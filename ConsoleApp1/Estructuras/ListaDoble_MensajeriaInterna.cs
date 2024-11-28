using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaDoble_MensajeriaInterna
    {
        public Mensajes delante;
        public Mensajes atras;

        public int codigoMensaje = 100001;
        public ListaDoble_MensajeriaInterna()
        {
            delante = null;
            atras = null;
        }

        public void CrearNuevoMensaje(string mensaje, string nombreEmisor, string nombrereceptor, int codigoDueño, int codigoReceptor)
        {
            string respuesta = null;
            DateTime fechaMensaje = DateTime.Now;
            string fechaRespuesta = " ";
            Mensajes q = new Mensajes(mensaje, respuesta, nombreEmisor, nombrereceptor, fechaMensaje, fechaRespuesta, codigoDueño, codigoReceptor, codigoMensaje);

            if (delante == null)
            {
                delante = q;
            }
            else
            {
                atras.sgte = q;
                q.ant = atras;
            }
            atras = q;
            codigoMensaje++;
        }
        public void MostrarMensajesEnviados(int codigoEmisor)
        {
            Mensajes t = delante;
            while(t != null)
            {
                if(codigoEmisor == t.codigoDueño)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje del " + t.fechaMensaje);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Emisor         : " + t.emisor);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje        : " + t.mensaje);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Receptor       : " + t.receptor);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Fecha respuesta: " + t.fechaRespuesta);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Respuesta      : " + t.respuesta);
                    Console.WriteLine("");

                }
                t = t.sgte;
            }
        }
        public void MostrarMensajesRecibido(int codigoreceptor)
        {
            Mensajes t = delante;
            while (t != null)
            {
                if (codigoreceptor == t.codigoReceptor)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje del " + t.fechaMensaje);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------");
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Emisor         : " + t.emisor);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje        : " + t.mensaje);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Receptor       : " + t.receptor);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Fecha respuesta: " + t.fechaRespuesta);
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Respuesta      : " + t.respuesta);
                }
                t = t.sgte;
            }
        }
        public void ResponderMensaje(int codigoreceptor)
        {
            Mensajes t = delante;
            Mensajes q = delante;
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t| Código Mensaje ".PadRight(10, ' ') + " | Emisor ".PadRight(40, ' ') + " | Mensaje ");
            while (t != null)
            {
                if (codigoreceptor == t.codigoReceptor)
                {
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t|"+ t.codigoMensaje.ToString().PadRight(20, ' ') + " | " + t.emisor.PadRight(35, ' ') + " | " + t.mensaje);
                }
                t = t.sgte;
            }
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t------------------------------------------------------------------");
            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  >  Escriba el código del mensaje que desea responder: ");
            int codigo = int.Parse(Console.ReadLine());
            bool flag = SaberSiExisteMensaje(codigo);
            if(flag)
            {
                while (t != null)
                {
                    if (codigo == t.codigoMensaje)
                    {
                        Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje del " + t.fechaMensaje);
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t---------------------------------------");
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Emisor         : " + t.emisor);
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Mensaje        : " + t.mensaje);
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Receptor       : " + t.receptor);
                        break;
                    }
                    t = t.sgte;
                }
                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Respuesta al mensaje: ");
                string rpta = Console.ReadLine();
                DateTime fechaRpt = DateTime.Now;
                while (q != null)
                {
                    if (q.codigoMensaje == codigo)
                    {
                        q.respuesta = rpta;
                        q.fechaRespuesta = fechaRpt.ToString();
                        Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t Respuesta enviada!");
                        Console.ReadLine();
                        break;
                    }
                    q = q.sgte;
                }
            }
        }
        public bool SaberSiExisteMensaje(int codigo)
        {
            Mensajes t = delante;
            bool flag = false;
            while(t != null)
            {
                if (t.codigoMensaje == codigo)
                {
                    flag = true;
                    break;
                }
                t = t.sgte;
            }

            return flag;
        }
    }
}
