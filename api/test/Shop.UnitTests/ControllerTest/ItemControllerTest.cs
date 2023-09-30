using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shop.Api.Controllers;
using Shop.Application.Features.Item;
using Shop.Application.Features.Item.CreateItem;
using Shop.Application.Features.Item.GetAllItem;
using Shop.Application.Response;

namespace Shop.UnitTests.ControllerTest
{
    public class ItemControllerTest
    {
        [Fact]
        public async Task FetchAllItems_Returns_OkResult()
        {
            var mediatorMock = new Mock<IMediator>();
            var controller = new ItemController(mediatorMock.Object);
            var allItemRequest = new AllItemRequest
            {
                // Any request without parms
            };
            var expectedResult = Result<PaginatedList<ItemResponse>>.Success(new PaginatedList<ItemResponse>());

            mediatorMock.Setup(m => m.Send(allItemRequest, new CancellationToken())).ReturnsAsync(expectedResult);

            // Act
            var result = await controller.FetchAllItems(allItemRequest);

            // Assert
            var okResult = Assert.IsType<ActionResult<PaginatedList<ItemResponse>>>(result);
            Assert.IsType<ActionResult<PaginatedList<ItemResponse>>>(okResult);
        }

        [Fact]
        public async Task SaveItem_Returns_OkResult()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new ItemController(mediatorMock.Object);
            var createItemRequest = new CreateItemRequest
            {
                Name = "Apple",
                Price = 10,
                Description = "Apple newst product",
            };

            var expectedResult = Result<ItemResponse>.Success(new ItemResponse());


            mediatorMock.Setup(m => m.Send(createItemRequest, new CancellationToken())).ReturnsAsync(expectedResult);

            // Act
            var result = await controller.SaveItem(createItemRequest);

            // Assert
            Assert.IsType<Result<ItemResponse>>(result);
        }
    }
}
