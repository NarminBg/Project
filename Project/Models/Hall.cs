using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    internal class Hall:BaseEntity
    {
        internal string Name { get; set; }
        internal Theater Theater { get; set; }
        internal int RowCount { get; set; }
        internal int ColumnCount { get; set; }

        public override string ToString()
        {
            Console.WriteLine();
            return $"Hall's ID:{Id}\nName:{Name}\nTheater:{Theater}\nCount of row:{RowCount}\nCount of column:{ColumnCount} ";

            
        }
    }
}
