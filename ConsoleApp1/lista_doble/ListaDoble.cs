using System;

namespace ConsoleApp1.Listas
{
    public class ListaDoble<T>
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
        }

        public void AgregarAlFinal(T data)
        {
            var nuevoNodo = new Nodo<T>(data);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
        }

        public void AgregarAlInicio(T data)
        {
            var nuevoNodo = new Nodo<T>(data);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }
        }

        public void EliminarDelFinal()
        {
            if (cola == null) return;

            if (cola.Anterior == null)
            {
                cabeza = null;
                cola = null;
            }
            else
            {
                cola = cola.Anterior;
                cola.Siguiente = null;
            }
        }

        public void EliminarDelInicio()
        {
            if (cabeza == null) return;

            if (cabeza.Siguiente == null)
            {
                cabeza = null;
                cola = null;
            }
            else
            {
                cabeza = cabeza.Siguiente;
                cabeza.Anterior = null;
            }
        }

        public void Imprimir()
        {
            var actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Data);
                actual = actual.Siguiente;
            }
        }
    }
}
