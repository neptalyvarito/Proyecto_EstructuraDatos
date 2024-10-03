using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Validaciones
    {
        public bool ValidacionIngresoDni(int numeroDNI)
        {
            bool flag = false;
            if(numeroDNI.ToString().Length == 8) flag = true;

            return flag;
        }
        public bool ValidacionIngresoNumeroCelular(int cadenaValidar)
        {
            bool flag = false;

            if (cadenaValidar.ToString().Length == 9)
            {
                flag = true;   
            }
            return flag;
        }
        public bool ValidacionDeCadenaVaciaEIngresoNum2(string cadenaAVerificar) // sirve para contraseñas y respuestas a tickets
        {
            bool verificacion = false;
            char[] b = new char[cadenaAVerificar.Length];

            if (cadenaAVerificar != null)
            {
                if (cadenaAVerificar == "2") verificacion = true;
                else
                {
                    for (int i = 0; i < cadenaAVerificar.Length; i++)
                    {
                        b[i] = cadenaAVerificar[i];
                        if (b[i] != ' ')
                        {
                            verificacion = true;
                            break;
                        }
                    }
                }
            }
            return verificacion;
        }
        public bool ValidacionDeCadenaSoloLetras(string cadenaAVerificar) // sirve para solo ingresar nombres, apellidos
        {
            bool verificacion = false;
            char[] b = new char[cadenaAVerificar.Length];

            if (cadenaAVerificar != null)
            {
                for (int i = 0; i < cadenaAVerificar.Length; i++)
                {
                    b[i] = cadenaAVerificar[i];
                    if (b[i] != ' ')
                    {
                        verificacion = true;
                        break;
                    }
                }
            }
            if(verificacion == true)
            {
                for (int i = 0; i < cadenaAVerificar.Length; i++)
                {
                    if (b[0] == 2) break;
                    b[i] = cadenaAVerificar[i];
                    if (b[i] == '1' || b[i] == '2' || b[i] == '3' || b[i] == '4' || b[i] == '5' || b[i] == '7' || b[i] == '8' || b[i] == '6' || b[i] == '9' || b[i] == '0')
                    {
                    
                        verificacion = false;
                        break;
                    }
                }
            }
            return verificacion;
        }
        public bool ValidacionIngresoNum2(string cadenaAVerificar)
        {
            bool verificacion = false;
           

            if (cadenaAVerificar != null)
            {
                if (cadenaAVerificar == "2") verificacion = true;
            } 
            if(verificacion == false)
            {
                verificacion = ValidacionDeCadenaSoloLetras(cadenaAVerificar);
            }
            return verificacion;
        }
        public bool ValidacionIngresoSoloNum(string cadena)
        {
            return int.TryParse(cadena, out int numero);
        } 
    }
}
