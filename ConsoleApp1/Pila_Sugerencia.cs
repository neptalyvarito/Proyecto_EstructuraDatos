using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp1
{
    internal class Pila_Sugerencia
    {
        public Sugerencias sugerencia;

        public Pila_Sugerencia()
        {
            sugerencia = null;
        }

        public void AgregarSug(string sugerenciaDeUser)
        {
            DateTime fechaCrea = DateTime.Now;
            string creador = "Anonimo";
            Sugerencias q = new Sugerencias(creador, sugerenciaDeUser, fechaCrea);
            if (sugerencia == null)
            {
                sugerencia = q;
            }
            else
            {
                q.sgte = sugerencia;
                sugerencia = q;
            }
        }

        public Sugerencias QuitarSug()
        {
            Sugerencias q;
            
            if (sugerencia == null)
            {
                Console.WriteLine("Lista de sugerencias vacia ... ");
                q = null;
            }
            else
            {
                q = sugerencia;
                sugerencia = sugerencia.sgte;
            }
            return q;
        }

        public void MostrarSugerencia()
        {
            Sugerencias t = sugerencia;
           
            Console.WriteLine(" Creador " + " | Sugerencia".PadRight(30,' ')+ " | Fecha Creacion");
            while (t != null)
            {
                Console.WriteLine(" " + t.creador + "  | " + t.sugerencia.PadRight(30,' ') + " | " +t.fechaCreacion.ToString());
                t = t.sgte;
            }
        }



    }
}
