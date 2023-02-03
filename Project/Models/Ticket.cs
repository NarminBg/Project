using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Ticket : BaseEntity
    {
        internal Session Session { get; set; }
        internal int Row { get; set; }
        internal int Column { get; set; }

        public override string ToString()
        {
            return $"Session:{Session}/n Row:{Row}/n Column{Column}";
        }

    }
}
