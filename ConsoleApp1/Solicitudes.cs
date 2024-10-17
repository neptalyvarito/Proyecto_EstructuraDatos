using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Solicitudes
    {
        private int codigoSolicitud;
        private string solicitante;
        private string tipoSolicitud;
        private string destinatario; // se busca entre todos los dnis
        private string condicion;
        private Solicitudes sgte;
        private Solicitudes delante;
        private Solicitudes atras;

        public int CodigoSolicitud
        {
            get { return codigoSolicitud; }
            set { codigoSolicitud = value; }

        }
        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }
        public string TipoSolicitud
        {
            get { return tipoSolicitud; }
            set { tipoSolicitud = value; }
        }
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        public string Condicion
        {
            get { return condicion; }
            set { condicion = value; }
        }
        public Solicitudes Sgte
        {
            get { return sgte; }
            set { sgte = value; }
        }

        public Solicitudes Delante
        { 
            get { return delante; }
            set { delante = value; } 
        }

        public Solicitudes Atras
        {
            get { return atras; }
            set { atras = value; }
        }

      
    }
}
