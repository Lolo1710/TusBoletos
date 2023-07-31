using LiveCharts.Wpf;
using ProyectotTUSBOLETOS.Entities;
using ProyectotTUSBOLETOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectotTUSBOLETOS.Vistas
{
    /// <summary>
    /// Lógica de interacción para Roles.xaml
    /// </summary>
    public partial class Roles : Window
    {
        RolesServices services = new RolesServices();
        public Roles()
        {
            InitializeComponent();
            GetRolesTable();
        }

        public void GetRolesTable()
        {
            UserTable.ItemsSource = services.GetRoles();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Rol roles = new Rol();
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (txtPkUser.Text == "")
                {
                    roles.Nombre = txtNombre.Text;

                    services.AddRoles(roles);

                    txtNombre.Clear();

                    MessageBox.Show("Se agrego correctamente");
                    GetRolesTable();
                }

                else
                {
                    roles.PkRol = int.Parse(txtPkUser.Text);
                    roles.Nombre = txtNombre.Text;

                    services.UpdateRol(roles);

                    txtPkUser.Clear();
                    txtNombre.Clear();

                    MessageBox.Show("Se actualizo correctamente");
                    GetRolesTable();
                }
            }
            else 
            {
                MessageBox.Show("Faltan datos por agregar");

            }
        }

        public void EditItem(object sender, RoutedEventArgs e)
        {
            Rol rol = new Rol();

            rol = (sender as FrameworkElement).DataContext as Rol; //Esta funcion traera la selecion de la fila 

            txtPkUser.Text = rol.PkRol.ToString();
            txtNombre.Text = rol.Nombre.ToString();
        }

        private void ElimiarItem(object sender, RoutedEventArgs e)
        {
            Rol rol = new Rol();
            RolesServices services = new RolesServices();
            rol = (sender as FrameworkElement).DataContext as Rol;
            rol.PkRol.ToString();
            services.DeleteRol(rol);

            MessageBox.Show("Se elimino el usuario");
            GetRolesTable();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                txtPkUser.Clear();
                txtNombre.Clear();
            }
            else
            {
                MessageBox.Show("Faltan datos por agregar");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            SuperAdmin admin = new SuperAdmin();
            admin.Show();
            this.Close();
        }
    }
}