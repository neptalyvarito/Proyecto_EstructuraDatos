using ConsoleApp1.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Clase para las operaciones del nodo "Salones"
    internal class ABBOptimizado_Salon
    {
        public Arbol_Compus Compus = new Arbol_Compus();
        public Salones salon;
        public ABBOptimizado_Salon()
        {
            salon = null;
        }
        public void insertarSalon(string codigoSalon, string tipo, string horarios, string profesor, string equipos, string estado, int alumnos)
        {
            int piso = 0;
            string codigocompu = " ", edificio = " ";
            Compus.buscarPorSalon(Compus.arbolito, codigoSalon, ref piso, ref edificio, ref codigocompu);
            string valorRaiz;
            Salones q = new Salones(codigoSalon, tipo, horarios, profesor, equipos, estado, edificio, alumnos, piso, codigocompu);
            Salones t = salon;

            if (salon == null)
            {
                salon = q;
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.codigoSalon;
                    if (codigoSalon.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izq != null)
                        {
                            t = t.izq;
                        }
                        else
                        {
                            t.izq = q;
                            return;
                        }
                    }
                    else
                    {
                        if (t.der != null)
                        {
                            t = t.der;
                        }
                        else
                        {
                            t.der = q;
                            return;
                        }
                    }
                }
            }
        }
        public void buscarSalon(string salonBuscado)
        {
            string valorRaiz;
            Salones t = salon;

            if (salon == null)
            {
                Console.WriteLine("El árbol está vacío... ");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.codigoSalon;
                    if (salonBuscado.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("\tSalón encontrado");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Código del salón: " + t.codigoSalon);
                        Console.WriteLine("Tipo de salón: " + t.tipo);
                        Console.WriteLine("Piso: " + t.piso);
                        Console.WriteLine("Profesores: " + t.profesor);
                        Console.WriteLine("Alumnos: " + t.alumnos);
                        Console.WriteLine("Equipos: " + t.equipos);
                        Console.WriteLine("Codigo de una computadora: " + t.codigoCompu);
                        Console.WriteLine("Horarios: " + t.horarios);
                        Console.WriteLine("Estado: " + t.estado);
                        Console.WriteLine("-----------------------------------");
                    }
                    if (salonBuscado.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izq != null)
                        {
                            t = t.izq;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (t.der != null)
                        {
                            t = t.der;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        public void mostrarArbol(Salones arb, int cont)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                mostrarArbol(arb.der, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(arb.codigoSalon);
                mostrarArbol(arb.izq, cont + 1);
            }
        }
        public void MostrarArbolEnOrden(Salones arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                MostrarArbolEnOrden(arb.izq);

                Console.WriteLine(arb.codigoSalon + " |" + arb.tipo + "|  " + arb.piso + " | " + arb.profesor + " | " + arb.alumnos + " | " + arb.equipos + " | " + arb.codigoCompu + " | " + arb.horarios + " | " + arb.estado);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                MostrarArbolEnOrden(arb.der);
            }
        }
    }
}
