using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cola_Solicitudes
    {
        public static int codigo = 222400001;
        public void Inicio(ref Solicitudes q)
        {
            q.Delante = null; 
            q.Atras = null; 
        }
        
        public void AgregarSolicitud(ref Solicitudes q, string solicitante, string tipoSolicitud, string destinatario, int codigoDueño)
        {
            Solicitudes p; 
            p = new Solicitudes();
            p.Solicitante = solicitante;
            p.CodigoDueno = codigoDueño;
            p.TipoSolicitud = tipoSolicitud;
            p.Destinatario = destinatario;
            p.Condicion = "En espera";
            p.CodigoSolicitud = codigo;
            p.MensajeParaUsuario = " ";
            p.Sgte = null;
            
            if (q.Delante == null)
                q.Delante = p; 
            else
            {
                (q.Atras).Sgte = p; 
            }
            q.Atras = p;
            codigo++;
        }

        public Solicitudes  EliminarSolicitud(ref Solicitudes q)
        {
            Solicitudes p; 
            p = q.Delante;
            Solicitudes retornar = p;
            q.Delante = (q.Delante).Sgte;
            
            p = null;


           return retornar;
        }
        public void EliminarTodasSolicitudes(ref Solicitudes q)
        {
            Solicitudes p, r;
            p = q.Delante; 
            while (p != null)
            {
                r = p; 
                p = p.Sgte;
                r = null; 
            }
            q.Delante = null; 
            q.Atras = null; 
        }
        
        public void MostrarSolicitudes(Solicitudes q)
        {
            Solicitudes p; 
            
            p = q.Delante;
            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                Console.WriteLine(" " + p.CodigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.Solicitante.PadRight(25, ' ') + "| " + p.CodigoDueno.ToString().PadRight(25, ' ') + " | " + p.TipoSolicitud.PadRight(45, ' ') + " | " + p.Destinatario.PadRight(40, ' ') + " | " + p.Condicion.PadRight(25, ' ') + " | " + p.MensajeParaUsuario.PadRight(26, ' '));
                p = p.Sgte; 
            }
            
        }
        public void MostrarPilaDeSolEnEspera(Solicitudes q, string condicion)
        {
            Solicitudes p;
            p = q.Delante;
            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                if(p.Condicion == "En espera")
                {
                    Console.WriteLine(" " + p.CodigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.Solicitante.PadRight(25, ' ') + "| " + p.CodigoDueno.ToString().PadRight(25, ' ') + " | " + p.TipoSolicitud.PadRight(45, ' ') + " | " + p.Destinatario.PadRight(40, ' ') + " | " + p.Condicion.PadRight(25, ' ') + " | " + p.MensajeParaUsuario.PadRight(26, ' '));
                }
                p = p.Sgte;
            }
        }
        public void MostrarPilaDeSolAprobar(Solicitudes q, string condicion)
        {
            Solicitudes p;
            p = q.Delante;
            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') + " | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            while (p != null)
            {
                if (p.Condicion == "Aprobada")
                {
                    Console.WriteLine(" " + p.CodigoSolicitud.ToString().PadRight(14, ' ') + "|  " + p.Solicitante.PadRight(25, ' ') + "| " + p.CodigoDueno.ToString().PadRight(25, ' ') + " | " + p.TipoSolicitud.PadRight(45, ' ') + " | " + p.Destinatario.PadRight(40, ' ') + " | " + p.Condicion.PadRight(25, ' ') + " | " + p.MensajeParaUsuario.PadRight(26, ' '));
                }
                p = p.Sgte;
            }
        }
        public void MostrarSolicitudesPorUsuario(Solicitudes q, int codigoDueno)
        {
            Solicitudes p;
            p = q.Delante;
            Console.WriteLine(" ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Código ".PadRight(14, ' ') + " | Solicitante".PadRight(28, ' ') +" | Código Solicitante".PadRight(28, ' ') + " | Tipo Solicitud".PadRight(45, ' ') + "    | Destinatario".PadRight(40, ' ') + "       | Condicion".PadRight(28, ' ') + "       | Mensaje".PadRight(28, ' '));
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            while (p != null)
            {
                if (p.CodigoDueno == codigoDueno)
                {
                    Console.WriteLine(" " + p.CodigoSolicitud.ToString().PadRight(14, ' ') + "|  "+ p.Solicitante.PadRight(25, ' ') + "| " +p.CodigoDueno.ToString().PadRight(25, ' ') + " | " + p.TipoSolicitud.PadRight(45, ' ') + " | " + p.Destinatario.PadRight(40, ' ') + " | " + p.Condicion.PadRight(25, ' ') + " | " + p.MensajeParaUsuario.PadRight(26, ' '));
                }
                p = p.Sgte;
            }
        }
        public void AprobarODenegarSoli(ref Solicitudes q, string condicion, string mensaje)
        {
            
        }
        public void ObtenerPrimerNodoColaEnEspera(ref Solicitudes q)
        {
            Solicitudes p;
            p = q.Delante;
            while (p != null)
            {
                p = p.Sgte;
            }
        }
    }
}
