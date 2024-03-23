using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Extensions
{
    public static class ProductExtension
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string OrderBy)
        {
            if (string.IsNullOrWhiteSpace(OrderBy)) return query.OrderBy(p => p.Name);

            query = OrderBy switch
            {
                "priceAsc" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name)
            };

            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string KeyWord)
        {
            if (string.IsNullOrEmpty(KeyWord)) return query;

            //Chuẩn hóa chuỗi
            string lowerCaseSearchKeyWord = KeyWord.Trim().ToLower();

            query = query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchKeyWord));

            return query;
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> query, string CategoryType)
        {
            var CategoryTypeList = new List<string>();

            if (!string.IsNullOrEmpty(CategoryType))
                CategoryTypeList.AddRange(CategoryType.Split(",").ToList());

            query = query.Where(p => CategoryTypeList.Count == 0 || CategoryTypeList.Contains(p.CategoryId.ToString()));

            return query;
        }
    }
}
