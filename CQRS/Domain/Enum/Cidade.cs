using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CQRS.Domain.Enum
{  
    public enum Cidade 
    {
        [Description("Sorocaba")]
        SOROCABA = 1,

        [Description("Tatui")]
        TATUI = 2
    }
}