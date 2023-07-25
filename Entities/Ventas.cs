using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Entities
{
    public class Venta
    {
        [Key]
        public int PkVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Eventos")]
        public int? FkEvento { get; set; }
        public Evento Eventos { get; set; }

        [ForeignKey("Usuarios")]
        public int? FkUsuario { get; set; }
        public Usuario Usuarios { get; set; }
    }
}
