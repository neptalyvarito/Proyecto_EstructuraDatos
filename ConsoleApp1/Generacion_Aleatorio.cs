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
        public static int chaparNombre, chaparApellido, chaparTelefono, chaparDni, chaparParaContra, chaparTicket;
        public static string contrasena, Nombre, Apellido;

        public static string[] nombres = {  "Diego", "Andre", "Frachesco", "Cesár", "Mauricio", "Raul", "Christian", "Eduardo", "Omar", "Juan", "Elias", "Alexi", "Alexander",
                                            "Carlos", "Alvaro", "Renato", "Jesús", "Moises", "Joaquin", "Gabriel", "Jose", "Alberto", "Steven", "Raúl", "Tomas", "Josue", "Bryan",
                                            "Alejandro", "Dyer", "Alonso"}; //arreglo de 30 nombres

        public static string[] apellidos ={ "Diaz", "Chavez", "Cahuas", "Mayo", "Abril", "Morales", "Silvera", "Figueredo", "Ayala", "Tapia", "Reyes", "Santos", "De la Vega", "Lopez",
                                            "Hilario", "Ramos", "Casas", "Torres", "Fernandez", "Garcia", "Ore", "Marquezano", "Crispin", "Estrada", "Chuqui","Solis", "Molina", "Acuña",
                                            "Fujimori", "Mandujano", "Ramirez", "Chipana", "Mercado", "Apaza", "Cifuentes", "Alor", "Ajalcriña", "", "Alimaña", "Navaja"}; //arreglo de 40 nombres

        public static string[] caracterescontraseña = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y","z", 
                                                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}; //36 caracteres

        public static string[] Tickesito = { "Falla de computadora en Laboratarios de Computo", "Falla de internet dentro del campus de la universidad", 
                                             "Falla en comunicaciones entre redes institucionales", "Página web de la institución falla"};//4 tipos generales de problemas
        public void GenerarUsuariosAdmisYTrabajadoresAleatorios(Lista_Usuarios Lu, Lista_Administrativos La, Lista_Trabajadores LTra)
        {
            bool flag, flag2 , flag3;

            for (int k = 0; k < 3; k++)
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

                    } while (flag != false && flag2 != false && flag3 != false);
                    do
                    {

                        chaparTelefono = Nro.Next(900000000, 999999999);
                        flag = Lu.SaberSiExisteNumCelularUsuario(chaparTelefono);
                        flag2 = La.SaberSiExisteNumCelularAdmin(chaparTelefono);
                        flag3 = LTra.SaberSiExisteNumCelularTrabajador(chaparTelefono);

                    } while (flag != false && flag2 != false && flag3 != false);
                    do
                    {
                       
                        for (int i = 0; i < 6; i++)
                        {
                            chaparParaContra = Nro.Next(0, 25);
                            contrasena += caracterescontraseña[chaparParaContra];
                        }
                        flag = Lu.SaberSiExisteContraUser(contrasena);
                        flag2 = La.SaberSiExisteContraAdmin(contrasena);
                        flag3 = LTra.SaberSiExisteContraTrabajador(contrasena);
                    
                    } while (flag != false && flag2 != false && flag3 != false);

                    if (k == 0) Lu.RegistrarUsuarios(Nombre, Apellido, chaparDni, chaparTelefono, contrasena);
                    else if (k == 1) La.AgregarAdmin(Nombre, Apellido, chaparTelefono, chaparDni, contrasena);
                    else if (k == 2) LTra.RegistrarTrabajador(Nombre, Apellido, chaparDni, chaparTelefono, contrasena);
                }
            }
           
        }
        public void GenerarTickets(Lista_Tickets Ltick, Lista_Usuarios Lu)
        {
            for (int i = 0; i < 30; i++)
            {
                int detener = Nro.Next(0, 19);
                int codigo = 0;
                string nombre = "";

                codigo = Lu.ObtenerCodigoAleatorioUser(detener);
                nombre = Lu.ObtenerNombreCompletoUser(codigo);

                chaparTicket = Nro.Next(0, 4);

                Ltick.AgregarTicket(nombre, Tickesito[chaparTicket], codigo);
            }
            
        }
    }
}
