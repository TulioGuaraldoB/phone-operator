using System.Text.Json.Serialization;

namespace PhoneOperator.Web.Dtos
{
    public class PhoneOperatorResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("operator_code")]
        public int OperatorCode { get; set; }
    }
}