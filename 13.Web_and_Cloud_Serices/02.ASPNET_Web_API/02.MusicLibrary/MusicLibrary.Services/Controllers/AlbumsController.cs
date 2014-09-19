namespace MusicLibrary.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using MusicLibrary.Data;
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
            var albums = this.data.Albums.All().Select(AlbumDataModel.FromAlbumEFModel);
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.data.Albums.All().Where(x => x.Id == id).Select(AlbumDataModel.FromAlbumEFModel).FirstOrDefault();
            if (album == null)
            {
                return NotFound();
            }
            return Ok(album);
        }

        public IHttpActionResult Post(AlbumDataModel model)
        {
            var album = model.CreateAlbum();
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

            model.UpdateAlbum(album);
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