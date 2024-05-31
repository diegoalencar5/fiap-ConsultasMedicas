using System.ComponentModel;

namespace Consultas.WebApplication.Models
{
    public class MedicoViewModel
    {
        public int IdMedico { get; set; }
        [DisplayName("Nome")]
        public string? Nome { get; set; }
    }
}
