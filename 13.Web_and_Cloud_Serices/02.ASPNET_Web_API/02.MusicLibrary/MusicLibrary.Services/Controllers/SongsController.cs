using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicLibrary.Data;
using MusicLibrary.Services.Models;

namespace MusicLibrary.Services.Controllers
{
    public class SongsController : ApiController, IRESTController<SongDataModel>
    {
        private IMusicLibraryData data;

        public SongsController()
        {
            this.data = new MusicLibraryData();
        }
        public IHttpActionResult Get()
        {
            var songs = this.data.Songs.All().Select(SongDataModel.FromSongEFModel);
            return Ok(songs);
        }

        public IHttpActionResult Get(int id)
        {
            var song = this.data.Songs.All().Where(x => x.Id == id).Select(SongDataModel.FromSongEFModel).FirstOrDefault();
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        public IHttpActionResult Post(SongDataModel model)
        {
            var song = model.CreateSong();
            data.Songs.Add(song);
            data.SaveChanges();
            return Ok(model);
        }

        public IHttpActionResult Put(SongDataModel model)
        {
            var song = this.data.Songs.All().Where(x => x.Id == model.Id).FirstOrDefault();
            if (song == null)
            {
                return NotFound();
            }

            model.UpdateSong(song);
            this.data.SaveChanges();
            return Ok(model);
        }

        public IHttpActionResult Delete(int id)
        {
            var song = this.data.Songs.All().Where(x => x.Id == id).FirstOrDefault();
            if (song == null)
            {
                return NotFound();
            }

            this.data.Songs.Delete(id);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
