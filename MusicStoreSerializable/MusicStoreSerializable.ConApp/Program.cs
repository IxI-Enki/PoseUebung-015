namespace MusicStoreSerializable.ConApp
{
        internal class Program
        {
                static void Main( )
                {
                        Console.WriteLine( "MusicStore with serializable" );

                        Logic.Contracts.IMusicStoreContext context = Logic.DataContext.Factory.CreateMusicStoreContext( );
                        Console.WriteLine( $"Loaded {context.GenreSet.Count} genres." );
                        Console.WriteLine( $"Loaded {context.ArtistSet.Count} artists." );
                        Console.WriteLine( $"Loaded {context.AlbumSet.Count} albums." );
                        Console.WriteLine( $"Loaded {context.TrackSet.Count} tracks." );

                        /*
                       //    if(context.GenreSet.Any( g => g.Name != "MyGenre" ))
                       //    {
                       //            var genre = new Logic.Models.Genre
                       //            {
                       //                    Name = "MyGenre"
                       //            };
                       //            context.GenreSet.Add( genre );
                       //    }
                       //
                       // Console.WriteLine( "Saving changes..." );
                       // context.SaveChanges( );
                       // Console.WriteLine( "Done." );
                       //
                       */

                        Console.ReadLine();
                }
        }
}
