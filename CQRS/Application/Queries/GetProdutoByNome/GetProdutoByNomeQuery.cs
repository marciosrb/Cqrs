using CQRS.Domain.DataAcess;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Queries
{
    public class GetProdutoByNomeQuery : IRequestHandler<GetProdutoByNomeRequest, GetProdutoByNomeResponse>
    {
        #region Properties
        private IProdutoRepository ProdutoRepository { get; }

        #endregion

        #region Constructor

        public GetProdutoByNomeQuery(
            IProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        #endregion

        public async Task<GetProdutoByNomeResponse> Handle(
            GetProdutoByNomeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetProdutoByNomeResponse();

            try
            {
                var produto = ProdutoRepository.FindProdutoByNome(request.Nome);

                if (produto == null)
                {
                    response.Message = "Nenhum produto encontrado";
                    response.StatusCode = (int)HttpStatusCode.NoContent;

                    return await Task.FromResult(response);
                }

                var result = new GetProdutoByNomeAdapter().Adapt(produto);

                response.Produto = result;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Success";

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "An unexpected error occurred. ";

                return await Task.FromResult(response);
            }
        }
    }
}