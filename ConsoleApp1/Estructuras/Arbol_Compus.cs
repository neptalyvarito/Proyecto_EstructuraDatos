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
      

            if (arbolito == null)
            {
                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\tLista de computadoras vacia... ");
                Console.ReadLine();
            }
            else
            {
                while (t != null)
                {
                    valorRaiz = t.codigoCompu;
                    if (codigoCom.CompareTo(valorRaiz) == 0)
                    {
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tComputadora encontrada");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tCódigo del computador : " + t.codigoCompu);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEdificio              : " + t.edificio);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tPiso                  : " + t.piso);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSalon                 : " + t.salon);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEspecificaciones: ");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t-------------------------");
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tMarca                 : " + t.marca);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSistema Operativo     : " + t.sistemaOperativo);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tAlmacenamiento        : " + t.almacenamiento);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tRam                   : " + t.ram);
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tTarjeta madres        : " + t.tarjetaMadre);
                        
                        
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
                            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  >  Computadora no encontrada");
                            Console.ReadLine();
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
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tComputadora encontrada");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tCódigo del computador : " + arb.codigoCompu);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEdificio              : " + arb.edificio);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tPiso                  : " + arb.piso);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSalon                 : " + arb.salon);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tMarca                 : " + arb.marca);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSistema Operativo     : " + arb.sistemaOperativo);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tAlmacenamiento        : " + arb.almacenamiento);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tRam                   : " + arb.ram);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tTarjeta madres        : " + arb.tarjetaMadre);
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
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tComputadora encontrada");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tCódigo del computador : " + arb.codigoCompu);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tEdificio              : " + arb.edificio);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tPiso                  : " + arb.piso);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSalon                 : " + arb.salon);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tMarca                 : " + arb.marca);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tSistema Operativo     : " + arb.sistemaOperativo);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tAlmacenamiento        : " + arb.almacenamiento);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tRam                   : " + arb.ram);
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\tTarjeta madres        : " + arb.tarjetaMadre);
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
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| "+arb.codigoCompu +  " | " + arb.edificio + "     | " +arb.piso +"    | "  + arb.salon);
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t----------------------------------------------------------------------------");
                MostrarArbolitoEnOrden(arb.derecha );
            }
        }
        public bool SaberSiExisteSalon(Computadoras arb, string codigo)
        {
            bool flag = false;
            if (arb == null)
            {
                return flag;
            }
            else
            {
                SaberSiExisteSalon(arb.izquierda, codigo);
                if (codigo == arb.salon) flag = true;
                SaberSiExisteSalon(arb.derecha, codigo);
                return flag;
            }
        }
        public bool SaberSiExisteCompu(Computadoras arb, string codigo)
        {
            bool flag = false;
            if (arb == null)
            {
                return flag ;
            }
            else
            {
                SaberSiExisteCompu(arb.izquierda, codigo);
                if(codigo == arb.codigoCompu) flag = true;
                SaberSiExisteCompu(arb.derecha, codigo);
                return flag;
            }
        }
        public void ModificarDatosCompu(string modificable1, double modificable2, int modificable3, string codigo, int opc, Computadoras arb)
        {
            if (arb == null)
            {
                return;
            }
            else
            {
                ModificarDatosCompu(modificable1, modificable2, modificable3, codigo, opc, arb.izquierda);
                if (codigo == arb.codigoCompu)
                {
                    if (opc == 1) arb.salon = modificable1;
                    else if (opc == 2) arb.piso = modificable3;
                    else if (opc == 3) arb.edificio = modificable1;
                    else if (opc == 4) arb.sistemaOperativo = modificable1;
                    else if (opc == 5) arb.ram = modificable2;
                    else if (opc == 6) arb.almacenamiento = modificable2;
                    else if (opc == 7) arb.marca = modificable1;
                }
                ModificarDatosCompu(modificable1, modificable2, modificable3, codigo, opc, arb.derecha);
             
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
