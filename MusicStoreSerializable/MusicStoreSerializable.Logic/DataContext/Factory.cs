using MusicStoreSerializable.Logic.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicStoreSerializable.Logic.DataContext
{
        /// <summary>
        /// Factory class to create instances of IMusicStoreContext.
        /// </summary>
        public static class Factory
        {
                /// <summary>
                /// Creates an instance of IMusicStoreContext.
                /// </summary>
                /// <returns>An instance of IMusicStoreContext.</returns>
                public static IMusicStoreContext CreateMusicStoreContext( )
                {
                        MusicStoreContext? result = null;

                        if(File.Exists( MusicStoreContext.DbFile ))
                        {
                                string json = File.ReadAllText( MusicStoreContext.DbFile );
                                result = JsonSerializer.Deserialize<MusicStoreContext>( json , MusicStoreContext.JsonOptions );
                                result?.CreateRelationships( );
                        }
                        else
                        {
                                result = new( )
                                {
                                        GenreSet = DataLoader.LoadGenresFromCsv( "Data/Genres.csv" ) ,
                                        AlbumSet = DataLoader.LoadAlbumsFromCsv( "Data/Albums.csv" ) ,
                                        ArtistSet = DataLoader.LoadArtistsFromCsv( "Data/Artists.csv" ) ,
                                        TrackSet = DataLoader.LoadTracksFromCsv( "Data/Tracks.csv" )
                                };
                        }
                        return result!;
                }
        }
}
