using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Models
{
    public static class Dictionaries
    {
        public static Dictionary<int, Product> Products =
            new Dictionary<int, Product>();
        public static Dictionary<int, Shop> Shops =
            new Dictionary<int, Shop>();
        public static Dictionary<int, Category> Categories =
            new Dictionary<int, Category>();
        public static Dictionary<int, ShopPrice> ShopPrices =
            new Dictionary<int, ShopPrice>();
        public static Dictionary<int, ProductReview> ProductReviews =
            new Dictionary<int, ProductReview>();
        public static Dictionary<int, Asset> Assets =
            new Dictionary<int, Asset>();
        public static Dictionary<int, ProductSpecification> ProductSpecifications =
            new Dictionary<int, ProductSpecification>();
        public static Dictionary<int, ProductPicture> ProductPictures =
            new Dictionary<int, ProductPicture>();
        public static Dictionary<int, UserList> UserLists =
            new Dictionary<int, UserList>();
        public static Dictionary<int, User> Users =
            new Dictionary<int, User>();
    }
}