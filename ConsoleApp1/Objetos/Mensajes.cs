using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Mensajes
    {
        public string mensaje;
        public string respuesta;
        public string emisor;
        public string receptor;
        public int codigoDueño;
        public int codigoReceptor;
        public int codigoMensaje;
        
        public DateTime fechaMensaje;
        public string fechaRespuesta;
        public Mensajes ant;
        public Mensajes sgte;

        public Mensajes(string mensaje, string respuesta, string emisor, string receptor, DateTime fechaMensaje, string fechaRespuesta, int codigoDueño, int codigoReceptor, int codigoMensaje)
        {
            this.mensaje = mensaje;
            this.respuesta = respuesta;
            this.emisor = emisor;
            this.receptor = receptor;
            this.fechaRespuesta = fechaRespuesta;
            this.fechaMensaje = fechaMensaje;
            this.codigoDueño = codigoDueño;
            this.codigoReceptor = codigoReceptor;
            this.codigoMensaje = codigoMensaje;
            ant = null;
            sgte = null;

        }
    }
}
