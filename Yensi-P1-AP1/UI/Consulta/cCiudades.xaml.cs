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

namespace Yensi_P1_AP1.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cCiudades.xaml
    /// </summary>
    public partial class cCiudades : Window
    {
        public cCiudades()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)

        {

            var listado = new List<Ciudades>();

            if (CriterioTextBox.Text.Trim().Length > 0)

            {

                switch (FiltroComboBox.SelectedIndex)

                {

                    case 0: //CiudadesId

                        listado = CiudadesBLL.GetList(e => e.CiudadID == Utilidades.ToInt(CriterioTextBox.Text));

                        break;



                    case 1: //Nombres                       

                        listado = CiudadesBLL.GetList(e => e.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));

                        break;

                }







            }

            else

            {

                listado = CiudadesBLL.GetList(c => true);

            }



            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;

        }
    }
}
