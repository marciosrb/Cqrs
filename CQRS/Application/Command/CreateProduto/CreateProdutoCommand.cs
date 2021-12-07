using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Domain.DataAcess;
using MediatR;

namespace CQRS.Application.Command.CreateProduto
{
    public class CreateProdutoCommand : IRequestHandler<CreateProdutoRequest, CreateProdutoResponse>
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
    public async Task<CreateProdutoResponse> Handle(CreateProdutoRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateProdutoResponse();

        try
        {
            var produto = new CreateProdutoAdapter().Adapt(request.Produto);
            
            var resultado =  await ProdutoRepository.Create(produto);                                 

            response.Message = "Success";
            response.StatusCode = (int)HttpStatusCode.OK;
            response.ProdutoId = resultado.Id;
            
            return await Task.FromResult(response);
            
        }
        catch (Exception ex)
            {
                response.Message = "An unexpected error occurred. ";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                return await Task.FromResult(response);
            }
    }
     #endregion
    }
}