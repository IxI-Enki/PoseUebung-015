using MusicStoreSerializable.Logic.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicStoreSerializable.Logic.DataContext
{
        /// <summary>
        /// Represents the data context for the Music Store application.
        /// </summary>
        [Serializable]
        internal sealed class MusicStoreContext : IMusicStoreContext
        {
                #region fields

                public static readonly string DbFile = "MusicStore.json";
                public static readonly JsonSerializerOptions JsonOptions = new( )
                {
                        ReferenceHandler = ReferenceHandler.Preserve ,
                        WriteIndented = true
                };

                #endregion fields

                #region Properties

                /// <summary>
                /// Gets or sets the collection of genres.
                /// </summary>
                public DbSet<Models.Genre> GenreSet { get; set; } = [];

                /// <summary>
                /// Gets or sets the collection of artists.
                /// </summary>
                public DbSet<Models.Artist> ArtistSet { get; set; } = [];

                /// <summary>
                /// Gets or sets the collection of albums.
                /// </summary>
                public DbSet<Models.Album> AlbumSet { get; set; } = [];

                /// <summary>
                /// Gets or sets the collection of tracks.
                /// </summary>
                public DbSet<Models.Track> TrackSet { get; set; } = [];

                #endregion Properties

                #region methods

                /// <summary>
                /// Creates relationships between entities.
                /// </summary>
                internal void CreateRelationships( )
                {
                        AlbumSet.ForEach( a =>
                        {
                                a.Artist = ArtistSet.FirstOrDefault( art => art.Id == a.ArtistId );
                                a.Tracks = TrackSet.Where( t => t.AlbumId == a.Id ).ToList( );
                        } );
                        GenreSet.ForEach( g =>
                        {
                                g.Tracks = TrackSet.Where( t => t.GenreId == g.Id ).ToList( );
                        } );
                        TrackSet.ForEach( t =>
                        {
                                t.Album = AlbumSet.FirstOrDefault( a => a.Id == t.AlbumId );
                                t.Genre = GenreSet.FirstOrDefault( g => g.Id == t.GenreId );
                        } );
                        ArtistSet.ForEach( art =>
                        {
                                art.Albums = AlbumSet.Where( a => a.ArtistId == art.Id ).ToList( );
                        } );
                }

                /// <summary>
                /// Validates relationships between entities.
                /// </summary>
                internal void ValidateRelationships( )
                {
                        AlbumSet.ForEach( a =>
                        {
                                if(a.Artist == default)
                                {
                                        throw new InvalidOperationException( $"Artist for Album not found {a.Title}." );
                                }
                        } );
                        TrackSet.ForEach( t =>
                        {
                                if(t.Album == default)
                                {
                                        throw new InvalidOperationException( $"Album for Track not found {t.Title}." );
                                }
                                if(t.Genre == default)
                                {
                                        throw new InvalidOperationException( $"Genre for Track not found {t.Genre}." );
                                }
                        } );
                        ArtistSet.ForEach( a =>
                        {
                                a.Albums.ForEach( al =>
                                {
                                        if(al.Artist == default)
                                        {
                                                throw new InvalidOperationException( $"Artist for Album not found {al.Title}." );
                                        }
                                        if(ArtistSet.GroupBy( a => a.Name.ToLower( ) ).Count( ) != ArtistSet.Count)
                                        {
                                                throw new InvalidOperationException( $"Artist {a.Name} is multiple times in Set." );
                                        }
                                        if(GenreSet.DistinctBy( g => g.Name.ToLower( ) ).Count( ) != GenreSet.Count( ))
                                        {
                                                throw new InvalidOperationException( $"Artist {a.Name} is multiple times in Set." );
                                        }
                                } );
                        } );
                        //    ArtistSet.ForEach( a =>
                        //    {
                        //    if(a.Name.Count( ) != 1)
                        //    throw new InvalidOperationException( $"Artist {a.Name} is multiple times in Set." );
                        //    } );
                }

                /// <summary>
                /// Dissolves relationships between entities.
                /// </summary>
                internal void DissolvingRelationships( )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Saves changes to the data context.
                /// </summary>
                public void SaveChanges( )
                {
                        CreateRelationships( );

                        ValidateRelationships( );
                        File.WriteAllText( DbFile , JsonSerializer.Serialize<MusicStoreContext>( this , JsonOptions ) );

                }

                #endregion methods
        }
}
