using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Consultas.ApplicationCore.Entities
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public string? Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? Sexo { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        [JsonIgnore]
        public virtual ICollection<Consulta>? Consultas { get; set; }
    }
}
