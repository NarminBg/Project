using Core.Models;
using Core.Services.Contracts;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    internal class TicketManager : IPrintService
    {
        public Ticket[] _tickets=new Ticket[4];
        private int _currentIndex = 0;

        public void Ticket(Session session, int row,int column)
        {
            _tickets[_currentIndex] = new Ticket
            {
                Session = session,
                Row = row,
                Column = column
            };

            _currentIndex++;
        }
      

        public void Print()
        {
            foreach (var item in _tickets)
            {
                if (item==null)
                {
                    continue;
                }

                Console.WriteLine(item);
            }
        }

    }
}
