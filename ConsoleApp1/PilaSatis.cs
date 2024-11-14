using ConsoleApp1.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PilaSatis
    {
        public Satisfaccion pilaS;
        public int contadorS;
        public string usuario;
        public PilaSatis()
        {
            pilaS = null;
        }

        public void push(string satisfaccion, string interfaz, string personal, string comentario, string colaborador)
        {
            usuario = "Anónimo" + contadorS;
            Satisfaccion q = new Satisfaccion(usuario, satisfaccion, interfaz, personal, comentario, colaborador);
            if (pilaS == null)
            {
                pilaS = q;
            }
            else
            {
                q.sgte = pilaS;
                pilaS = q;
            }
            contadorS++;
        }

        public void pop()
        {
            if (pilaS == null)
            {
                Console.WriteLine("Pila vacia ... ");

            }
            else
            {
                pilaS = pilaS.sgte;
                Console.WriteLine(" Pila eliminada exitosamente...");
            }
        }

        public void muestraPila()
        {
            Satisfaccion t = pilaS;
            Console.WriteLine("| Usuario |    Satisfacción    |     Interfaz     |        Personal        |        Comentario        |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            while (t != null)
            {
                Console.WriteLine(t.usuario + " |" + t.satisfaccion + "|  " + t.interfaz + " | " + t.personal + " | " + t.comentario + " |");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                t = t.sgte;
            }
        }
    }
}
