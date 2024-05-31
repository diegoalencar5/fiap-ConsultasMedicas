using Consultas.ApplicationCore.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Consultas.WebApplication.Models
{
    public class ConsultaViewModel
    {
        [DisplayName("Código")]        
        public int IdConsulta { get; set; }
        public int IdMedico { get; set; }        
        public int IdPaciente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Data da Consulta")]
        public DateTime DtConsulta { get; set; }

        [DisplayName("Observações")]
        public string? Observacoes { get; set; }

        [DisplayName("Medico")]
        public Medico Medico { get; set; }

        [DisplayName("Paciente")]
        public Paciente Paciente { get; set; }
    }
}
