using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TicketsProgramados
    {
        public Ticket t;
        public TicketsProgramados sgte;
        public TicketsProgramados (Ticket t)
        {
            this.t = t;
            sgte = null;
        }
    }
}
