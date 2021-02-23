using System.Runtime.Serialization;

namespace TagSDK.Models.Enums
{
    public enum DocumentType
    {
        [EnumMember(Value = "CPF")]
        CPF,
        [EnumMember(Value = "CNPJ")]
        CNPJ
    }
}
