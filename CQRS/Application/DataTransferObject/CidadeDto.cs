using System.Text.Json.Serialization;
using CQRS.CrossCutting.Commom;
using CQRS.Domain.Entity;
using CQRS.Domain.Enum;

namespace CQRS.Application.DataTransferObject
{
public class CidadeDto
{
        [JsonPropertyNameAttribute("cidade")]         
        public string Cidade { get; set; }

        internal static CidadeDto Build(Produto cidade)
        {
            var cidadestatus = EnumExtensions.GetDescription<CidadeEnum>((CidadeEnum)cidade.Cidade);
            var cidadeEnum = new CidadeDto{
                Cidade = cidadestatus
            };

            return cidadeEnum;
        }

       

}
}