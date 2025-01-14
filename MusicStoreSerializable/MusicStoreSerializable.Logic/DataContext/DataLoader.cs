namespace MusicStoreSerializable.Logic.DataContext
{
    internal static class DataLoader
    {
        #region methods

        /// <summary>
        /// Loads genres from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of genres.</returns>
        public static DbSet<Models.Genre> LoadGenresFromCsv(string path)
        {
            var result = new DbSet<Models.Genre>();
            
            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Models.Genre
                       {
                           Id = Convert.ToInt32(d[0]),
                           Name = d[1]
                       }));
            return result;
        }

        /// <summary>
        /// Loads artists from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of artists.</returns>
        public static DbSet<Models.Artist> LoadArtistsFromCsv(string path)
        {
            var result = new DbSet<Models.Artist>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Models.Artist
                       {
                           Id = Convert.ToInt32(d[0]),
                           Name = d[1]
                       }));
            return result;
        }

        /// <summary>
        /// Loads albums from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of albums.</returns>
        public static DbSet<Models.Album> LoadAlbumsFromCsv(string path)
        {
            var result = new DbSet<Models.Album>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Models.Album
                       {
                           Id = Convert.ToInt32(d[0]),
                           Title = d[1],
                           ArtistId = Convert.ToInt32(d[2]),
                       }));
            return result;
        }

        /// <summary>
        /// Loads tracks from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of tracks.</returns>
        public static DbSet<Models.Track> LoadTracksFromCsv(string path)
        {
            var result = new DbSet<Models.Track>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Models.Track
                       {
                           Id = Convert.ToInt32(d[0]),
                           Title = d[1],
                           AlbumId = Convert.ToInt32(d[2]),
                           GenreId = Convert.ToInt32(d[3]),
                           Composer = d[4],
                           Milliseconds = Convert.ToInt32(d[5]),
                           Bytes = Convert.ToInt32(d[6]),
                           UnitPrice = Convert.ToDouble(d[7]),
                       }));
            return result;
        }

        #endregion methods
    }
}
