using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Yensi_P1_AP1.BLL;
using Yensi_P1_AP1.Entities;

namespace Yensi_P1_AP1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rCiudades.xaml
    /// </summary>
    public partial class rCiudades : Window
    {
        private  Ciudades ciudades = new Ciudades();
        public rCiudades()
        {
            InitializeComponent();
            this.DataContext = ciudades;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ciudades;
        }

        private void Limpiar()
        {
            this.ciudades = new Ciudades();
            this.DataContext = ciudades;

        }

        private bool Validar()
        {
            bool esValido = true;
            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion fallida", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }

        private void BuButton_Clic(object serder, RoutedEventArgs e)
        {
            Ciudades encotrado = CiudadesBLL.Buscar(Utilidades.ToInt(CiudadesIdTextBox.Text));
            if (encotrado != null)
            {
                this.ciudades = encotrado;
                Cargar();
                MessageBox.Show("Puntos encontrados!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object serder, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object serder, RoutedEventArgs e)
        {

            if (!Validar())
            {
                return;
            }
            var paso = CiudadesBLL.Guardar(ciudades);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)

        {

            if (CiudadesBLL.Eliminar(Utilidades.ToInt(CiudadesIdTextBox.Text)))

            {

                Limpiar();

                MessageBox.Show("Eliminado", "EXITO");

            }

            else

            {

                MessageBox.Show("No se pudo eliminar", "Error");

            }

        }

    }
}
