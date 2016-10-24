using System;
using DVDRenatal.Infrastructure.Domain;

namespace DVDRental.Catalogue.Catalogue {
    /// <summary>
    /// Catalogue：类目
    /// 电影
    /// </summary>
    public class Film: Entity<int> {
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime ReleaseDate { get; private set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 电影分级
        /// </summary>
        public string Certification { get; set; }

        public Film(DateTime releaseDate, string title) {
            ReleaseDate = releaseDate;
            Title = title;
        }

        private Film() {
        }
    }
}