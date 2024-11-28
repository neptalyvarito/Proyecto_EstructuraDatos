using System;

namespace ConsoleApp1.Listas
{
    public class Nodo<T>
    {
        public T Data { get; set; }
        public Nodo<T> Siguiente { get; set; }
        public Nodo<T> Anterior { get; set; }

        public Nodo(T data)
        {
            Data = data;
            Siguiente = null;
            Anterior = null;
        }
    }
}