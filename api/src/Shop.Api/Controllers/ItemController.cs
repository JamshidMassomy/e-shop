using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Item;
using Shop.Application.Features.Item.CreateItem;

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
       //  [ProducesResponseType(typeof(PaginatedList<GetUserResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetItemById()
        {
            return Ok();

        }

        [HttpPost]
        [Authorize]
        public async Task<Result<ItemResponse>> SaveItem([FromBody] CreateItemRequest request)
        {
            var result = await _mediator.Send(request);
            return result;

        }

        [HttpDelete]
        [Authorize]
        // GET: ItemController/Details/5
        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize]
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

      

    }
}
