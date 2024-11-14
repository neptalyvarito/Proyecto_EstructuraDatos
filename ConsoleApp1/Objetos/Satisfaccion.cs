using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Objetos
{
    //Clases para el nodo de la pila en el árbol
    //Clase del nodo pila
    internal class Satisfaccion
    {
        public string usuario, satisfaccion, interfaz, personal, comentario, colaborador;
        public Satisfaccion sgte;

        public Satisfaccion(string usuario, string satisfaccion, string interfaz, string personal, string comentario, string colaborador)
        {
            this.colaborador = colaborador;
            this.satisfaccion = satisfaccion;
            this.interfaz = interfaz;
            this.personal = personal;
            this.comentario = comentario;
            this.usuario = usuario;
            this.sgte = null;
        }
    }
    internal class NArbolSatis
    {
        public string satisfaccion, interfaz, personal, comentario, usuario, colaborador;
        public NArbolSatis izq;
        public NArbolSatis der;

        public NArbolSatis(string usuario, string satisfaccion, string interfaz, string personal, string comentario, string colaborador)
        {
            this.colaborador = colaborador;
            this.usuario = usuario;
            this.satisfaccion = satisfaccion;
            this.interfaz = interfaz;
            this.personal = personal;
            this.comentario = comentario;
            this.izq = null;
            this.der = null;
        }
    }
}
