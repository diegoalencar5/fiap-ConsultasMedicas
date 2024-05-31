using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Consultas.WebApplication.Models
{
    public class PacienteViewModel
    {
        public int IdPaciente { get; set; }

        [DisplayName("Nome")]
        public string? Nome { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data de Nascimento")]
        public DateTime DtNascimento { get; set; }

        [DisplayName("Sexo")]
        public string? Sexo { get; set; }

        [DisplayName("Endereco")]
        public string? Endereco { get; set; }

        [DisplayName("Email")]
        public string? Email { get; set; }

        [DisplayName("Telefone")]
        public string? Telefone { get; set; }
    }
}
