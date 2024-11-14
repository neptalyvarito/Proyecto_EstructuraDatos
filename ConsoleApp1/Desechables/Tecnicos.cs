using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Tecnicos
    {
        public Trabajador datosTecnico;
        public Ticket ticketParaResolver;
        public Lista_Tickets Lista_Tickets;
        public Tecnicos ant;
        public Tecnicos sgte;
        public Tecnicos(Trabajador datosTecnico)
        {
            this.datosTecnico = datosTecnico;
            this.ant = null;
            this.sgte = null;
        }
    }
}
