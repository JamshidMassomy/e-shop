using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Item;
using Shop.Application.Features.Item.CreateItem;
using Shop.Application.Features.Item.DeleteItem;
using Shop.Application.Features.Item.GetAllItem;
using Shop.Application.Features.Item.GetItemById;
using Shop.Application.Features.Item.UpdateItem;
using Shop.Application.Response;
using Shop.Domain.Entities.Common;


namespace Shop.Api.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator) { 
            _mediator = mediator;
        }


        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Result<ItemResponse>> GetItemById(GetItemByIdRequest Id)
        {
            var result = await _mediator.Send(Id);
            return result;

        }


        [HttpPost]
        [TranslateResultToActionResult]
        public async Task<Result<ItemResponse>> SaveItem([FromBody] CreateItemRequest request)
        {
            var result = await _mediator.Send(request);
            return result;

        }

        [HttpGet]
        [TranslateResultToActionResult]
        [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound, ResultStatus.Unauthorized)]
        public async Task<ActionResult<PaginatedList<ItemResponse>>> FetchAllItems([FromQuery] AllItemRequest request)
        {
            return Ok(await _mediator.Send(request));
          
        }


        [HttpPut("{id}")]
        [TranslateResultToActionResult]
        [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound)]
        public async Task<Result<ItemResponse>> Update(ItemId id, [FromBody] UpdateItemRequest request)
        {
            var result = await _mediator.Send(request with { Id = id });
            return result;
        }


        [HttpDelete("{id}")]
        [TranslateResultToActionResult]
        [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound)]
        public async Task<Result> Delete(ItemId id)
        {
            var result = await _mediator.Send(new DeleteItemRequest(id));
            return result;
        }


    }
}
