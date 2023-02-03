using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Session:BaseEntity
    {
        internal Hall Hall { get; set; }
        internal DateTime SessionTime { get; set; }
        internal Film Film { get; set; }
        internal int Price{get; set; }

        public override string ToString()
        {
            return $"Session's ID:{Id}\n Hall:{Hall}\nSession time:{SessionTime}\n Film:{Film}\n Price:{Price}\n";
        }
    }
}
