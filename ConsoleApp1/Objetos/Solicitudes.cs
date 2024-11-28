using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Solicitudes
    {
        public int codigoSolicitud;
        public int codigoDueno;
        public string solicitante;
        public string tipoSolicitud;
        public string destinatario;
        public string condicion;
        public string mensajeParaUsuario;
        public DateTime fechaCreacion;
        public Solicitudes sgte;

        public Solicitudes(int codigoSolicitud, int codigoDueno, string solicitante, string tipoSolicitud, string destinatario, string condicion, string mensajeParaUsuario)
        {
            this.codigoSolicitud = codigoSolicitud;
            this.codigoDueno = codigoDueno;
            this.solicitante = solicitante;
            this.tipoSolicitud = tipoSolicitud;
            this.destinatario = destinatario;
            this.condicion = condicion;
            this.mensajeParaUsuario = mensajeParaUsuario;
            fechaCreacion = DateTime.Now;
            this.sgte = null;
      
        }
    }
}
