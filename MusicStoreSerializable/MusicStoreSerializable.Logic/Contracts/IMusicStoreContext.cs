using MusicStoreSerializable.Logic.DataContext;
using MusicStoreSerializable.Logic.Models;

namespace MusicStoreSerializable.Logic.Contracts
{
    public interface IMusicStoreContext
    {
        DbSet<Album> AlbumSet { get; }
        DbSet<Artist> ArtistSet { get; }
        DbSet<Genre> GenreSet { get; }
        DbSet<Track> TrackSet { get; }

        void SaveChanges();
    }
}