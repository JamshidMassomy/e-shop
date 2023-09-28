using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Item;
using Shop.Application.Features.Item.CreateItem;
using Shop.Application.Features.Item.GetAllItem;
using Shop.Application.Features.Item.GetItemById;
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
        [Authorize]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Result<ItemResponse>> GetItemById(GetItemByIdRequest Id)
        {
            var result = await _mediator.Send(Id);
            return result;

        }

        [HttpPost]
        [Authorize]
        public async Task<Result<ItemResponse>> SaveItem([FromBody] CreateItemRequest request)
        {
            var result = await _mediator.Send(request);
            return result;

        }

        [HttpGet]
        [AllowAnonymous]
        [TranslateResultToActionResult]
        // [ExpectedFailures(ResultStatus.Invalid, ResultStatus.NotFound)]
        public async Task<ActionResult<PaginatedList<ItemResponse>>> FetchAllItems([FromQuery] AllItemRequest request)
        {
            return Ok(await _mediator.Send(request));
          
        }

        [HttpDelete]
        [Authorize]
        // GET: ItemController/Details/5
        public ActionResult Details(ItemId Id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize]
        public ActionResult Edit(ItemId Id)
        {
            throw new NotImplementedException();
        }

      

    }
}
