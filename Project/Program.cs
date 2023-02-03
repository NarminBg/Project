using Project.Models;
using Project.Services;
using System;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filmManager = new FilmManager();
            var hallManager = new HallManager();
            var sessionManager = new SessionManager();
            var theaterManager = new TheaterManager();
            var ticketManager = new TicketManager();

            string command = "";

            do
            {
                Console.Write("Enter the command:");
                command = Console.ReadLine();
                Console.WriteLine(" ");

                if (command.ToLower().Equals("add theater"))
                {
                    var theater1 = new Theater
                    {
                        Id = 1,
                        Name = "Ganjlik Mall"
                    };

                    var theater2 = new Theater
                    {
                        Id = 2,
                        Name = "28 Mall"
                    };
                    var theater3 = new Theater
                    {
                        Id = 3,
                        Name = "Deniz Mall"
                    };
                    var theater4 = new Theater
                    {
                        Id = 4,
                        Name = "Amburan"
                    };

                    theaterManager.Add(theater1);
                    theaterManager.Add(theater2);
                    theaterManager.Add(theater3);
                    theaterManager.Add(theater4);
                }
                else if (command.ToLower().Equals("print theaters"))
                {
                    theaterManager.Print();
                }
                else if (command.ToLower().Equals("add hall"))
                {
                    var hall1 = new Hall
                    {
                        Id = 1,
                        Name = "Platinum",
                        Theater = (Theater)theaterManager.Get(1),
                        RowCount = 8,
                        ColumnCount = 8,
                    };
                    var hall2 = new Hall
                    {
                        Id = 2,
                        Name = "Birbank",
                        Theater = (Theater)theaterManager.Get(2),
                        RowCount = 8,
                        ColumnCount = 8,
                    };
                    var hall3 = new Hall
                    {
                        Id = 3,
                        Name = "Rabitabank",
                        Theater = (Theater)theaterManager.Get(3),
                        RowCount = 8,
                        ColumnCount = 8,
                    };
                    var hall4 = new Hall
                    {
                        Id = 4,
                        Name = "Baku Electronics",
                        Theater = (Theater)theaterManager.Get(4),
                        RowCount = 8,
                        ColumnCount = 8,
                    };

                    hallManager.Add(hall1);
                    hallManager.Add(hall2);
                    hallManager.Add(hall3);
                    hallManager.Add(hall4);
                }
                else if (command.ToLower().Equals("print halls"))
                {
                    hallManager.Print();
                }
                else if (command.ToLower().Equals("add film"))
                {
                    var film1 = new Film
                    {
                        Id = 1,
                        Name = "Trust me"
                    };
                    var film2 = new Film
                    {
                        Id = 2,
                        Name = "Avatar"
                    };
                    var film3 = new Film
                    {
                        Id = 3,
                        Name = "Shotgun wedding"
                    };
                    var film4 = new Film
                    {
                        Id = 4,
                        Name = "Babylon"
                    };

                    filmManager.Add(film1);
                    filmManager.Add(film2);
                    filmManager.Add(film3);
                    filmManager.Add(film4);

                }
                else if (command.ToLower().Equals("print films"))
                {
                    filmManager.Print();
                }
                else if (command.ToLower().Equals("add session"))
                {
                    var session1 = new Session
                    {
                        Id = 1,
                        Hall = (Hall)hallManager.Get(1),
                        SessionTime = DateTime.Parse("03.03.2023  17:00"),
                        Film = (Film)filmManager.Get(1),
                        Price = 30
                    };
                    var session2 = new Session
                    {
                        Id = 2,
                        Hall = (Hall)hallManager.Get(2),
                        SessionTime = DateTime.Parse("03.03.2023  19:00"),
                        Film = (Film)filmManager.Get(2),
                        Price = 10,
                    };
                    var session3 = new Session
                    {
                        Id = 3,
                        Hall = (Hall)hallManager.Get(3),
                        SessionTime = DateTime.Parse("03.03.2023  21:30"),
                        Film = (Film)filmManager.Get(3),
                        Price = 10,
                    };
                    var session4 = new Session
                    {
                        Id = 4,
                        Hall = (Hall)hallManager.Get(4),
                        SessionTime = DateTime.Parse("03.03.2023  23:30"),
                        Film = (Film)filmManager.Get(4),
                        Price = 10,
                    };

                    sessionManager.Add(session1);
                    sessionManager.Add(session2);
                    sessionManager.Add(session3);
                    sessionManager.Add(session4);
                }

                else if (command.ToLower().Equals("print sessions"))
                {
                    sessionManager.Print();

                    Console.WriteLine("If you want continue, choose 1"); 
                    int operation = int.Parse(Console.ReadLine());

                    bool a = false;

                    switch (operation)
                    {
                        case 1:
                            a = true;

                            Console.Write("Session ID: ");
                            var id = int.Parse(Console.ReadLine());
                            var session = (Session)sessionManager.Get(id);
                            var tickets = ticketManager._tickets;

                            Console.Write("    ");

                            for (int i = 0; i < session.Hall.ColumnCount; i++)
                            {
                                Console.Write($"{ i+1,-6}");
                            }

                            Console.WriteLine(" ");

                            for (int i = 0; i < session.Hall.RowCount; i++)
                            {
                                Console.Write($"{i+1,-3}");

                                for (int j = 0; j < session.Hall.ColumnCount; j++)
                                {
                                    bool sold = false;

                                    for (int l = 0; l < tickets.Length; l++)
                                    {
                                        if (tickets[l] != null && tickets[l].Session.Id == id && tickets[l].Row == i && tickets[l].Column == j )
                                        {
                                            sold = true;
                                            break;
                                        }
                                    }

                                    if (sold)
                                        Console.Write("sold ");
                                    else
                                        Console.Write("empty ");
                                }

                                Console.WriteLine("");
                            }

                            break;
                        case 2:
                            a = true;
                            break;
                    }

                    if (a)
                    {
                        Console.WriteLine();
                        Console.WriteLine("If you want buy ticket, choose 1");

                        int operation1 = int.Parse(Console.ReadLine());

                        switch (operation1)
                        {
                            case 1:
                                Console.Write("Choose session: ");
                                var sessionId = int.Parse(Console.ReadLine());
                                Console.Write("Choose Row: ");
                                var row = int.Parse(Console.ReadLine());
                                Console.Write("Choose Column: ");
                                var column = int.Parse(Console.ReadLine());
                                var session = (Session)sessionManager.Get(sessionId);

                                ticketManager.Ticket(session, row - 1, column - 1);

                                break;
                            case 2:
                                break;

                        }
                    }
                }

            } while (true);
            
        }
    }
}