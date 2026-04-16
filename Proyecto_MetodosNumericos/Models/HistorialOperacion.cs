using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_MetodosNumericos.Models
{
    [Table("HistorialOperaciones")]
    public class HistorialOperacion
    {
        [Key]
        public int IdHistorial { get; set; }
        public int IdUsuario { get; set; }
        public string Metodo { get; set; }
        public string FuncionEvaluada { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
