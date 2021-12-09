using Ardalis.GuardClauses;
using CQRS.Application.Command.CreateProduto;
using CQRS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Templates.Application.Command.DeleteProduto;

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

        #region Commands
        [HttpPost]
        public async Task<ActionResult> CreateProduto(
            [FromBody] CreateProdutoRequest request,
            CancellationToken cancellationToken)
        {           
            var response = await Mediator.Send(request, cancellationToken);
            
            return Ok(response);
        }

        #endregion

        [HttpGet]
        [Route("{nomeProduto}")]
        public async Task<ActionResult> GetProdutoByNome(
           [FromRoute] string nomeProduto,
           CancellationToken cancellationToken)
        {
            var request = new GetProdutoByNomeRequest
            {
                Nome = nomeProduto
            };

            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduto(
            [FromRoute] string id,            
            CancellationToken cancellationToken)
        {
            var request = new DeleteProdutoRequest
            {
                ProdutoId = id
            };
           
            var response = await Mediator.Send(request, cancellationToken);           

            return Ok(response);
        }
    }
}