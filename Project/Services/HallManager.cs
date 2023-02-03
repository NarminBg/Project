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
    internal class HallManager : ICrudService, IPrintService
    {
        private Hall[] _halls = new Hall[4];
        private int _currentIndex = 0;

        public void Add(BaseEntity baseEntity)
        {
            if (_currentIndex > 3)
            {
                Console.WriteLine("You can add only 4 halls!");

                return;
            }

            Console.WriteLine();
            _halls[_currentIndex++] = (Hall)baseEntity;
            Console.WriteLine("Hall is added succesfully");
        }

        public void Delete(int id)
        {
            bool found = false;

            for (int i = 0; i < _halls.Length; i++)
            {
                if (_halls[i] == null)
                {
                    continue;
                }
                if (id == _halls[i].Id)
                {
                    found = true;
                    for (int j = i; j < _halls.Length; j++)
                    {
                        _halls[j] = _halls[j + 1];
                    }

                    _currentIndex--;
                    Console.WriteLine("Hall is deleted.");

                    return;
                }

                if (!found)
                {
                    Console.WriteLine("Hall is not found!");
                }
            }
        }

        public BaseEntity Get(int id)
        {
            foreach (var item in _halls)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Id == id)
                {
                    Console.Write(item);

                    return item;
                }
            }
            Console.WriteLine("Hall is not found");

            return null;
        }

        public BaseEntity[] GetAll()
        {
            return _halls;
        }

        public void Print()
        {
            foreach (var item in _halls)
            {
                if (item == null)
                    continue;

                Console.Write(item);
            }
        }

        public void Update(int id, BaseEntity baseEntity)
        {
            throw new NotImplementedException();
        }
    }
}
