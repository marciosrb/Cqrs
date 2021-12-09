using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.DataAcess;
using MediatR;
using Templates.Application.Command.DeleteProduto;

namespace CQRS.Application.Command.DeleteProduto
{
   public class CreateProdutoCommand : IRequestHandler<DeleteProdutoRequest, DeleteProdutoResponse>
    {
         #region Properties
    private IProdutoRepository ProdutoRepository { get ;}

    #endregion

    #region Contructor
    public CreateProdutoCommand(IProdutoRepository produtoRepository)
    {
        ProdutoRepository = produtoRepository;
    }
    #endregion

    #region IRequestHandler Implementation 
    public async Task<DeleteProdutoResponse> Handle(DeleteProdutoRequest request, CancellationToken cancellationToken)
    {
        var response = new DeleteProdutoResponse();

        try
            {                
                var produto = ProdutoRepository.FindProdutoById(request.ProdutoId);

                if(ProdutoRepository.Delete(produto))
                {
                    response.Message = "Success";
                    response.StatusCode = (int)HttpStatusCode.OK;
                    return await Task.FromResult(response);
                } 

                response.Message = "Deleting failed.";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
               
                response.Message = "An unexpected error occurred.";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return await Task.FromResult(response);
            }
        }

        #endregion

    }
}