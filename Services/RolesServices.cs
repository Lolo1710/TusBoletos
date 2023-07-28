using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectotTUSBOLETOS.Services
{
    public class RolesServices
    {
        public void AddRoles(Rol request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Rol res = new Rol();
                        res.Nombre = request.Nombre;
                        _context.Roles.Add(res);
                        _context.SaveChanges();

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }

        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();

                    return roles;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }

        public void DeleteRol(Rol request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Rol roles = new Rol();
                    roles = _context.Roles.Find(request.PkRol);
                    roles.Nombre = request.Nombre;

                    _context.Roles.Remove(roles);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sucedio un error: {ex.Message}");
            }
        }
        public void UpdateRol(Rol request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Rol roles = new Rol();
                    roles = _context.Roles.Find(request.PkRol);
                    roles.Nombre = request.Nombre;

                    _context.Roles.Update(roles);
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


