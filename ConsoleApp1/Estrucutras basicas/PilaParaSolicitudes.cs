using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PilaParaSolicitudes
    {
        public Solicitudes pilaSolic;

        public PilaParaSolicitudes()
        {
            pilaSolic = null;
        }

        public void AgregarSug(Solicitudes q)
        {
        
            if (pilaSolic == null)
            {
                pilaSolic = q;
            }
            else
            {
                q.sgte = pilaSolic;
                pilaSolic = q;
            }
        }
        public void MostrarSugerencia()
        {
            Solicitudes p = pilaSolic;

            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                Console.WriteLine(" " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                p = p.sgte;
            }
        }
        public void MostrarSugerenciaAceptadas()
        {
            Solicitudes p = pilaSolic;

            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                if (p.condicion == "Aprobada")
                {
                    Console.WriteLine(" " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                }
                 p = p.sgte;
            }
        }
        public void MostrarSugerenciaRechazadas()
        {
            Solicitudes p = pilaSolic;

            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                if (p.condicion == "Rechazada")
                {
                    Console.WriteLine(" " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                }
                p = p.sgte;
            }
        }
        public void MostrarSugerenciaPorUser(int codigoDueno)
        {
            Solicitudes p = pilaSolic;

            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                if (p.codigoDueno == codigoDueno)
                {
                    Console.WriteLine(" " + p.codigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.solicitante.PadRight(25, ' ') + "| " + p.codigoDueno.ToString().PadRight(25, ' ') + " | " + p.tipoSolicitud.PadRight(45, ' ') + " | " + p.destinatario.PadRight(40, ' ') + " | " + p.condicion.PadRight(25, ' ') + " | " + p.mensajeParaUsuario.PadRight(26, ' '));
                }
                p = p.sgte;
            }
        }

    }
}
