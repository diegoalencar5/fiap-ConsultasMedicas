using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consultas.ApplicationCore.Entities
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        public string? Nome { get; set; }
        [JsonIgnore]
        public virtual ICollection<Consulta>? Consultas { get; set; }
    }
}
