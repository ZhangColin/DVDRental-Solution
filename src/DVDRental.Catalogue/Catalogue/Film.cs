using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Catalogue.Catalogue {
    /// <summary>
    /// 电影
    /// </summary>
    public class Film: Entity<int> {
        public DateTime ReleaseDate { get; private set; }
        public string Title { get; set; }
        public string Certification { get; set; }

        public Film(DateTime releaseDate, string title) {
            ReleaseDate = releaseDate;
            Title = title;
        }

        private Film() {
        }
    }
}