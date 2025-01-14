using Microsoft.AspNetCore.Mvc;
using MusicStoreSerializable.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicStoreSerializable.WebAPI.Controllers
{
        [Route( "api/[controller]" )]
        [ApiController]
        public class GenresController : ControllerBase
        {
                // GET: api/<GenresController>
                [HttpGet]
                public IEnumerable<Logic.Models.Genre> Get( )
                {
                        var context = Logic.DataContext.Factory.CreateMusicStoreContext( );
                        return context.GenreSet;
                }

                // GET api/<GenresController>/5
                [HttpGet( "{id}" )]
                public Logic.Models.Genre? Get( int id )
                {
                        var context = Logic.DataContext.Factory.CreateMusicStoreContext( );

                        var result = context.GenreSet.FirstOrDefault( g => g.Id == id );

                        return result;
                        // return context.GenreSet.FirstOrDefault( g => g.Id == id );
                }

                // POST api/<GenresController>
                [HttpPost]
                public void Post( [FromBody] Logic.Models.Genre item )
                {
                        var context = Logic.DataContext.Factory.CreateMusicStoreContext( );

                        context.GenreSet.Add( item );
                        context.SaveChanges( );
                }

                // PUT api/<GenresController>/5
                [HttpPut( "{id}" )]
                public void Put( int id , [FromBody] Logic.Models.Genre item )
                {
                        var context = Logic.DataContext.Factory.CreateMusicStoreContext( );
                        var updateItem = context.GenreSet.FirstOrDefault( e => e.Id == id );

                        if(updateItem != null)
                        {
                                updateItem.CopyProperties( item );
                                context.SaveChanges( );
                        }

                }

                // DELETE api/<GenresController>/5
                [HttpDelete( "{id}" )]
                public void Delete( int id )
                {
                        var context = Logic.DataContext.Factory.CreateMusicStoreContext( );
                        var deleteItem = context.GenreSet.FirstOrDefault( g => g.Id == id );
                        if(deleteItem != null)
                        {
                                context.GenreSet.Remove( deleteItem );
                                context.SaveChanges( );
                        }

                }
        }
}
