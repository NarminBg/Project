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
    internal class SessionManager : ICrudService, IPrintService
    {
        private Session[] _sessions = new Session[4];
        private int _currentIndex = 0;
        public void Add(BaseEntity baseEntity)
        {
            if (_currentIndex > 3)
            {
                Console.WriteLine("You can add only 4 sessions");
                return;
            }

            Console.WriteLine(" ");
            _sessions[_currentIndex++] = (Session)baseEntity;
            Console.WriteLine("Session is added succesfully!");
        }

        public void Delete(int id)
        {
            bool found = false;

            for (int i = 0; i < _sessions.Length; i++)
            {
                if (_sessions[i] == null)
                {
                    continue;
                }
                if (_sessions[i].Id == id)
                {
                    found = true;

                    for (int j = i; j < _sessions.Length; j++)
                    {
                        _sessions[j] = _sessions[j + 1];
                    }
                    _currentIndex--;

                    Console.WriteLine("Session is deleted");

                    return;
                }
                if (!found)
                {
                    Console.WriteLine("Session is not found!");
                }
            }
        }

        public BaseEntity Get(int id)
        {
            foreach (var item in _sessions)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Id == id)
                {
                    Console.WriteLine(item);

                    return item;
                }
            }
            Console.WriteLine("Session is not found!");

            return null;
        }

        public BaseEntity[] GetAll()
        {
           return _sessions;
        }

        public void Print()
        {
            foreach (var item in _sessions)
            {
                if (item == null)
                {
                    continue;
                }
                Console.WriteLine(item);
            }
        }

        public void Update(int id, BaseEntity baseEntity)
        {
            for (int i = 0; i < _sessions.Length; i++)
            {
                if (_sessions[i] == null)
                {
                    continue;
                }
                if (_sessions[i].Id == id)
                {
                    _sessions[i] = (Session)baseEntity;
                    Console.WriteLine("Session is changed!");

                    return;
                }
            }
            Console.WriteLine("Session is not found!");
        }
    }
}
