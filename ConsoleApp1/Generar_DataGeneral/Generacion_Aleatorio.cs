using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Generacion_Aleatorio
    {   
        public static Random Nro = new Random();
        public static int chaparNombre, chaparApellido, chaparTelefono, chaparDni, chaparParaContra, chaparTicket, chaparCategoriaTicket, piso;
        public static string contrasena, Nombre, Apellido, codigoCompu, marca, sistemaOperativo, salon, edificio, tarjetaMadre;
        public static double ram, almacenamiento;

        //arreglo de 30 nombres
        public static string[] nombres = {  "Diego", "Andre", "Frachesco", "Cesár", "Mauricio", "Raul", "Christian", "Eduardo", 
                                            "Omar", "Juan", "Elias", "Alexi", "Alexander", "Carlos", "Alvaro", "Renato", "Jesús", 
                                            "Moises", "Joaquin", "Gabriel", "Jose", "Alberto", "Steven", "Raúl", "Tomas", "Josue", 
                                            "Bryan", "Alejandro", "Dyer", "Alonso"}; 

        //40
        public static string[] apellidos ={ "Diaz", "Chavez", "Cahuas", "Mayo", "Abril", "Morales", "Silvera", "Figueredo", "Ayala",
                                            "Tapia", "Reyes", "Santos", "De la Vega", "Lopez", "Hilario", "Ramos", "Casas", "Torres", 
                                            "Fernandez", "Garcia", "Ore", "Marquezano", "Crispin", "Estrada", "Chuqui", "Solis", "Molina", 
                                            "Acuña", "Fujimori", "Mandujano", "Ramirez", "Chipana", "Mercado", "Apaza", "Cifuentes", "Alor", 
                                            "Ajalcriña", "Lovera", "Alimaña", "Navaja"};

        //arreglo de 66 nombres
        public static string[] caracterescontraseña = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                                        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y","Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", 
                                                        "r", "s", "t", "u", "v", "w", "x", "y","z", "1", "2", "3", "4", "5", "6", "7", "8",
                                                        "9","0"};

        //4 tipos generales de problemas
        public static string[] TickesitoDescripcion = { "Falla de computadora en Laboratarios de Computo", "Falla de internet dentro del campus de la universidad", 
                                                        "Falla en comunicaciones entre redes institucionales", "Página web de la institución falla"};

        //8 tipos de categoria
        public static string[] TicketsitoCategoria = { "VPN: Conexion, error en VPN", "Equipos de computo y accesorios", "Redes: Falla de conexión, lentitud, etc", 
                                                       "Software: Teams, Windows, Office, etc", "Wifi: falla de conexión, etc", "Internet: caida del servicio",
                                                       "Correo: No envia ni recibe correo", "Antivirus:AMP, Umbrella"};

        //3 tipos de solicitudes
        public static string[] Solicitudes = { "Prestamo de laptop", "Prestamo de pc", "Servicios especificos de TI "};

        //4 tipos de sugerencias
        public static string[] Sugerencias = { "Mejorar interfaz grafica del programa", "Hacer más rondas de chequeo a Pcs", "Agregar más opciones en el programa", 
                                               "Mejorar atención al cliente"};

        public static string[] Salones = { "LCOM1", "LCOM2", "LCOM3", "LCOM4", "LCOM5", "LAB_ELEC", "TALL_ROBOTICA", "CONF1", "CONF2"};

        public static string[] MarcaCompus = { "Toshiba", "HP", "Lenovo"};

        public static double[] Rams = { 4, 8, 16, 32 };

        public static double[] Almacenamiento = { 250, 500, 1024}; 

        public static string[] SistemaOperativo = {"Windows", "Linux", "Apple"};

        public static string[] TarjetasMadres = {"Nvidia", "Amx", "NoseManoxD" };

        public void GenerarUsuariosAdmisYTrabajadoresAleatorios(Lista_Alumnos Lu, Lista_Administrativos La, Lista_Trabajadores LTra, Lista_Profes Lp)
        {
            bool flag, flag2 , flag3, flag4;

            for (int k = 0; k < 4; k++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Nombre = "";
                    Apellido = "";
                    contrasena = "";
                    for (int o =0; o<2; o++)
                    {
                        chaparNombre = Nro.Next(0, 29);
                        chaparApellido = Nro.Next(0, 39);
                        Nombre += nombres[chaparNombre] + " ";
                        Apellido += apellidos[chaparApellido] + " ";
                    }
                    do
                    {
                        chaparDni = Nro.Next(10000000, 99999999);

                        flag = Lu.SaberSiExisteUsuarioConDni(chaparDni);
                        flag2 = La.SaberSiExisteAdminConDni(chaparDni);
                        flag3 = LTra.SaberSiExisteTrabajadorConDni(chaparDni);
                        flag4 = Lp.SaberSiExisteProfeConDni(chaparDni);

                    } while (flag != false && flag2 != false && flag3 != false && flag4 != false);
                    do
                    {

                        chaparTelefono = Nro.Next(900000000, 999999999);
                        flag = Lu.SaberSiExisteNumCelularUsuario(chaparTelefono);
                        flag2 = La.SaberSiExisteNumCelularAdmin(chaparTelefono);
                        flag3 = LTra.SaberSiExisteNumCelularTrabajador(chaparTelefono);
                        flag4 = Lp.SaberSiExisteNumCelularProfe(chaparTelefono);

                    } while (flag != false && flag2 != false && flag3 != false && flag4 != false);
                    do
                    {
                       
                        for (int i = 0; i < 6; i++)
                        {
                            chaparParaContra = Nro.Next(0, 36);
                            contrasena += caracterescontraseña[chaparParaContra];
                        }
                        flag = Lu.SaberSiExisteContraUser(contrasena);
                        flag2 = La.SaberSiExisteContraAdmin(contrasena);
                        flag3 = LTra.SaberSiExisteContraTrabajador(contrasena);
                        flag4 = Lp.SaberSiExisteContraProfe(contrasena);
                    
                    } while (flag != false && flag2 != false && flag3 != false && flag4 != false);

                    if (k == 0) Lu.RegistrarUsuarios(Nombre, Apellido, chaparDni, chaparTelefono, contrasena);
                    else if (k == 1) La.AgregarAdmin(Nombre, Apellido, chaparTelefono, chaparDni, contrasena);
                    else if (k == 2) LTra.RegistrarTrabajador(Nombre, Apellido, chaparDni, chaparTelefono, contrasena);
                    else if (k == 3) Lp.RegistrarProfe(Nombre, Apellido, chaparDni, chaparTelefono, contrasena);
                }
            }
           
        }
        public void GenerarTickets(Lista_Tickets Ltick, Lista_Alumnos Lu, ColaPrio_Ticket colaPrio, Lista_Trabajadores LTra, Lista_Administrativos La, Lista_Profes Lp)
        {
            for (int i = 0; i < 30; i++)
            {
                int detener = Nro.Next(0, Lu.CantidadDeUsuarios());
                int codigo = 0;
                string nombre = "";
                string cate = "";
              
                chaparTicket = Nro.Next(0, 4);
                chaparCategoriaTicket = Nro.Next(0, 8);

                int a = Nro.Next(1, 5);

                if (a == 1)
                {
                    cate = "Alumno";
                    codigo = Lu.ObtenerCodigoAleatorioUser(detener);
                    nombre = Lu.ObtenerNombreCompletoUser(codigo);
                }
                else if (a == 2)
                {
                    cate = "Trabajador";
                    codigo = LTra.ObtenerCodigoAleatorioTrabajador(detener);
                    nombre = LTra.ObtenerNombreTrabajadoresConCodigo(codigo);
                }
                else if (a == 3)
                {
                    cate = "Profesor";
                    codigo = Lp.ObtenerCodigoAleatorioProfe(detener);
                    nombre = Lp.ObtenerNombreCompletoProfe(codigo);
                }
                else if (a == 4)
                {
                    cate = "Administrativo";
                    codigo = La.ObtenerCodigoAleatorioAdmin(detener);
                    nombre = La.ObtenerNombreCompletoAdmin(codigo);
                }
                colaPrio.AgregarTicketPrioridad(nombre, TickesitoDescripcion[chaparTicket], codigo, TicketsitoCategoria[chaparCategoriaTicket],a, cate );
            }
            
        }
        public void GeneraCompus(Arbol_Compus arbolito)
        {
            //string codigoCompu, double ram, double almacenamiento, string marca, string sistemaOperativo, string salon, int piso, string edificio, string tarjetaMadre
            int chaparAl;
            for(int i = 0; i <50; i++)
            {
                codigoCompu = "";
                for (int j = 0;j  < 6; j++)
                {
                    chaparAl = Nro.Next(0, 36);
                    codigoCompu += caracterescontraseña[chaparAl];
                }

                ram = Rams[Nro.Next(0,4)];
                almacenamiento = Almacenamiento[Nro.Next(0, 3)];
                marca = MarcaCompus[Nro.Next(0, 3)];
                sistemaOperativo = SistemaOperativo[Nro.Next(0, 3)];
                salon = Salones[Nro.Next(0, 9)];
                piso = Nro.Next(1, 6);
                edificio = caracterescontraseña[Nro.Next(0, 5)];
                tarjetaMadre = TarjetasMadres[Nro.Next(0, 3)];

                arbolito.AgregarCompu(codigoCompu, ram, almacenamiento, marca, sistemaOperativo, salon, piso, edificio, tarjetaMadre);
            }
        }
    }
}
