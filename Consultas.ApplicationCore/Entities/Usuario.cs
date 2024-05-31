using System.ComponentModel.DataAnnotations;

namespace Consultas.ApplicationCore.Entities
{
    public class Usuario
    {
        [Key]
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}
