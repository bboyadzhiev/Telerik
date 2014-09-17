using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;
using MusicLibrary.Data;

using System.Net;
using System.Net.Http;


using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Http.Headers;

using System.Runtime.Serialization;

namespace MusicLibrary.ConsoleClient
{
    static class Program
    {
        static string baseUrl = "http://localhost:4196/api";


        static void Main(string[] args)
        {
            string inputLine = "";

            Requester reqConsumer = new Requester(baseUrl);

            while (true)
            {
                PrintMenu();
                inputLine = Console.ReadLine().ToLower();

                if (inputLine == "4")
                {
                    break;
                }

                ExecuteMenuChoice(inputLine, reqConsumer);

                PrintEndOperationsCycle();
            }


        }
        static void ExecuteMenuChoice(string inputChoice, Requester reqConsumer)
        {
            switch (inputChoice)
            {
                case "1":
                    {
                        string controller = "/artists";
                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();
                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterArtist, UpdateArtist);
                    }
                    break;
                case "2":
                    {
                        string controller = "/albums";

                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();

                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterAlbum, UpdateAlbum);
                    } break;
                case "3":
                    {
                        string controller = "/songs";

                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();

                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterSong, UpdateSong);
                    } break;

                default: Console.WriteLine("Error, incorrect digit."); break;
            }
        }

        static void ExecuteCRUDChoice(string inputChoice, Requester reqConsumer, string controller,
            Func<Requester, string, string> CreateEntry, Func<Requester, string, string> UpdateEntry)
        {
            switch (inputChoice)
            {
                case "1":
                    {
                        var sent = CreateEntry(reqConsumer, controller);
                        Console.WriteLine(sent);
                    }
                    break;
                case "2":
                    {
                        var recieved = reqConsumer.Read(controller);
                        Console.WriteLine(recieved);
                    }
                    break;
                case "3":
                    {
                        var recieved = UpdateEntry(reqConsumer, controller);
                        Console.WriteLine(recieved);
                    }
                    break;
                case "4":
                    {
                        Console.Write("Enter id: ");
                        var inputId = int.Parse(Console.ReadLine());
                        var recieved = reqConsumer.Delete(controller, inputId.ToString());
                        Console.WriteLine("Deleted: \n{0}", recieved);
                    }
                    break;
                case "5":
                    {
                        Console.Write("Enter id: ");
                        var inputId = int.Parse(Console.ReadLine());
                        var recieved = reqConsumer.Read(controller, inputId.ToString());
                        Console.WriteLine(recieved);
                    }
                    break;
                default: Console.WriteLine("Error, incorrect digit."); break;
            }
        }

        private static string UpdateArtist(Requester reqConsumer, string controller)
        {
            Console.Write("Enter id: ");
            var inputId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter country(optional): ");
            string country = Console.ReadLine();
            Console.WriteLine("Enter birth date(optional): ");
            DateTime date = DateTime.Now;
            try
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            Artist newArtist = new Artist()
            {
                Id = inputId,
                Name = name,
                Country = country,
                DateOfBirth = date
            };

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Artist>(newArtist, controller, inputId.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Artist>(newArtist, controller, inputId.ToString());
                return sent;
            }
        }

        private static string EnterArtist(Requester reqConsumer, string controller)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter country(optional): ");
            string country = Console.ReadLine();
            Console.WriteLine("Enter birth date(optional): ");
            DateTime date = DateTime.Now;
            try
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            Artist newArtist = CreateArtistObject(0, name, country, date);

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.CreateAsJson<Artist>(newArtist, controller);
                return sent;
            }
            else
            {
                var sent = reqConsumer.CreateAsXML<Artist>(newArtist, controller);
                return sent;
            }
        }

        private static Artist CreateArtistObject(int id, string name, string country, DateTime date)
        {
            Artist newArtist = new Artist()
            {
                Id = id,
                Name = name,
                Country = country,
                DateOfBirth = date
            };
            return newArtist;
        }

        private static string EnterAlbum(Requester reqConsumer, string controller)
        {
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter producer(optional): ");
            string producer = Console.ReadLine();
            Console.WriteLine("Enter release date(optional): ");
            DateTime releaseDate = DateTime.Now;
            try
            {
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            Album newAlbum = new Album()
            {
                Title = title,
                Producer = producer,
                Year = releaseDate,
            };

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.CreateAsJson<Album>(newAlbum, controller);
                return sent;
            }
            else
            {
                var sent = reqConsumer.CreateAsXML<Album>(newAlbum, controller);
                return sent;
            }
        }

        private static string UpdateAlbum(Requester reqConsumer, string controller)
        {
            Console.Write("Enter id: ");
            var inputId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter producer(optional): ");
            string producer = Console.ReadLine();
            Console.WriteLine("Enter release date(optional): ");
            DateTime releaseDate = DateTime.Now;
            try
            {
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            Console.WriteLine("Artist Name(optional): ");
            string artistName = Console.ReadLine();


            MusicLibraryDbContext db = new MusicLibraryDbContext();

            var artist = (from a in db.Artists
                          where a.Name == artistName
                          select a
                        ).ToList();

            Album newAlbum;

            if (artist == null)
            {
                newAlbum = new Album()
                {
                    Id = inputId,
                    Title = title,
                    Producer = producer,
                    Year = releaseDate
                };
            }
            else
            {
                List<Artist> artists = new List<Artist>();
                foreach (var art in artist)
                {
                    artists.Add(CreateArtistObject(artist[0].Id, artist[0].Name, artist[0].Country, artist[0].DateOfBirth));
                }

                newAlbum = new Album()
                {
                    Id = inputId,
                    Title = title,
                    Producer = producer,
                    Year = releaseDate,
                    Artists = artists
                };
            }

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Album>(newAlbum, controller, inputId.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Album>(newAlbum, controller, inputId.ToString());
                return sent;
            }
        }

        private static string EnterSong(Requester reqConsumer, string controller)
        {
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter genre(optional): ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter release date(optional): ");
            DateTime releaseDate = DateTime.Now;
            try
            {
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            MusicLibraryDbContext db = new MusicLibraryDbContext();

            Console.WriteLine("Artist Name(optional): ");
            string artistName = Console.ReadLine();

            var artist = (from a in db.Artists
                          where a.Name == artistName
                          select a
                        ).FirstOrDefault();

            Song newSong = new Song()
            {
                Title = title,
             
                Year = releaseDate
            };

            newSong.Artist = CreateArtistObject(artist.Id, artist.Name, artist.Country, artist.DateOfBirth);

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.CreateAsJson<Song>(newSong, controller);
                return sent;
            }
            else
            {
                var sent = reqConsumer.CreateAsXML<Song>(newSong, controller);
                return sent;
            }
        }

        private static string UpdateSong(Requester reqConsumer, string controller)
        {
            Console.Write("Enter id: ");
            var inputId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter genre(optional): ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter release date(optional): ");
            DateTime releaseDate = DateTime.Now;
            try
            {
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {

            }

            MusicLibraryDbContext db = new MusicLibraryDbContext();

            Console.WriteLine("Artist Name(optional): ");
            string artistName = Console.ReadLine();




            var artist = (Artist)(from a in db.Artists
                                  where a.Name == artistName
                                  select a
                        ).FirstOrDefault();
            Song newSong;

            if (artist == null)
            {
                newSong = new Song()
                {
                    Id = inputId,
                    Title = title,
                    Year = releaseDate
                };
            }
            else
            {
                newSong = new Song()
                {
                    Id = inputId,
                    Title = title,
                    Year = releaseDate,
                    Artist = CreateArtistObject(artist.Id, artist.Name, artist.Country, artist.DateOfBirth)
                };
            }

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Song>(newSong, controller, inputId.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Song>(newSong, controller, inputId.ToString());
                return sent;
            }
        }

        static string PrintCurrentPath(string controller)
        {
            string path = baseUrl + controller;
            Console.WriteLine(path);

            return path;
        }

        static void PrintMenu()
        {
            Console.WriteLine("Enter corresponding number for each option:\n1. Artist\n2. Album\n3. Song\n4. End");
        }

        static void PrintCRUDOperationsChoices()
        {
            Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete\n5. Read with Id");
        }

        static void PrintEndOperationsCycle()
        {
            Console.WriteLine("\n========================\n");
        }
    }
}
