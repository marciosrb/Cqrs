using System.Net.Sockets;
using System;
using CQRS.Application.DataTransferObject;

namespace CQRS.Application.Command.CreateProduto
{
    public class CreateProdutoAdapter
    {
        public Domain.Entity.Produto Adapt(ProdutoDto createProdutoDto)
        {
            return ProdutoDto.Build(createProdutoDto);
        }
    }

}