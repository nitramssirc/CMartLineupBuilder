using Application.Queries.GetSlateById;
using Application.Repositories;
using Application.Specifications.Factory;
using Application.Specifications;
using Common.Enums;
using Domain.Entities;
using Domain.ValueTypes;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Specifications.SlateSpecs;

namespace ApplicationTests.Queries.GetSlateById
{
    [TestClass]
    public class GetSlateByIdHandlerTests
    {
        private Mock<ISpecificationFactory> _specificationFactoryMock;
        private Mock<IQueryRepository<Slate>> _slateRepositoryMock;
        private GetSlateByIdHandler _handler;
        public GetSlateByIdHandlerTests()
        {
            _specificationFactoryMock = null!;
            _slateRepositoryMock = null!;
            _handler = null!;
        }

        [TestInitialize]
        public void Setup()
        {
            _specificationFactoryMock = new Mock<ISpecificationFactory>();
            _slateRepositoryMock = new Mock<IQueryRepository<Slate>>();
            _handler = new GetSlateByIdHandler(_specificationFactoryMock.Object, _slateRepositoryMock.Object);
        }

        #region Tests

        #region Handle

        [TestMethod]
        public async Task Handle_Should_ReturnGetSlateByIdResponse_When_SlateExists()
        {
            // Arrange
            var slateId = new SlateID();
            var slate = Slate.Create(DateTime.Now, Sport.NFL, GameType.Cash, DFSSite.DraftKings, "Test Slate");
            var request = new GetSlateByIdQuery(slateId);
            var specification = new GetSlateByIdSpec(slateId);

            _specificationFactoryMock.Setup(f => f.Create<GetSlateByIdSpec>(slateId)).Returns(specification);
            _slateRepositoryMock.Setup(r => r.GetEntity(specification)).ReturnsAsync(slate);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(slate.Sport, result.Sport);
            Assert.AreEqual(slate.GameType, result.GameType);
            Assert.AreEqual(slate.DFSSite, result.DFSSite);
            Assert.AreEqual(slate.Name, result.Name);
        }

        [TestMethod]
        public async Task Handle_Should_ThrowException_When_SlateNotFound()
        {
            // Arrange
            var slateId = new SlateID();
            var request = new GetSlateByIdQuery(slateId);
            var specification = new GetSlateByIdSpec(slateId);

            _specificationFactoryMock.Setup(f => f.Create<GetSlateByIdSpec>(slateId)).Returns(specification);
            _slateRepositoryMock.Setup(r => r.GetEntity(specification)).ReturnsAsync((Slate)null!);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _handler.Handle(request, CancellationToken.None));
        }

        #endregion

        #endregion
    }
}
