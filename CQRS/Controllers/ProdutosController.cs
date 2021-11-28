using Ardalis.GuardClauses;
using CQRS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        #region Properties

        private IMediator Mediator { get; }

        #endregion

        #region Constructor

        public ProdutosController(
        IMediator mediator
       )
        {
            Guard.Against.Null(mediator, nameof(mediator));

            Mediator = mediator;
        }

        #endregion

        [HttpGet]
        [Route("{produtoId}")]
        public async Task<ActionResult> GetProdutoById(
           [FromRoute] string produtoId,
           CancellationToken cancellationToken)
        {
            var request = new GetProdutoByIdRequest
            {
                ProdutoId = produtoId
            };

            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}