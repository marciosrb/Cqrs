using CQRS.Domain.DataAcess;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Queries
{
    public class GetProdutoByIdQuery : IRequestHandler<GetProdutoByIdRequest, GetProdutoByIdResponse>
    {
        #region Properties
        private IProdutoRepository ProdutoRepository { get; }

        #endregion

        #region Constructor

        public GetProdutoByIdQuery(
            IProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        #endregion

        public async Task<GetProdutoByIdResponse> Handle(
            GetProdutoByIdRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetProdutoByIdResponse();

            try
            {
                var produto = ProdutoRepository.FindProdutoById(request.ProdutoId);

                if (produto == null)
                {
                    response.Message = "Nenhum produto encontrado";
                    response.StatusCode = (int)HttpStatusCode.NoContent;

                    return await Task.FromResult(response);
                }

                var result = new GetProdutoByUserAdapter().Adapt(produto);

                response.Produto = result;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Success";

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "An unexpected error occurred.";

                return await Task.FromResult(response);
            }
        }
    }
}