using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Zadanie_5.Models
{
    public class Product
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("id"), NotMapped]
        public string IdJson { get; set; }
        [Required, MaxLength(100)]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
