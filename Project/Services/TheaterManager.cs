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
    internal class TheaterManager : ICrudService,IPrintService
    {
        private Theater[]_theaters=new Theater[4];
        private int _currentIndex = 0;

        public void Add(BaseEntity baseEntity)
        {
            if (_currentIndex>3)
            {
                Console.WriteLine("You can add only 4 theaters!");

                return;
            }

            _theaters[_currentIndex++]=(Theater)baseEntity;
            Console.WriteLine("Theater is added successfully!");
        }

        public void Delete(int id)
        {
            bool found = false;

            for (int i = 0; i < _theaters.Length; i++)
            {
                if (_theaters[i]==null)
                {
                    continue;
                }
                if (_theaters[i].Id==id)
                {
                    found = true;

                    for (int j = i; j <_theaters.Length; j++)
                    {
                        _theaters[j] = _theaters[j + 1];
                    }
                    _currentIndex--;

                    Console.WriteLine("Theater is deleted!");

                    return;
                }
            }
            if (!found)
            {
                Console.WriteLine("Theater is not found!");
            }
        }

        public BaseEntity Get(int id)
        {
            foreach (var item in _theaters)
            {
                if (item==null)
                {
                    continue;
                }
                if (item.Id==id)
                {
                    Console.Write(item);

                    return item;
                }
            }

            return null;
        }

        public BaseEntity[] GetAll()
        {
            return _theaters;
        }

        public void Print()
        {
            foreach (var item in _theaters)
            {
                if (item==null)
                {
                    continue;
                }
                Console.WriteLine(item);
            }
        }
          
        public void Update(int id, BaseEntity baseEntity)
        {
            for (int i = 0; i < _theaters.Length; i++)
            {
                if (_theaters[i] == null)
                {
                    continue;
                }
                if (_theaters[i].Id == id)
                {
                    _theaters[i] = (Theater)baseEntity;
                    Console.WriteLine("Theater is changed!");

                    return;
                }
            }
            Console.WriteLine("Theater is not found!");
        }
    }
}
