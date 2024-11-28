using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static Menu_Alumnos menuUsario = new Menu_Alumnos();
        public static Menu_Trabajadores menuTrabajador = new Menu_Trabajadores();
        public static Menu_Admin menuAdministrador = new Menu_Admin();
        public static Menu_Profes menuProfes = new Menu_Profes();

        public static Cola_TicketsResueltos ColaTicketsResueltos = new Cola_TicketsResueltos();
 
        public static ColaPrio_Ticket colitaPrioridad = new ColaPrio_Ticket();
        public static GenerarTicket generarTicketsito = new GenerarTicket();

        public static Lista_Tickets Ltick = new Lista_Tickets();
        public static Lista_Alumnos Lu = new Lista_Alumnos();
        public static Lista_Administrativos La = new Lista_Administrativos();
        public static Lista_Trabajadores LTra = new Lista_Trabajadores();
        public static Lista_Profes Lp = new Lista_Profes();

        public static Papelera_Tickets Papelera = new Papelera_Tickets();
        public static Cola_Solicitudes ColaSol = new Cola_Solicitudes();
        public static Solicitudes q = new Solicitudes();
        public static Pila_Sugerencia PilaSug = new Pila_Sugerencia();
        public static AsignacionTrabajos AsigTra = new AsignacionTrabajos();
        public static Arbol_Compus ArbolitoCompus = new Arbol_Compus();
  

        public static Validaciones validacion = new Validaciones();
        public static Log_in inicioSesion = new Log_in();
        public static Generacion_Aleatorio GAletorio = new Generacion_Aleatorio();

        

        public static Registros registro = new Registros();
        

        public static int dni;
        public static int codigoBusquedaTrabajador, codigoBusquedaAdmin, dniUser = 0, dniTrabajador = 0, dniAdmin =0, dniProfe = 0;

        public static void UserPorDefecto()
        {
            Lu.RegistrarUsuarios("Renato", "Crispin Alvaro", 12345678, 901789730, "hola");
        }
        public static void AdminPorDefecto()
        {
            La.AgregarAdmin("Alvaro Neptaly", "Mayo de la Vega", 901789730, 75433366, "alvaroneptaly");
            La.AgregarAdmin("Sandy Andrea", "Solis Molina", 953261550, 76802211, "sandyandrea");
            La.AgregarAdmin("Elias Alejandro", "Diaz Cahuas", 927073589, 74877780, "eliasalejandro");
        }
        public static void TrabajadorPorDefecto()
        {
            LTra.RegistrarTrabajador("Neiser Omar", "Chavez Chuqui", 70826687, 922240578, "neiseromar");
        }
           
        static void Main(string[] args)
        {
            UserPorDefecto();
            AdminPorDefecto();
            TrabajadorPorDefecto();
            GAletorio.GenerarUsuariosAdmisYTrabajadoresAleatorios(Lu, La, LTra, Lp);
            GAletorio.GenerarTickets(Ltick, Lu, colitaPrioridad, LTra, La, Lp);
            GAletorio.GeneraCompus(ArbolitoCompus);
            Ltick.LlenarLista(colitaPrioridad.colaPrio);

            


            int opc = 0;
           
            do
            {
                Console.Clear(); 
                try
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black; 
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.BackgroundColor = ConsoleColor.Black; //Fondo NEGRO
                    Console.ForegroundColor = ConsoleColor.Red; //Texto RED en negrita
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t\n\t\t\t\t\t\t\t\t\t\t\t...........................................................':ccc:,'....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t...........,cc:,.........................................':lddxxxxxxdc'...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t........';lxO00Oxdo:'...................'ldool,.........':cc:::cclokOOo'...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......;okkdc::cdOKKd'.................,dkoldOk:.......,:c::;''';:clxOOd,...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......ck0x;....'oO0k:.................cOx;..c0O:......:c:;:,....';clxOOo'....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......ckKO;.....oO00l.....','.........'lOOocdko'......;ccclc.....,cc:dOOc..");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....',,oO0kc;;cdkOko;'...,::c;..........;clll:.........;clkOo,...;::,:o:'....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....;'.ckxxkkkxxdo:'.....';;,,.......'..................;clllc;,;::;::,...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....;,.l0OkkxdodkOOkxxdoolllc:;,,,''',ccc::;;;,,,,,'''..',;::::;;;;:;'..");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....;,.c0O000000000O000000000000OOOkxxkOkkkkkxxxdddooollcc::::;,,,,'..");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....,,.c00O000000000000000000000000OOO0KXXKKKKKKKK00000OOOkkkkxxo:..',.");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....,,.:O000000000000000000000000OOO0KXXXXXKKKXKKKKK00KKKKKKKKKKkl,..'...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t....;odcoO0000000000000000000000Okxk00000000000KKXXXXXK000000KK0Kkl,...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t...:olloodxkO00000000000000000OxdkO0000OxxdxxO000000KNNK00000000Kkl,..");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t..;c:::',:cdkOO0000000000000OdlokOO0Oxc;'..'',:dO0000KXK0KKK00000kl,....cddddo;.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.';c;cc.'lc:coxkO0000000000Ol;lkOOOOd;'';coddol::xO000KXXKK000000Ol;..'oOxlclkOl'.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t..,:cdx;,dl::;lxO00000000O0Ol;dOOO0k:,;oO000000Oo:lx00KXX00000000Oo;..ckk:...,x0d'...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t...':odl::::;cdOOO0000000000dcdOOO0xlcdO00000000Ol,o000KXK0000000Oo;..;dOOo;,ckkc.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....,;;,;;:oxO0000000000000OllkOOK0kOO000000000Oo:d000KNK0000000Oo;'..'lxkkxxo;....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......;'.lkkO000000OO00000O00OlcxOO0XNNNK00O0000Odoxk000KNKOO000000d;'.....''''.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......;'.o0O000000OkkkkO00O00OlcdOO0XNWN0OOOOOxddk0000K0xldk000000d:'....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......;;'o00000000OkkOOkkOOO00x::xOOO0KK0OOOOkkOOOOO0OdloxO000000d:'.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......cOOO0KK000000OkOkxxkO000Ol,;ldkOOOOOOOOOOOOOkkdloxO000000000xlc;'.......','....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....,xklokkO0KOO000OOOkOO00000kdlc::cldxxkkkkkxdolloxO00000000OOkxxxkdc'....'c:,;,...");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....:kkld0OkOOkO00000000000000000Okxdolc:cclllccodkO00000O00O0Oxdo;,lxd;.....,:,,.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......:x0K0OkxxO00000000000000000OOO000OOkxdllldkO00000000O00O0Oxddl;ld:......");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......'c:lkkkxk0000000000000000OOOOOOOOOOOOOOOOOOOOOO0000000000OOxlc:,........");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t......';.'x00000000000OkxxdddddooooollllllllllllooooooddddxxxkO0O0O;.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......;.'x0O000000000OkkkxxxxxddddddoooooooooodddddddxxxxxkkOO000O:.........");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......;..d0O00000000O0000000000000000O0000000000000000000000000000c.'.....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......;'.d0000000000OOOOOOOOOOOkkkkkkkxxxxxxddddddddoooooollllllcc,.'.......");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......;'.,:;;;;;;;,,,,,,,,'''''''''''.'................'''''',,,,,,:c:;;;,,'..........");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.......';';;::c:;''.'''''''',,,,,,,,,,;;;;;;;;;;:::::::::ccccccllllcccloddxxxxxxxxdollc:;,''..");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t.....  ..;lokxkOxxkkkxxddoooollodoodddxxxxxxxkkkOOOOOOOOO000000KKKK0KKKXXXXXXNNNNNNNNXXK0OOkxc....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t........  .......':lodkO0KKKXXNXXKXWWWWWWWWWWNNNNNNNXXXXKK000OOOOkkxxxdolllccc:::;;;,,,''''''....");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t..................   ....',,;:lc;,cxdoolllccc::;;;;;,,,'''.....");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t\t\t\t==============================================================================================================================================================================================");
                    Console.ForegroundColor = ConsoleColor.Yellow; //Texto AMARILO en negrita
                    
                    Console.WriteLine("\t\n\t\t\t\t\t\t\t\t\t\t\t   ___ ___ ___ _____ ___ __  __   _     ___  ___    ___ ___ ___ _____ ___ ___  _  _ ");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t  / __|_ _/ __|_   _| __|  \\/  | /_\\   |   \\| __|  / __| __/ __|_   _|_ _/ _ \\| \\| |");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t  \\__ \\| |\\__ \\ | | | _|| |\\/| |/ _ \\  | |) | _|  | (_ | _|\\__ \\ | |  | | (_) | .` | ");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t  |___/___|___/ |_| |___|_|  |_/_/ \\_\\ |___/|___|  \\___|___|___/ |_| |___\\___/|_|\\_|");
                    Console.WriteLine("");
                    // Cuerpo del menú
                    Console.WriteLine("\t\t\t\t\t$$$$$$$\\  $$$$$$$$\\        $$$$$$\\   $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\       $$$$$$$$\\  $$$$$$\\           $$$$$$$\\  $$$$$$$$\\       $$\\   $$\\ $$$$$$$\\  $$\\   $$\\ ");
                    Console.WriteLine("\t\t\t\t\t$$  __$$\\ $$  _____|      $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\\\__$$  __|$$  _____|      \\__$$  __| \\_$$  _|          $$  __$$\\ $$  _____|      $$ |  $$ |$$  __$$\\ $$$\\  $$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$ |            $$ /  \\__|$$ /  $$ |$$ |  $$ |$$ /  $$ |$$ |  $$ |  $$ |   $$ |               $$ |      $$ |            $$ |  $$ |$$ |            $$ |  $$ |$$ |  $$ |$$$$\\ $$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$$$$\\          \\$$$$$$\\  $$ |  $$ |$$$$$$$  |$$ |  $$ |$$$$$$$  |  $$ |   $$$$$\\             $$ |      $$ |            $$ |  $$ |$$$$$\\          $$ |  $$ |$$$$$$$  |$$ $$\\$$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$  __|          \\____$$\\ $$ |  $$ |$$  ____/ $$ |  $$ |$$  __$$<   $$ |   $$  __|            $$ |      $$ |            $$ |  $$ |$$  __|         $$ |  $$ |$$  ____/ $$ \\$$$$ |");
                    Console.WriteLine("\t\t\t\t\t$$ |  $$ |$$ |            $$\\   $$ |$$ |  $$ |$$ |      $$ |  $$ |$$ |  $$ |  $$ |   $$ |               $$ |      $$ |            $$ |  $$ |$$ |            $$ |  $$ |$$ |      $$ |\\$$$ |");
                    Console.WriteLine("\t\t\t\t\t$$$$$$$  |$$$$$$$$\\       \\$$$$$$  | $$$$$$  |$$ |       $$$$$$  |$$ |  $$ |  $$ |   $$$$$$$$\\          $$ |$$\\ $$$$$$\\ $$\\       $$$$$$$  |$$$$$$$$\\       \\$$$$$$  |$$ |      $$ | \\$$ |");
                    Console.WriteLine("\t\t\t\t\t\\_______/ \\________|       \\______/  \\______/ \\__|       \\______/ \\__|  \\__|  \\__|   \\________|         \\__|\\__|\\______|\\__|      \\_______/ \\________|       \\______/ \\__|      \\__|  \\__|");
                    Console.ForegroundColor = ConsoleColor.Red; //Texto ROJO en negrita
                    Console.WriteLine("\n\t\t\t\t\t==============================================================================================================================================================================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t==========================");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  >  1. Iniciar sesión");
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  >  2. Salir");
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t==========================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  >  Elija una opción: ");
                   
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            do
                            {
                                try
                                {

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;                                  
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t======== Iniciar sesión como ========");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Alumno\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Trabajador\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Administrativo\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Docente \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                                    opc = int.Parse(Console.ReadLine());

                                    switch (opc)
                                    {
                                        case 1:// Desarrollo de la parte usuario

                                            menuUsario.Menu_Usuarios(opc, inicioSesion, Lu, LTra, La, Ltick, Lp, ColaSol, ref q, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe, PilaSug, colitaPrioridad);
                                          
                                            opc = 0;
                                            break;

                                        case 2:// Desarrollo parte trabajadores

                                            menuTrabajador.menuTrabajador(opc, inicioSesion, Lu, LTra, La, Ltick, Lp, ArbolitoCompus, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe, AsigTra);
                                            opc = 0;
                                            break; 

                                        case 3: // Desarrollo de la parte aministrativos

                                            menuAdministrador.menuAdmin(opc, inicioSesion, Lu, LTra, La, Ltick, Lp, ColaSol, ref q, PilaSug, registro, ref dniUser, ref dniTrabajador, ref dniAdmin, ref dniProfe, colitaPrioridad);
                                            
                                            opc = 0;
                                            break;// Desarrollo parte Admins

                                        case 4:

                                            break;

                                        case 5:// Salida
                                            break;

                                        default:
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                            Console.ReadLine();
                                            break;
                                    }
                                }
                                catch  
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                                    Console.ReadLine();
                                }

                            } while (opc != 4);

                            opc = 0;
                            break;

                        case 2: // Sale del programa
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                            Console.ReadLine();
                            break;

                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }

            } while (opc != 2);
        
        }
        public void EnMedio()
        {
            Console.Write("\t\t\t\t\t\t\t\t\t\t");
        }
        public void ModificacionUsuariosTrabajsYAdmins(int codigo, int tipoModificar)
        {
            int opc = 0;
            string tipoObjeto = " ", cabecera = " ";

            if (tipoModificar == 1)
            {
                tipoObjeto = "alumno";
                cabecera = "Alumno";
            }
            else if (tipoModificar == 2)
            {
                tipoObjeto = "trabajador";
                cabecera = "Trabajadores";
            }
            else if (tipoModificar == 3)
            {
                tipoObjeto = "administrador";
                cabecera = "Administradores";
            }
            do
            {
                try
                {
                   
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t============ Modificando " + cabecera+ " ==========");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. Modificar nombres\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Modificar apellidos\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Modificar número celular\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Modificar contraseña \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Volver.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=================================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                    opc = int.Parse(Console.ReadLine());

                    string modificacion1 = " ";
                    int modificacion2 = 0;
                    bool verificacion;

                    switch (opc)
                    {
                        case 1:

                            do {

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t        Modificando " + cabecera);
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================================================");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|         Modificando nombres. Ingrese el número 2 para volver      |");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese los nuevos nombres del " + tipoObjeto+" : ");
                                Console.Write("\n    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                             
                                if(modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {

                                    if(tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if(tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);

                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  ¡Nombres modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if(verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Los nombres no pueden quedar vacios y no deben tener caracteres númericos.\n... O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }

                            } while (verificacion != true);

                            opc = 0;
                            break;

                        case 2:
                            do
                            {
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t        Modificando " + cabecera);
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|         Modificando apellidos. Ingrese el número 2 para volver      |");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t=======================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese los nuevos apellidos del " + tipoObjeto + ": ");
                                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                                if (modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {
                                    if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Apellidos modificados con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t... Los apellidos no pueden quedar vacios y no deben tener caracteres númericos\n... O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);
                            opc = 0;
                            break;

                        case 3:

                            do {
                                string aux;

                                Console.Clear();
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t        Modificando " + cabecera);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t================================================================================");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|       Modificando número de celular. Ingrese el número 2 para volver         |");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t================================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese el nuevo número de celular  del " + tipoObjeto+" : ");
                                aux = Console.ReadLine();
                                verificacion = validacion.ValidacionIngresoSoloNum(aux);

                                if (verificacion == true)
                                {
                                    modificacion2 = int.Parse(aux);
                                    verificacion = validacion.ValidacionIngresoNumeroCelular(modificacion2);

                                    if (aux == "2") break;
                                    else if (verificacion == true)
                                    {
                                        verificacion = true;
                                        if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                        else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                        else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  ¡Número de celular modificado con exito!");
                                        Console.ReadLine();
                                    }
                                    else if (verificacion == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... La longitud del número de celular debe ser de 9 caracteres númericos\n... O ingrese el número 2 para volver");
                                        Console.ReadLine();
                                    }

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... La variable debe poseer solo caracteres de tipo númericos\n... O ingrese el número 2 para volver");
                                    Console.ReadLine();
                                }
                            } while (verificacion != true);

                            opc = 0;
                            break;

                        case 4:
                            do
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t        Modificando " + cabecera);
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================================");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t|              Modificando contraseña. Ingrese el número 2 para volver            |");
                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t===================================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t >  Por favor ingrese la nueva contraseña " + tipoObjeto+" : ");
                                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t    ");
                                modificacion1 = Console.ReadLine();

                                verificacion = validacion.ValidacionIngresoNum2(modificacion1);
                                if (modificacion1 == "2")
                                {
                                    break;
                                }
                                else if (verificacion == true)
                                {
                                    if (tipoModificar == 1) Lu.ModificarDatosUsers(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 2) LTra.ModificarDatosTrabajadores(modificacion1, modificacion2, codigo, opc);
                                    else if (tipoModificar == 3) La.ModificarDatosAdmins(modificacion1, modificacion2, codigo, opc);

                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t  ->  Contraseña modificada con exito!");
                                    Console.ReadLine();
                                }
                                else if (verificacion == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t... La contraseña no pueden quedar vacia. O ingrese el número 2 para salir.");
                                    Console.ReadLine();
                                }
                            } while (verificacion == false);

                            opc = 0;
                            break;

                        case 5:
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                            Console.ReadLine();
                            break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }
            } while (opc != 5);
        }
        public void GestionTickets(int tipoIngresante, string nombreCompleto, int codigoCreador)
        {
            int opc = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t======= Gestionando tickets =======");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  1. Ver lista de tickets \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  2. Generar ticket \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  3. Responder ticket \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  4. Ver tickets en espera \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  5. Ver tickets resueltos \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  6. Designar tickets \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  7. Ver tickets asignados \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  8. Eliminar ticket\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  9. Mostrar Papelera \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  10. Restaurar ultimo ticket eliminado ticket \n\n\t\t\t\t\t\t\t\t\t\t\t\t\t " +
                        ">  11. Volver");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t===================================");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:

                            Console.Clear();
                            colitaPrioridad.ImprimirTicketsPrio();
                            ColaTicketsResueltos.ImprimirTicketsResueltos();
                            Console.ReadLine();

                            opc = 0;
                            break; //lito

                        case 2:
                            do
                            {
                                try
                                {
                                    string categoria;
                                    string nivel = " ";
                                    if (tipoIngresante == 4) nivel = "Administrador";
                                    else if (tipoIngresante == 2) nivel = "Trabajador";
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t    Indicanos el servicio que presenta fallas");
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t====================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  1. VPN: Conexion, error en VPN");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  2. Equipos de computo y accesorios");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  3. Redes: Falla de conexión, lentitud, etc.");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  4. Software: Teams, Windows, Office, etc. ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  5. Wifi: falla de conexión, etc.");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  6. Internet: caida del servicio ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  7. Correo: No envia ni recibe correo ");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  8. Antivirus:AMP, Umbrell");
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  9. Volver");
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t====================================================");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Elija una opción: ");
                                    opc = int.Parse(Console.ReadLine());
                                    switch (opc)
                                    {
                                        case 1:
                                            categoria = "VPN: Conexion, error en VPN";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 2:
                                            categoria = "Equipos de computo y accesorios";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 3:
                                            categoria = "Redes: Falla de conexión, lentitud, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 4:
                                            categoria = "Software: Teams, Windows, Office, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 5:
                                            categoria = "Wifi: falla de conexión, etc";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 6:
                                            categoria = "Internet: caida del servicio";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 7:
                                            categoria = "Correo: No envia ni recibe correo ";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 8:
                                            categoria = "Antivirus:AMP, Umbrell";
                                            generarTicketsito.GenerarTickesito(categoria, nombreCompleto, colitaPrioridad, codigoCreador, tipoIngresante, nivel);
                                            break;
                                        case 9: // sale de do while
                                            break;
                                    }
                                }
                                catch
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese un dato valido >");
                                    Console.ReadLine();
                                }

                            } while (opc != 9);

                            opc = 0;
                            break; //lito

                        case 3:

                            Console.Clear();
                            colitaPrioridad.ResponderTicket(ColaTicketsResueltos);      
                            opc = 0;
                            break; //lito

                        case 4:
                            Console.Clear();
                            colitaPrioridad.ImprimirTicketsPrio();
                            Console.ReadLine();
                            opc = 0;
                            break; //lito

                        case 5:
                            Console.Clear();
                            ColaTicketsResueltos.ImprimirTicketsResueltos();
                            Console.ReadLine();
                            opc = 0;
                            break; //lito

                        case 6:

                            string codigoTi, codigoTr;
                            bool flag;
                           
                            do
                            {
                                Console.Clear();
                                colitaPrioridad.MostrarTicketsEsperaPrio();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t=====================================================================");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese código del ticket que desea designar: ");
                                codigoTi = Console.ReadLine();

                                flag = validacion.ValidacionIngresoSoloNum(codigoTi);
                                if (codigoTi == "2")
                                {
                                    break;
                                }
                                else if (flag == true)
                                {
                                    flag = false;

                                    flag =  colitaPrioridad.SaberSiExisteTicketPrio(int.Parse(codigoTi));

                                    if(flag == true)
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            LTra.MostrarListaTrabajadores();
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.Write("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t==========================================================");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("\n\t\t\t\t\t\t\t\t\t\t\t\t\t >  Ingrese código del trabajador a designar:");
                                            codigoTr = Console.ReadLine();
                                            flag = validacion.ValidacionIngresoSoloNum(codigoTi);
                                            if (codigoTr == "2")
                                            {
                                                break;
                                            }
                                            else if (flag == true)
                                            {
                                                flag = false;
                                                flag = LTra.SaberSiExisteTrabajadorConCodigo(int.Parse(codigoTr));
                                                if (flag == true)
                                                {
                                                    AsigTra.AsignacionTicket(int.Parse(codigoTr), int.Parse(codigoTi), Ltick, colitaPrioridad);
                                                 
                                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t=============================");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine(" \n\t\t\t\t\t\t\t\t\t\t\t\t\t Asignación hecha: ");
                                                    Console.WriteLine(" \n\t\t\t\t\t\t\t\t\t\t\t\t\t Ticket: " + codigoTi);
                                                    Console.WriteLine(" \n\t\t\t\t\t\t\t\t\t\t\t\t\t Responsable: " + LTra.ObtenerNombreTrabajadoresConCodigo(int.Parse(codigoTr)));
                                                    Console.ReadLine();
                                                }
                                            }
                                            if (flag == false)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Trabajador no encontrado\n... Ingrese el código correcto o ingrese el número 2 para volver");
                                                Console.ReadLine();
                                            }
                                        } while (flag != true);
                                    }

                                    if (flag == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Ticket no encontrado\n... Ingrese el código correcto o ingrese el número 2 para volver");
                                        Console.ReadLine();
                                    }

                                }
                                else if (flag == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t... Ingrese solo un valor númerico\n");
                                    Console.ReadLine();
                                }
                            } while (flag != true);
                            opc = 0;
                            break;

                        case 7:
                            if (tipoIngresante == 4) { Console.WriteLine("\n\n\n\t\t\t\t\t\t Como administrador no se le puede designar tickets..."); Console.ReadLine(); }
                            else if (tipoIngresante == 2)
                            {

                                AsigTra.MostrarTicketPorTrabajor(codigoCreador, colitaPrioridad);
                            }
                            break;

                        case 8:
                            Console.Clear();
                            colitaPrioridad.EliminarTicketPrioridad(Papelera);
                            opc = 0;
                            break;

                        case 9:
                            Console.Clear();
                            Papelera.MostrarPapelera();
                            Console.ReadLine();
                            break;

                        case 10:
                            Ticket q;
                            q = Papelera.RestaurarElUltimoTicketIngresado();
                            colitaPrioridad.AgregarTicketPrioridad(q.dueño, q.descripcion, q.codigoDueño, q.categoria,q.prioridadNum, q.prioridadDes);

                            break;

                        case 11:
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                            Console.ReadLine();
                            break;

                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n\t\t\t\t\t\t\t\t\t\t\t\t\t.. < Ingrese una opción valida >");
                    Console.ReadLine();
                }
            } while (opc != 11);
        }

    }
}

