namespace DVDRental.Public.ApplicationService.ApplicationViews {
    /// <summary>
    /// 电影视图
    /// </summary>
    public class FilmView {
        public int Id { get; set; }
        /// <summary>
        /// 电影名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前是否已供出
        /// </summary>
        public bool IsCurrentlyOnLoan { get; set; }
        /// <summary>
        /// 是否在租借列表中
        /// </summary>
        public bool IsOnRentalList { get; set; }
    }
}