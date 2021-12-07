using Ardalis.GuardClauses;
using CQRS.Application.Queries.GetProdutoByUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosAllController : ControllerBase
    {
        #region Properties

        private IMediator Mediator { get; }

        #endregion

        #region Constructor

        public ProdutosAllController(
        IMediator mediator
       )
        {
            Guard.Against.Null(mediator, nameof(mediator));

            Mediator = mediator;
        }

        #endregion

        [HttpGet]
        [Route("{userName}")]
        public async Task<ActionResult> GetProdutoByUser(
           [FromRoute] string userName,
           CancellationToken cancellationToken)
        {
            var request = new GetProdutoByUserRequest
            {
                UserName = userName
            };

            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}