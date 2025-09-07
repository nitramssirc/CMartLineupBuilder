using Moq;
using Application.Commands.AddProjections;
using Application.Repositories;
using Application.Specifications.Factory;
using Domain.Entities;
using Domain.ValueTypes;
using Common.Enums;
using MediatR;
using Application.Specifications.SlateSpecs;
using Application.Commands.AddProjections.Models;

namespace ApplicationTests.Commands.AddProjections
{
    [TestClass]
    public class Test_AddProjectionsHandler
    {
        private Mock<ICommandRepository<Slate>> _mockSlateRepository;
        private Mock<ISpecificationFactory> _mockSpecFactory;
        private IRequestHandler<AddProjectionsCommand, AddProjectionsResponse> _command;

        public Test_AddProjectionsHandler()
        {
            _mockSlateRepository = null!;
            _mockSpecFactory = null!;
            _command = null!;
        }

        [TestInitialize]
        public void Setup()
        {
            _mockSlateRepository = new Mock<ICommandRepository<Slate>>();
            _mockSpecFactory = new Mock<ISpecificationFactory>();
            _command = new AddProjectionsHandler(_mockSlateRepository.Object, _mockSpecFactory.Object);
        }

        private class TestUploadedProjection : UploadedProjection
        {
            public override string Name { get; }

            public override Team Team { get; }

            public override IEnumerable<ProjectionData> ProjectionData { get; }

            public TestUploadedProjection(
                string name = "Name",
                Team team = Team.DAL,
                ProjectionData projectionData = null!)
            {
                Name = name;
                Team = team;
                ProjectionData = projectionData == null ? new List<ProjectionData>() : new List<ProjectionData> { projectionData };
            }
        }

        private (AddProjectionsCommand request, Slate slate) SetupForHandle(
            List<TestUploadedProjection>? projections = null,
            Slate? slate = null,
            ProjectionSource projectionSource = default,
            bool returnsNullSlate = false)
        {
            var slateID = new SlateID(Guid.NewGuid());
            projections ??= new List<TestUploadedProjection>
            {
                new TestUploadedProjection()
            };
            var request = new AddProjectionsCommand(slateID, projectionSource, projections);
            slate ??= returnsNullSlate ? null : Slate.Create(DateTime.Now, Sport.NBA, GameType.Cash, DFSSite.DraftKings, "TestSlate");

            var spec = new GetSlateByIDWithProjectionsSpec(new SlateID());
            _mockSpecFactory.Setup(factory => factory.Create<GetSlateByIDWithProjectionsSpec>(slateID)).Returns(spec);
            _mockSlateRepository.Setup(repo => repo.GetEntity(spec)).ReturnsAsync(slate);

            return (request, slate!);
        }

        #region Tests

        #region Handle

        [TestMethod]
        public async Task Handle_Should_ClearAllRotoGrindersProjections()
        {
            // Arrange
            var (request, slate) = SetupForHandle();
            slate.AddProjection(Projection.Create(request.SlateID, ProjectionSource.RotoGrinders, "ExistingPlayer", Team.ATL, new List<ProjectionData>()));

            // Act
            await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsFalse(slate.Projections.Any(p => p.ProjectionSource == ProjectionSource.RotoGrinders && p.PlayerName == "ExistingPlayer"));
        }

        [TestMethod]
        public async Task Handle_Should_AddRequestedProjections()
        {
            // Arrange
            var (request, slate) = SetupForHandle(projections:
                new List<TestUploadedProjection>
                {
                    new TestUploadedProjection(name: "Player1")
                });

            // Act
            await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(1, slate.Projections.Count);
            Assert.AreEqual("Player1", slate.Projections.First().PlayerName);
        }

        [TestMethod]
        public async Task Handle_Should_ReturnSuccessfulResponse()
        {
            // Arrange
            var (request, slate) = SetupForHandle();

            // Act
            var response = await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task Handle_Should_ReturnError_When_SlateCannotBeFound()
        {
            // Arrange
            var (request, _) = SetupForHandle(returnsNullSlate: true);

            // Act
            var response = await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsFalse(response.Success);
            Assert.AreEqual(response.Error, "Error Adding Projections: Slate Not Found");
        }

        [TestMethod]
        public async Task Handle_Should_ReturnError_When_SaveFails()
        {
            // Arrange
            var (request, slate) = SetupForHandle();
            var exception = new Exception("Save failed");
            _mockSlateRepository.Setup(repo => repo.SaveAsync()).ThrowsAsync(exception);

            // Act
            var response = await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsFalse(response.Success);
            Assert.IsTrue(response.Error.Contains($"Error Adding Projections: {exception}"));
        }

        #endregion

        #endregion
    }
}





