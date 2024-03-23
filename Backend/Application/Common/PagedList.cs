using Domain.RequestHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    //can use for any of my entities
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }
        public PagedList(List<T> items, int _TotalCount, int _PageNumber, int _PageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = _TotalCount,
                CurPage = _PageNumber,
                PageSize = _PageSize,
                TotalPage = (int)Math.Ceiling((double)_TotalCount / _PageSize)
            };
            AddRange(items);
        }

        // Hiển thị số lượng bản ghi tương ứng
        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query,
                    int PageNumber, int PageSize)
        {
            var Count = await query.CountAsync();
            var items = await query.Skip((PageNumber - 1) * PageSize)
                                   .Take(PageSize).ToListAsync();
            return new PagedList<T>(items, Count, PageNumber, PageSize);
        }

    }
}
