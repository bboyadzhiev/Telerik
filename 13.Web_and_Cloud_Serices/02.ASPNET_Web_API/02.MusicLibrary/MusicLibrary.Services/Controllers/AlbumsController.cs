namespace MusicLibrary.Services.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using MusicLibrary.Data;
    using MusicLibrary.Models;
    using MusicLibrary.Services.Models;

    public class AlbumsController : ApiController, IRESTController<AlbumDataModel>
    {
        private IMusicLibraryData data;

        public AlbumsController()
        {
            this.data = new MusicLibraryData();
        }

        public IHttpActionResult Get()
        {
            var albums = this.data.Albums.All().Select(AlbumDataModel.FromAlbumEFModel).ToList();
            if (albums.Count() == 0)
            {
                return NotFound();
            }
            foreach (var model in albums)
            {
                var songs = this.data.Albums.All().Where(x => x.Id == model.Id).FirstOrDefault().Songs.AsQueryable();
                foreach (var song in songs)
                {
                    model.songTitles.Add(song.Title);
                    model.SongsIds.Add(song.Id);
                }

                var artists = this.data.Albums.All().Where(x => x.Id == model.Id).FirstOrDefault().Artists.AsQueryable();
                foreach (var artist in artists)
                {
                    model.artistNames.Add(artist.Name);
                    model.ArtistsIds.Add(artist.Id);
                }
            }

            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            var model = this.data.Albums.All().Where(x => x.Id == id).Select(AlbumDataModel.FromAlbumEFModel).FirstOrDefault();
            if (model == null)
            {
                return NotFound();
            }
            var songs = this.data.Albums.All().Where(x => x.Id == id).FirstOrDefault().Songs.ToList();
            foreach (var song in songs)
            {
                model.songTitles.Add(song.Title);
                model.SongsIds.Add(song.Id);
            }

            var artists = this.data.Albums.All().Where(x => x.Id == id).FirstOrDefault().Artists.ToList();
            foreach (var artist in artists)
            {
                model.artistNames.Add(artist.Name);
                model.ArtistsIds.Add(artist.Id);
            }
            return Ok(model);
        }

        public IHttpActionResult Post(AlbumDataModel model)
        {
            List<Artist> artists = new List<Artist>();
            Artist artist;
            for (int i = 0; i < model.ArtistsIds.Count(); i++)
            {
                artist = this.data.Artists.All().Where(x => x.Id == model.ArtistsIds[i]).FirstOrDefault();
                artists.Add(artist);
            }
            List<Song> songs = new List<Song>();
            Song song;
            for (int i = 0; i < model.SongsIds.Count(); i++)
            {
                song = this.data.Songs.All().Where(x => x.Id == model.SongsIds[i]).FirstOrDefault();
                songs.Add(song);
            }
            var album = model.CreateAlbum(songs, artists);
            data.Albums.Add(album);
            data.SaveChanges();
            return Ok(model);
        }

        public IHttpActionResult Put(AlbumDataModel model)
        {
            var album = this.data.Albums.All().Where(x => x.Id == model.Id).FirstOrDefault();
            if (album == null)
            {
                return NotFound();
            }

            List<Artist> artists = new List<Artist>();
            Artist artist;
            for (int i = 0; i < model.ArtistsIds.Count(); i++)
            {
                artist = this.data.Artists.All().Where(x => x.Id == model.ArtistsIds[i]).FirstOrDefault();
                artists.Add(artist);
                model.artistNames.Add(artist.Name);
            }
            List<Song> songs = new List<Song>();
            Song song;
            for (int i = 0; i < model.SongsIds.Count(); i++)
            {
                song = this.data.Songs.All().Where(x => x.Id == model.SongsIds[i]).FirstOrDefault();
                songs.Add(song);
                model.songTitles.Add(song.Title);
            }

            model.UpdateAlbum(album, songs, artists);
            this.data.SaveChanges();
            return Ok(model);
        }

        public IHttpActionResult Delete(int id)
        {
            var album = this.data.Albums.All().Where(x => x.Id == id).FirstOrDefault();
            var albumModel = this.data.Albums.All().Where(x => x.Id == id).Select(AlbumDataModel.FromAlbumEFModel).FirstOrDefault();
            if (album == null)
            {
                return NotFound();
            }

            this.data.Albums.Delete(id);
            this.data.SaveChanges();

            return Ok(albumModel);
        }
    }
}