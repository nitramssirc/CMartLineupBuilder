using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Application.Commands.AddProjections;
using Application.Repositories;
using Application.Specifications.Factory;
using Domain.Entities;
using Domain.ValueTypes;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Application.Specifications;
using Application.Specifications.SlateSpecs;

namespace Application.Tests.Commands.AddProjections
{
    [TestClass]
    public class AddProjectionsCommandTests_RotoGrindersNBAProjections
    {
        private Mock<ICommandRepository<Slate>> _mockSlateRepository;
        private Mock<ISpecificationFactory> _mockSpecFactory;
        private IRequestHandler<AddRotoGrindersNBAProjections, AddProjectionsResponse> _command;

        public AddProjectionsCommandTests_RotoGrindersNBAProjections()
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
            _command = new AddProjectionsCommand(_mockSlateRepository.Object, _mockSpecFactory.Object);
        }

        private (AddRotoGrindersNBAProjections request, Slate slate) SetupForHandle(
            List<RotoGrindersNBAProjection>? projections = null,
            Slate? slate = null,
            bool returnsNullSlate = false)
        {
            var slateID = new SlateID(Guid.NewGuid());
            projections ??= new List<RotoGrindersNBAProjection>
            {
                new RotoGrindersNBAProjection(1, "ATL", "BOS", "PG", "Player1", 50, 20, 10, 30, 35, 60, 40, 10, 50, 5, 8000, "", 1001, 2001)
            };
            var request = new AddRotoGrindersNBAProjections(slateID, projections);
            slate ??= returnsNullSlate ? null : Slate.Create(DateTime.Now, Sport.NBA, GameType.Cash, DFSSite.DraftKings, "TestSlate");

            var spec = new GetSlateByIDWithProjections(new SlateID());
            _mockSpecFactory.Setup(factory => factory.Create<GetSlateByIDWithProjections>(slateID)).Returns(spec);
            _mockSlateRepository.Setup(repo => repo.GetEntity(spec)).ReturnsAsync(slate);

            return (request, slate!);
        }

        #region Tests

        #region Handle

        [TestMethod]
        public async Task Handle_RotoGrindersNBAProjections_Should_ClearAllRotoGrindersProjections()
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
        public async Task Handle_RotoGrindersNBAProjections_Should_AddRequestedProjections()
        {
            // Arrange
            var (request, slate) = SetupForHandle();

            // Act
            await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(1, slate.Projections.Count);
            Assert.AreEqual("Player1", slate.Projections.First().PlayerName);
        }

        [TestMethod]
        public async Task Handle_RotoGrindersNBAProjections_Should_ReturnSuccessfulResponse()
        {
            // Arrange
            var (request, slate) = SetupForHandle();

            // Act
            var response = await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task Handle_RotoGrindersNBAProjections_Should_ReturnError_When_SlateCannotBeFound()
        {
            // Arrange
            var (request, _) = SetupForHandle(returnsNullSlate:true);

            // Act
            var response = await _command.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsFalse(response.Success);
            Assert.AreEqual(response.Error, "Error Adding Projections: Slate Not Found");
        }

        [TestMethod]
        public async Task Handle_RotoGrindersNBAProjections_Should_ReturnError_When_SaveFails()
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





