using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Film : BaseEntity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}"; 
        }
    }
}
