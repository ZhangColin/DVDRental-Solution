using System;
using System.Collections.Generic;

namespace DVDRenatal.Infrastructure.Repository {
    public class Paginated<T> {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// 当前页的数据
        /// </summary>
        public IEnumerable<T> Datas { get; private set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageTotal {
            get {
                return (int)Math.Ceiling((decimal)Total / PageSize);
            }
        }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPreviousPage {
            get {
                return this.PageIndex > 1;
            }
        }

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage {
            get {
                return this.PageIndex < this.PageTotal;
            }
        }

        public Paginated(IEnumerable<T> source, int pageIndex, int pageSize, int total) {
            if (source == null) {
                source = new List<T>();
            }

            this.Datas = source;

            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
        }
    }
}