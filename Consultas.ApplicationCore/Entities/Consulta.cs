using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultas.ApplicationCore.Entities
{
    public class Consulta
    {
        [Key]
        public int IdConsulta { get; set; }        
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public DateTime DtConsulta { get; set; }        
        public string? Observacoes { get; set; }
        public bool Inativa { get; set; } = false;
        [ForeignKey("IdPaciente")]
        public Paciente? Paciente { get; set; }
        [ForeignKey("IdMedico")]
        public Medico? Medico { get; set; }
    }
}