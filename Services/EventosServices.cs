using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Services
{
    class EventosServices
    {

        public List<Evento> GetEventos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {

                    List<Evento> eventos = new List<Evento>();

                    eventos = _context.Eventos.ToList();

                    return eventos;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }
        public void AddEvent(Evento request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Evento res = new Evento();
                        res.Nombre = request.Nombre;
                        res.Descripcion = request.Descripcion;
                        res.Asientos = request.Asientos;
                        res.Fecha = request.Fecha;
                        res.Precio = request.Precio;
                        _context.Eventos.Add(res);
                        _context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }
        public void DeleteEvent(Evento request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Evento evento = new Evento();
                    evento = _context.Eventos.Find(request.PkEvento);
                    evento.Nombre = request.Nombre;
                    evento.Descripcion = request.Descripcion;
                    evento.Asientos = request.Asientos;
                    evento.Fecha = request.Fecha;
                    evento.Precio = request.Precio;

                    _context.Eventos.Remove(evento);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sucedio un error: {ex.Message}");
            }
        }
        public void UpdateEvent(Evento request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Evento evento = new Evento();
                    evento = _context.Eventos.Find(request.PkEvento);
                    evento.Nombre = request.Nombre;
                    evento.Descripcion = request.Descripcion;
                    evento.Asientos = request.Asientos;
                    evento.Fecha = request.Fecha;
                    evento.Precio = request.Precio;

                    _context.Eventos.Update(evento);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sucedio un error: {ex.Message}");
            }
        }
    }
}
