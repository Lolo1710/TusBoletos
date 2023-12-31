﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using ProyectotTUSBOLETOS.Context;
using ProyectotTUSBOLETOS.Entities;
using ProyectotTUSBOLETOS.Services;

namespace ProyectotTUSBOLETOS.Vistas
{
    /// <summary>
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        TotalServices services = new TotalServices();
        public Ventas()
        {
            InitializeComponent();
            GetUserTable();
            Gtotal();
        }

        decimal gtotal;
        TotalServices total = new TotalServices();

        public void GetUserTable()
        {
            Eventos.ItemsSource = services.GetVentas();
        }

        public void Gtotal()
        {
            gtotal = total.Monto();
            lblTotal.Content = gtotal;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();
            int? rol = Auth.Authentication.FkUser;
            using (var _context = new ApplicationDbContext())
            {
                usuario = _context.Usuarios.Find(rol);
            }
            if (usuario.FkRol == 1)
            {
                SuperAdmin admin = new SuperAdmin();
                admin.Show();
                this.Close();
            }
            else
            {
                Gerente gerente = new Gerente();
                gerente.Show();
                this.Close();
            }
        }

        private void Eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
