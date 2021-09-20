using System.Threading;
using System.Threading.Tasks;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : BaseController
    {
        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search(
            [FromBody] CustomerSearchRequest request, CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(request, cancellationToken);
            return Ok(res);
        }

        public CustomerController(IMediator mediator) : base(mediator)
        {
        }
    }
}