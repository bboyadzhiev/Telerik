namespace MusicLibrary.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using MusicLibrary.Models;
    using Newtonsoft.Json.Linq;
   

    internal static class Program
    {
        private static string baseUrl = "http://localhost:4196/api";
        private const string ARTISTS = "/artists";
        private const string ALBUMS = "/albums";
        private const string SONGS = "/songs";

        private static void Main(string[] args)
        {
            string inputLine = "";

            Requester reqConsumer = new Requester(baseUrl);

            while (true)
            {
                PrintMenu();
                Console.Write("Choice: ");
                inputLine = Console.ReadLine().ToLower();

                if (inputLine == "4")
                {
                    break;
                }
                ExecuteMenuChoice(inputLine, reqConsumer);

                PrintEndOperationsCycle();
            }
        }

        private static void ExecuteMenuChoice(string inputChoice, Requester reqConsumer)
        {
            switch (inputChoice)
            {
                case "1":
                    {
                        string controller = ARTISTS;
                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();
                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterArtist, UpdateArtist);
                    }
                    break;

                case "2":
                    {
                        string controller = ALBUMS;

                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();

                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterAlbum, UpdateAlbum);
                    } break;
                case "3":
                    {
                        string controller = SONGS;

                        PrintCurrentPath(controller);

                        PrintCRUDOperationsChoices();

                        inputChoice = Console.ReadLine();

                        ExecuteCRUDChoice(inputChoice, reqConsumer, controller, EnterSong, UpdateSong);
                    } break;

                default: Console.WriteLine("Error, incorrect digit."); break;
            }
        }

        private static void ExecuteCRUDChoice(string inputChoice, Requester reqConsumer, string controller,
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
            //var oldArtist = GetArtistById(reqConsumer);
            Artist oldArtist = GetById<Artist>(reqConsumer, ARTISTS);
            Console.Write("Enter new name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new country(optional): ");
            string country = Console.ReadLine();
            Console.Write("Enter new birth date(optional): ");
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
                Id = oldArtist.Id,
                Name = name,
                Country = country,
                DateOfBirth = date
            };

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Artist>(newArtist, controller, oldArtist.Id.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Artist>(newArtist, controller, oldArtist.Id.ToString());
                return sent;
            }
        }

        private static string EnterArtist(Requester reqConsumer, string controller)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter country(optional): ");
            string country = Console.ReadLine();
            Console.Write("Enter birth date(optional): ");
            DateTime date = DateTime.Now;
            try
            {
                date = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
            }

            Artist newArtist = CreateArtistObject(name, country, date);

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

        private static Artist CreateArtistObject(string name, string country, DateTime date)
        {
            Artist newArtist = new Artist()
            {
                //Id = id,
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
            var artists = new List<Artist>();
            var artistIds = new List<int>();
            Artist artist;
            do
            {
                Console.WriteLine("Add atuhor by ID:");
                //artist = GetArtistById(reqConsumer);
                artist = GetById<Artist>(reqConsumer, ARTISTS);
                if (artist != null)
                {

                    artists.Add(artist);
                    artistIds.Add(artist.Id);
                }

            } while (artist != null);

            if (artistIds.Count == 0)
            {
                return "Every album must have at least one artist!";
            }

            var songIds = new List<int>();
            var songs = new List<Song>();
            Song song;
            do
            {
                Console.WriteLine("Add song by ID:");
                //song = GetSongById(reqConsumer);
                song = GetById<Song>(reqConsumer, SONGS);
                if (song != null)
                {
                    songs.Add(song);
                    songIds.Add(song.Id);
                }
            } while (song != null);

            if (songs.Count == 0)
            {
                return "Every album must have at least one song!";
            }

            var newAlbum = new Album()
            {
                Title = title,
                Producer = producer,
                Year = releaseDate,
                Artists = artists,
                Songs = songs
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
            //var oldAlbum = GetAlbumById(reqConsumer);
            var oldAlbum = GetById<Album>(reqConsumer, ALBUMS);
            Console.WriteLine("Enter new title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter new producer: ");
            string producer = Console.ReadLine();
            Console.WriteLine("Enter new  release date: ");
            DateTime releaseDate = DateTime.Now;
            try
            {
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
            }
            var artists = new List<Artist>();
            var artistIds = new List<int>();
            Artist artist;
            do
            {
                Console.WriteLine("Add atuhor by ID:");
                //artist = GetArtistById(reqConsumer);
                artist = GetById<Artist>(reqConsumer, ARTISTS);
                if (artist != null)
                {

                    artists.Add(artist);
                    artistIds.Add(artist.Id);
                }

            } while (artist != null);

            if (artists.Count == 0)
            {
                return "Every album must have at least one artist";
            }

            var songIds = new List<int>();
            var songs = new List<Song>();
            Song song;
            do
            {
                Console.WriteLine("Add song by ID:");
                //song = GetSongById(reqConsumer);
                song = GetById<Song>(reqConsumer, SONGS);
                if (song != null)
                {
                    songs.Add(song);
                    songIds.Add(song.Id);
                }
            } while (song != null);

            if (songs.Count == 0)
            {
                return "Every album must have at least one song";
            }

            var newAlbum = new Album()
             {
                 Id = oldAlbum.Id,
                 Title = title,
                 Producer = producer,
                 Year = releaseDate,
                 Artists = artists,
                 Songs = songs
             };

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Album>(newAlbum, controller, oldAlbum.Id.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Album>(newAlbum, controller, oldAlbum.Id.ToString());
                return sent;
            }
        }

        private static string EnterSong(Requester reqConsumer, string controller)
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            Console.Write("Enter genre(optional): ");
            string genreString = Console.ReadLine();
            Console.Write("Enter release date(optional): ");
            DateTime releaseDate = DateTime.Now;
            Genre genre = Genre.Undefined;
            try
            {
                genre = (Genre)Enum.Parse(typeof(Genre), genreString, true);
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
            }
            Console.WriteLine("Add artist");
            //var artist = GetArtistById(reqConsumer);
            var artist = GetById<Artist>(reqConsumer, ARTISTS);
            if (artist == null)
            {
                return "Artist cannot be null - ABORTING";
            }
            Song newSong = new Song()
            {
                Title = title,
                Genre = genre,
                Year = releaseDate,
                ArtistId = artist.Id
            };

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
            //var oldSong = GetSongById(reqConsumer);
            var oldSong = GetById<Song>(reqConsumer, SONGS);
            Console.Write("Enter new title: ");
            string title = Console.ReadLine();
            Console.Write("Enter new genre: ");
            string genreString = Console.ReadLine();
            Console.Write("Enter new release date: ");
            DateTime releaseDate = DateTime.Now;
            Genre genre = Genre.Undefined;
            try
            {
                genre = (Genre)Enum.Parse(typeof(Genre), genreString, true);
                releaseDate = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
            }

            Console.WriteLine("Add artist");

            //var artist = GetArtistById(reqConsumer);
            var artist = GetById<Artist>(reqConsumer, ARTISTS);
            if (String.IsNullOrEmpty(artist.Name))
            {
                return "Artist cannot be null - ABORTING";
            }

            Song newSong = new Song()
            {
                Title = title,
                Genre = genre,
                Year = releaseDate,
                ArtistId = artist.Id
            };

            Console.WriteLine("As Json(1) Or XML(2)? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var sent = reqConsumer.UpdateAsJson<Song>(newSong, controller, oldSong.Id.ToString());
                return sent;
            }
            else
            {
                var sent = reqConsumer.UpdateAsXML<Song>(newSong, controller, oldSong.Id.ToString());
                return sent;
            }
        }

        // TODO WebAPI Controllers update is needed for this
        private static T GetByName<T>(Requester reqConsumer, string endpoint) where T : class
        {
            Console.Write("Enter name/title:");
            string entityName = Console.ReadLine();
            if (String.IsNullOrEmpty(entityName))
            {
                Console.WriteLine("Aborting search!");
                return null;
            }

            JObject jEntity = reqConsumer.ReadJobject(endpoint, entityName);
            JToken checkEntity;
            if (jEntity.TryGetValue("Name", out checkEntity) || jEntity.TryGetValue("Title", out checkEntity))
            {
                var entity = jEntity.ToObject<T>();
                if (entity.GetType() == typeof(Artist))
                {
                    var artist = entity as Artist;
                    Console.WriteLine("Artist found: {0}", artist.Name);
                    return entity;
                }
                if (entity.GetType() == typeof(Song))
                {
                    var song = entity as Song;
                    Console.WriteLine("Song found: {0}", song.Title);
                    return entity;
                }
                if (entity.GetType() == typeof(Album))
                {
                    var album = entity as Album;
                    Console.WriteLine("Album found: {0}", album.Title);
                    return entity;
                }
                return default(T);
            }
            Console.WriteLine("Not found!");

            return default(T);
        }

        private static T GetById<T>(Requester reqConsumer, string endpoint)
        {
            Console.Write("Enter id: ");
            string entityId = Console.ReadLine();
            if (String.IsNullOrEmpty(entityId))
            {
                Console.WriteLine("ID not found!");
                return default(T);
            }
            JObject jEntity = reqConsumer.ReadJobject(endpoint, entityId);
            JToken checkEntity;
            if (jEntity.TryGetValue("Id", out checkEntity))
            {
                var entity = jEntity.ToObject<T>();
                if (entity.GetType() == typeof(Artist))
                {
                    var artist = entity as Artist;
                    Console.WriteLine("Artist found: {0}", artist.Name);
                }
                if (entity.GetType() == typeof(Song))
                {
                    var song = entity as Song;
                    Console.WriteLine("Song found: {0}", song.Title);
                }
                if (entity.GetType() == typeof(Album))
                {
                    var album = entity as Album;
                    Console.WriteLine("Album found: {0}", album.Title);
                }
                return entity;
            }
            Console.WriteLine("Not found!");
            return default(T);
        }

        private static Artist GetArtistById(Requester reqConsumer)
        {
            Console.Write("Enter an Artist id: ");
            var artistId = Console.ReadLine();

            if (String.IsNullOrEmpty(artistId))
            {
                Console.WriteLine("Aborting search!");
                return null;
            }
            JObject jArtist = reqConsumer.ReadJobject(ARTISTS, artistId);
            JToken checkId;
            if (jArtist.TryGetValue("Id", out checkId))
            {
                var artist = jArtist.ToObject<Artist>();
                Console.WriteLine("Artist found: {0}", artist.Name);
                return artist;
            }
            Console.WriteLine("Artist not found!");
            return null;
        }

        private static Song GetSongById(Requester reqConsumer)
        {
            Console.Write("Enter Song id: ");
            var songId = Console.ReadLine();
            if (String.IsNullOrEmpty(songId))
            {
                Console.WriteLine("Aborting search!");
                return null;
            }
            JObject jSong = reqConsumer.ReadJobject(SONGS, songId);
            JToken checkId;
            if (jSong.TryGetValue("Id", out checkId))
            {
                var song = jSong.ToObject<Song>();
                Console.WriteLine("Song found: {0}", song.Title);
                return song;
            }
            Console.WriteLine("Song not found!");
            return null;
        }

        private static Album GetAlbumById(Requester reqConsumer)
        {
            Console.Write("Enter Album id: ");
            var albumId = Console.ReadLine();
            if (String.IsNullOrEmpty(albumId))
            {
                Console.WriteLine("Aborting search!");
                return null;
            }
            JObject jAlbum = reqConsumer.ReadJobject(ALBUMS, albumId);
            JToken checkId;
            if (jAlbum.TryGetValue("Id", out checkId))
            {
                var album = jAlbum.ToObject<Album>();
                Console.WriteLine("Album found: {0}", album.Title);
                return album;
            }
            Console.WriteLine("Album not found!");
            return null;
        }

        private static string PrintCurrentPath(string controller)
        {
            string path = baseUrl + controller;
            Console.WriteLine(path);

            return path;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Enter corresponding number for each option:\n1. Artist\n2. Album\n3. Song\n4. End");
        }

        private static void PrintCRUDOperationsChoices()
        {
            Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete\n5. Read with Id");
        }

        private static void PrintEndOperationsCycle()
        {
            Console.WriteLine("\n========================\n");
        }
    }
}