using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/catalog")]
    public class CatalogController : BaseController
    {
        public CatalogController(IMediator mediator) : base(mediator)
        {
            
        }
        
    }
}