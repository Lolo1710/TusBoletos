using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Entities
{
    public class Evento
    {
        [Key]
        public int PkEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Asientos { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
    }
}
