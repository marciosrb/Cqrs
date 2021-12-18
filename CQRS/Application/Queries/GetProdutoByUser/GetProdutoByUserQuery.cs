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
        private IGrupoRepository GrupoRepository { get; }

        #endregion

        #region Constructor

        public GetProdutoByUserQuery(
            IProdutoRepository produtoRepository,
            IGrupoRepository gruporepository)
        {
            ProdutoRepository = produtoRepository;
            GrupoRepository = gruporepository;
        }

        #endregion

        public async Task<GetProdutoByUserResponse> Handle(
           GetProdutoByUserRequest request,
           CancellationToken cancellationToken)
        {
            var response = new GetProdutoByUserResponse();
            var adapter = new GetProdutoByUserAdapter();

            try
            {
                var produto = ProdutoRepository.FindProdutoByUser(request.UserName);

                if (produto.Count == 0)
                {
                    response.Message = "Nenhum cadastro encontrado";
                    response.StatusCode = (int)HttpStatusCode.NoContent;

                    return await Task.FromResult(response);
                }

                foreach ( var items in produto)
                {
                    if( items.Grupo != "")
                    {
                        var nomeGrupo = GrupoRepository.FindNomeGrupoById(items.Grupo);
                   
                        if( nomeGrupo == null)
                        {
                            items.Grupo = ""; 
                        }
                    }
                }

                var listaProduto = adapter.Adapt(produto);                 

                foreach (var groupItem in listaProduto)
                {
                    if( groupItem.Key.Grupo != "")
                        {
                            var nomeGrupo = GrupoRepository.FindNomeGrupoById(groupItem.Key.Grupo);

                            if (nomeGrupo != null)
                            {
                                groupItem.Key.Grupo = nomeGrupo.NomeGrupoSelected; 
                            }                                          
                        }
                    else
                        {
                           groupItem.Key.Grupo = "Sem Grupo";
                        }             
                }  

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