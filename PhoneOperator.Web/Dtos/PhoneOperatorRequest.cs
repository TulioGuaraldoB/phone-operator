using System.Text.Json.Serialization;

namespace PhoneOperator.Web.Dtos
{
    public class PhoneOperatorRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("operator_code")]
        public int OperatorCode { get; set; }
    }
}