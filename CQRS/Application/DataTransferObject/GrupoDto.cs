using System.Collections.Generic;

namespace CQRS.Application.DataTransferObject
{
    public class GrupoDto
    {
        public KeyGrupoDto Key { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
        
    }
}