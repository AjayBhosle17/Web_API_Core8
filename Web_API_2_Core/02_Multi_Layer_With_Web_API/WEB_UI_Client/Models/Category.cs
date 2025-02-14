using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WEB_UI_Client.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [MinLength(2, ErrorMessage = "Plz Enter minimum 2 charcters")]

        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("order")]
        [Required(ErrorMessage = "Order Is Required")]
        [Range(1, 500, ErrorMessage = "Order Should be Between 1 and 500")]
        public int Order { get; set; }
    }
}
