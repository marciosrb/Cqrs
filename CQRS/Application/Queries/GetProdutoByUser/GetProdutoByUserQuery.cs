using System.Collections.Generic;
using CQRS.Domain.DataAcess;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Application.DataTransferObject;

namespace CQRS.Application.Queries.GetProdutoByUser
{
    public class GetProdutoByUserQuery : IRequestHandler<GetProdutoByUserRequest, GetProdutoByUserResponse>
    {
        #region Properties
        private IProdutoRepository ProdutoRepository { get; }

        #endregion

        #region Constructor

        public GetProdutoByUserQuery(
            IProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        #endregion

        public async Task<GetProdutoByUserResponse> Handle(
           GetProdutoByUserRequest request,
           CancellationToken cancellationToken)
        {
            var response = new GetProdutoByUserResponse();
           // var adapter = new GetProdutoByUserAdapter();

            try
            {
                var produto = ProdutoRepository.FindProdutoByUser(request.UserName);

               // var listaProduto = adapter.Adapt(produto);  
               var listaProduto = new GetProdutoByUserAdapter().Adapt(produto);

               /* if (produto.Count == 0)
                {
                    response.Message = "Nenhum cadastro encontrado";
                    response.StatusCode = (int)HttpStatusCode.NoContent;

                    return await Task.FromResult(response);
                }*/

                response.Produto = listaProduto;
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