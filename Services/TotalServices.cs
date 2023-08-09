using Microsoft.EntityFrameworkCore;
using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Services
{
    public class TotalServices
    {
        public decimal Monto()
        {
            using (var _context = new ApplicationDbContext())
            {
                decimal total;
                total = _context.Ventas.Sum(x => x.Total);
                return total;
            }
        }

        public List<Venta> GetVentas()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    List<Venta> ventas = new List<Venta>();

                    return _context.Ventas
                        .Include(x => x.Usuarios)
                        .Include(x => x.Eventos)
                        .ToList();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }
    }
}
