namespace MusicLibrary.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using MusicLibrary.Data;
    using MusicLibrary.Services.Models;

    public class ArtistsController : ApiController, IRESTController<ArtistDataModel>
    {
        private IMusicLibraryData data;

        public ArtistsController()
        {
            this.data = new MusicLibraryData();
        }

        public IHttpActionResult Get()
        {
            var artists = this.data.Artists.All().Select(ArtistDataModel.FromArtistEFModel);
            return Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            var artist = this.data.Artists.All().Where(x => x.Id == id).Select(ArtistDataModel.FromArtistEFModel).FirstOrDefault();
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        public IHttpActionResult Post([FromBody]ArtistDataModel artistModel)
        {
            var artist = artistModel.CreateArtist();
            data.Artists.Add(artist);
            data.SaveChanges();
            return Ok(artistModel);
        }

        public IHttpActionResult Put([FromBody]ArtistDataModel artistModel)
        {
            var artist = this.data.Artists.All().Where(x => x.Id == artistModel.Id).FirstOrDefault();
            if (artist == null)
            {
                return NotFound();
            }

            artistModel.UpdateArtist(artist);
            this.data.SaveChanges();
            return Ok(artistModel);
        }

        public IHttpActionResult Delete(int id)
        {
            var artist = this.data.Artists.All().Where(x => x.Id == id).FirstOrDefault();
            var artistModel = this.data.Artists.All().Where(x => x.Id == id).Select(ArtistDataModel.FromArtistEFModel).FirstOrDefault();
            if (artist == null)
            {
                return NotFound();
            }

            this.data.Artists.Delete(id);
            this.data.SaveChanges();

            return Ok(artistModel);
        }
    }
}