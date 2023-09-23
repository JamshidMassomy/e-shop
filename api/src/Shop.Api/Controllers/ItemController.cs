using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> SaveItem()
        {
            throw new NotImplementedException();
           
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
