using ConsoleApp1.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ArbolSatis
    {
        public NArbolSatis aSatis;

        public ArbolSatis()
        {
            aSatis = null;
        }
        public void insertarSatis(string satisfaccion, string interfaz, string personal, string comentario, string colaborador, PilaSatis PilaS)
        {
            string valorRaiz;
            NArbolSatis q = new NArbolSatis(PilaS.usuario, satisfaccion, interfaz, personal, comentario, colaborador);
            NArbolSatis t = aSatis;

            if (aSatis == null)
            {
                aSatis = q;
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.colaborador;
                    if (colaborador.CompareTo(valorRaiz) == -1)
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
        public void buscarColaborador()
        {
            string valorRaiz;
            NArbolSatis t = aSatis;

            if (aSatis == null)
            {
                Console.WriteLine(" El árbol está vacío... ");
            }
            else
            {
                Console.Write(" ¿De qué colaborador desea ver las opiniones de los usuarios?\n\n < ");
                string colabBuscado = Console.ReadLine();
                while (t != null)
                {
                    valorRaiz = t.colaborador;
                    if (colabBuscado.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("\tColaborador encontrado");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Colaborador: " + t.colaborador);
                        Console.WriteLine("Usuario: " + t.usuario);
                        Console.WriteLine("Satisfacción: " + t.satisfaccion);
                        Console.WriteLine("Inerfaz: " + t.interfaz);
                        Console.WriteLine("Personal: " + t.personal);
                        Console.WriteLine("Comentario: " + t.comentario);
                        Console.WriteLine("-----------------------------------");
                    }
                    if (colabBuscado.CompareTo(valorRaiz) == -1)
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
        public void mostrarArbol(NArbolSatis arbSatis, int cont)
        {
            if (arbSatis == null)
            {
                return;
            }
            else
            {
                mostrarArbol(arbSatis.der, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(arbSatis.colaborador);
                mostrarArbol(arbSatis.izq, cont + 1);
            }
        }
        public void MostrarArbolEnOrden(NArbolSatis arbSatis)
        {
            if (arbSatis == null)
            {
                return;
            }
            else
            {
                MostrarArbolEnOrden(arbSatis.izq);

                Console.WriteLine(arbSatis.usuario + " |" + arbSatis.satisfaccion + "|  " + arbSatis.interfaz + " | " + arbSatis.personal + " | " + arbSatis.comentario + " |");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");

                MostrarArbolEnOrden(arbSatis.der);
            }
        }
        public void DePilaaArbol(PilaSatis PilaS, ArbolSatis arbol)
        {
            while (PilaS.pilaS != null)
            {
                Satisfaccion p = PilaS.Pop();
                arbol.insertarSatis(p.satisfaccion, p.interfaz, p.personal, p.comentario, p.colaborador, PilaS);
            }
        }
    }
}
