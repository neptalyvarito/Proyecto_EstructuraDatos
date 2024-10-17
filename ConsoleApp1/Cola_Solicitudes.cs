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
        
        public void AgregarSolicitud(ref Solicitudes q, string solicitante, string tipoSolicitud, string destinatario)
        {
            Solicitudes p; 
            p = new Solicitudes();
            p.Solicitante = solicitante;
            p.TipoSolicitud = tipoSolicitud;
            p.Destinatario = destinatario;
            p.Condicion = "Sin aproboar";
            p.CodigoSolicitud = codigo;

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

        public void EliminarSolicitud(ref Solicitudes q)
        {
            Solicitudes p; 
            p = q.Delante; 
            
            
            q.Delante = (q.Delante).Sgte;
            
            p = null;
           
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
            Console.WriteLine(" Código ".PadRight(20,' ')+" | Solicitante".PadRight(25,' ') + " | Tipo Solicitud".PadRight(25, ' ') + " | Destinatario".PadRight(25,' ') + " | Condicion".PadRight(25, ' '));
            while (p != null)
            {
                Console.Write(" " + q.CodigoSolicitud.ToString().PadRight(20, ' ') +q.Solicitante.PadRight(25,' ') + " | " +q.TipoSolicitud.PadRight(25,' ') + " | " +q.Destinatario.PadRight(25,' ') + q.Condicion.PadRight(25,' '));
                p = p.Sgte; 
            }
            
        }
        public void AprobarODesaprobarSolicitud(Solicitudes q, string condicion)
        {
            Solicitudes p, r;
            p = q.Delante;
            while (p != null)
            {
                
            }
            
        }

    }
}
