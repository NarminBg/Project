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
    internal class FilmManager : ICrudService, IPrintService
    {
        private Film[] _films = new Film[4];
        private int _currentIndex = 0;
        public void Add(BaseEntity baseEntity)
        {
            if (_currentIndex>3)
            {
                Console.WriteLine("You can add only 4 films!");

                return;
            }

            _films[_currentIndex++] = (Film)baseEntity;
            Console.WriteLine("Film is added successfully!");
        }

        public void Delete(int id)
        {
            bool found = false;
            for (int i = 0; i < _films.Length; i++)
            {
                if (_films[i] == null)
                {
                    continue;
                }

                if (id == _films[i].Id)
                {
                    found = true;
                    for (int j = 0; j < _films.Length; j++)
                    {
                        _films[j] = _films[j + 1];
                    }

                    _currentIndex--;
                    Console.WriteLine("Film is deleted");

                    return;
                }

               
                if (!found)
                {
                    Console.WriteLine("Film is not found!");
                }     
            }
        }

        public BaseEntity Get(int id)
        {
            foreach (var item in _films)
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
            Console.WriteLine("Not found!");

            return null;
        }

        public BaseEntity[] GetAll()
        {
            return _films;
        }

        public void Print()
        {
            foreach (var item in _films)
            {
                if (item==null)
                {
                    continue;
                }

                Console.WriteLine(item);
            };
        }

        public void Update(int id, BaseEntity baseEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseEntity baseEntity)
        {
            throw new NotImplementedException();
        }
    }
}
