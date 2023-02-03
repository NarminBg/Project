using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Theater : BaseEntity
    {
        internal string Name { get; set; }

        public override string ToString()
        {
            Console.WriteLine(" ");
            return $"{Name}";
        }
    }
}
