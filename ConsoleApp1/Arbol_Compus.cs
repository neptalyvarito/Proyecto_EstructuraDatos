using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Arbol_Compus
    {
        public Computadoras arbolito;

        public Arbol_Compus()
        {
            arbolito = null;
        }
        public void AgregarCompu(string codigoCompu, double ram, double almacenamiento, string marca, string sistemaOperativo, string salon, int piso, string edificio, string tarjetaMadre)
        {
            string valorRaiz;
            Computadoras q = new Computadoras(codigoCompu, ram, almacenamiento, marca.ToUpper(), sistemaOperativo.ToUpper(), salon, piso, edificio, tarjetaMadre.ToUpper());
            Computadoras t = arbolito;

            if (arbolito == null)
            {
                arbolito = q;
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.codigoCompu;
                    if (codigoCompu.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izquierda != null)
                        {
                            t = t.izquierda;
                        }
                        else
                        {
                            t.izquierda = q;
                            return;
                        }
                    }
                    else
                    {
                        if (t.derecha != null)
                        {
                            t = t.derecha;
                        }
                        else
                        {
                            t.derecha = q;
                            return;
                        }
                    }
                }
            }
        }
        public void buscarPorCompuPorCodigo(string codigoCom)
        {
            string valorRaiz;
            Computadoras t = arbolito;
            int nivel = 0;

            if (arbolito == null)
            {
                Console.WriteLine("Lista de computadoras vacia... ");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.codigoCompu;
                    if (codigoCom.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Computadora encontrada");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Código del computador : " + t.codigoCompu);
                        Console.WriteLine("Edificio              : " + t.edificio);
                        Console.WriteLine("Piso                  : " + t.piso);
                        Console.WriteLine("Salon                 : " + t.salon);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Especificaciones: ");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Marca                 : " + t.marca);
                        Console.WriteLine("Sistema Operativo     : " + t.sistemaOperativo);
                        Console.WriteLine("Almacenamiento        : " + t.almacenamiento);
                        Console.WriteLine("Ram                   : " + t.ram);
                        Console.WriteLine("Tarjeta madres        : " + t.tarjetaMadre);
                        
                        
                    }

                    if (codigoCom.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izquierda != null)
                        {
                            t = t.izquierda;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (t.derecha != null)
                        {
                            t = t.derecha;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        public void buscarPorCompuPorSalon(string SalonCom)
        {
            string valorRaiz;
            Computadoras t = arbolito;
            int nivel = 0;

            if (arbolito == null)
            {
                Console.WriteLine("Lista de computadoras vacia... ");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.salon;
                    if (SalonCom.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Computadora encontrada");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Código del computador : " + t.codigoCompu);
                        Console.WriteLine("Edificio              : " + t.edificio);
                        Console.WriteLine("Piso                  : " + t.piso);
                        Console.WriteLine("Salon                 : " + t.salon);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Especificaciones: ");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Marca                 : " + t.marca);
                        Console.WriteLine("Sistema Operativo     : " + t.sistemaOperativo);
                        Console.WriteLine("Almacenamiento        : " + t.almacenamiento);
                        Console.WriteLine("Ram                   : " + t.ram);
                        Console.WriteLine("Tarjeta madres        : " + t.tarjetaMadre);


                    }

                    if (SalonCom.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izquierda != null)
                        {
                            t = t.izquierda;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (t.derecha != null)
                        {
                            t = t.derecha;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        public void buscarPorCompuPorMarca(string MarcaCom)
        {
            string valorRaiz;
            Computadoras t = arbolito;
            int nivel = 0;

            if (arbolito == null)
            {
                Console.WriteLine("Lista de computadoras vacia... ");
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.marca;
                    if (MarcaCom.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Computadora encontrada");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Código del computador : " + t.codigoCompu);
                        Console.WriteLine("Edificio              : " + t.edificio);
                        Console.WriteLine("Piso                  : " + t.piso);
                        Console.WriteLine("Salon                 : " + t.salon);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Especificaciones: ");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Marca                 : " + t.marca);
                        Console.WriteLine("Sistema Operativo     : " + t.sistemaOperativo);
                        Console.WriteLine("Almacenamiento        : " + t.almacenamiento);
                        Console.WriteLine("Ram                   : " + t.ram);
                        Console.WriteLine("Tarjeta madres        : " + t.tarjetaMadre);


                    }

                    if (MarcaCom.CompareTo(valorRaiz) == -1)
                    {
                        if (t.izquierda != null)
                        {
                            t = t.izquierda;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (t.derecha != null)
                        {
                            t = t.derecha;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }
        public void mostrarArbolito(Computadoras arb, int cont)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                mostrarArbolito(arb.derecha, cont + 1);
                for (int i = 0; i < cont; i++)
                {
                    Console.Write("   ");
                }
                Console.WriteLine(arb.codigoCompu);
                mostrarArbolito(arb.izquierda, cont + 1);
            }
        }
        public void MostrarArbolitoEnOrden(Computadoras arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                MostrarArbolitoEnOrden(arb.izquierda);

                Console.WriteLine(arb.codigoCompu +  " |" + arb.edificio + "|  " +arb.piso +" | "  + arb.salon);
                Console.WriteLine("------------------------------------------------------------------------------------------------");

                MostrarArbolitoEnOrden(arb.derecha );
            }
        }

    }
}
