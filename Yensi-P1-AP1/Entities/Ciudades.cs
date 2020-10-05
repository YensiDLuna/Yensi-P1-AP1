using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yensi_P1_AP1.Entities
{
    public class Ciudades

    {
        [Key]
        public int CiudadID { get; set; }
        public string Nombre { get; set; }

        public Ciudades(int ciudadID, string nombre)
        {
            CiudadID = ciudadID;
            Nombre = nombre;
        }

        public Ciudades()
        {
            CiudadID = 0;
            Nombre = string.Empty;
        }
    }
}
