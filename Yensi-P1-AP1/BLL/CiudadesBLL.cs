using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Yensi_P1_AP1.DAL;
using Yensi_P1_AP1.Entities;

namespace Yensi_P1_AP1.BLL
{
    public class CiudadesBLL
    {
        public static bool Guardar(Ciudades ciudades)
        {
            if (!Existe(ciudades.CiudadID)) 
                return Insertar(ciudades);
            else
                return Modificar(ciudades);
        }

        private static bool Insertar(Ciudades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Ciudades.Add(ciudades);
                paso = contexto.SaveChanges() > 0;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Ciudades ciudades)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(ciudades).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }

            catch (Exception)
            {
                throw;

            }

            finally
            {
                contexto.Dispose();
            }

            return paso;

        }


        public static Ciudades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ciudades ciudades;


            try
            {
               ciudades = contexto.Ciudades.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return ciudades;
        }

        public static List<Ciudades> GetList(Expression<Func<Ciudades, bool>> criterio)
        {

            List<Ciudades> lista = new List<Ciudades>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ciudades.Where(criterio).ToList();

            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ciudades.Any(e => e.CiudadID == id);
            }

            catch (Exception)
            {
                throw;

            }

            finally
            {

                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                var vehiculos = contexto.Ciudades.Find(id);

                if (vehiculos != null)
                {
                    contexto.Ciudades.Remove(vehiculos);
                    paso = contexto.SaveChanges() > 0;

                }


            }

            catch (Exception)
            {
                throw;
            }

            finally
            {

                contexto.Dispose();

            }

            return paso;

        }

    }
}
