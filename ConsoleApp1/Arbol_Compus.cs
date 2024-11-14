using System;
using System.Collections.Generic;
using System.Configuration;
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
     
        public void MostrarArbolitoPorSalon(Computadoras arb, string salon)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                MostrarArbolitoPorSalon(arb.izquierda, salon);
                if (salon.ToUpper() == arb.salon.ToUpper())
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Computadora encontrada");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Código del computador : " + arb.codigoCompu);
                    Console.WriteLine("Edificio              : " + arb.edificio);
                    Console.WriteLine("Piso                  : " + arb.piso);
                    Console.WriteLine("Salon                 : " + arb.salon);
                    Console.WriteLine("Marca                 : " + arb.marca);
                    Console.WriteLine("Sistema Operativo     : " + arb.sistemaOperativo);
                    Console.WriteLine("Almacenamiento        : " + arb.almacenamiento);
                    Console.WriteLine("Ram                   : " + arb.ram);
                    Console.WriteLine("Tarjeta madres        : " + arb.tarjetaMadre);
                }
                MostrarArbolitoPorSalon(arb.derecha, salon);
            }
        }
        public void MostrarArbolitoPorMarca(Computadoras arb, string marca)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                MostrarArbolitoPorMarca(arb.izquierda, marca);
                if (marca.ToUpper() == arb.marca.ToUpper())
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Computadora encontrada");
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Código del computador : " + arb.codigoCompu);
                    Console.WriteLine("Edificio              : " + arb.edificio);
                    Console.WriteLine("Piso                  : " + arb.piso);
                    Console.WriteLine("Salon                 : " + arb.salon);
                    Console.WriteLine("Marca                 : " + arb.marca);
                    Console.WriteLine("Sistema Operativo     : " + arb.sistemaOperativo);
                    Console.WriteLine("Almacenamiento        : " + arb.almacenamiento);
                    Console.WriteLine("Ram                   : " + arb.ram);
                    Console.WriteLine("Tarjeta madres        : " + arb.tarjetaMadre);
                }
                MostrarArbolitoPorMarca(arb.derecha, marca);
            }
        }

        public void mostrarArbolitoVertical(Computadoras arb, int cont)
        {
            if (arb == null)
            {
                return;
            }

           
            mostrarArbolitoVertical(arb.derecha, cont + 1);

           
            for (int i = 0; i < cont; i++)
            {
                Console.Write("   ");
            }

            
            Console.WriteLine(" " + arb.codigoCompu + " (" + arb.marca + ")");

           
            if (arb.izquierda != null || arb.derecha != null) 
            {
                if (arb.izquierda != null)
                {
                    mostrarArbolitoVertical(arb.izquierda, cont + 1);
                }
                else
                {
                    for (int i = 0; i < cont + 1; i++)
                    {
                        Console.Write("   ");
                    }
                   // Console.WriteLine("|-- (nulo)"); // Nodo nulo
                }

                if (arb.derecha != null)
                {
                    mostrarArbolitoVertical(arb.derecha, cont + 1);
                }
                else
                {
                  
                    for (int i = 0; i < cont + 1; i++)
                    {
                        Console.Write("   ");
                    }
                  //  Console.WriteLine("|-- (nulo)"); // Nodo nulo
                }
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
        public void buscarPorSalon(Computadoras arb, string salon, ref int piso, ref string edificio, ref string codigoCompu)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                buscarPorSalon(arb.izquierda, salon, ref piso, ref edificio, ref codigoCompu);
                if (salon.ToUpper() == arb.salon.ToUpper())
                {
                    piso = arb.piso;
                    edificio = arb.edificio;
                    codigoCompu = arb.codigoCompu;
                }
                buscarPorSalon(arb.derecha, salon, ref piso, ref edificio, ref codigoCompu);
            }
        }
    }
}
