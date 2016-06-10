using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Models
{
    public class ShopReview : Review
    {
        public int SGeneral { get; set; }
        public string EGeneral { get; set; }
        public int SDelivery { get; set; }
        public string EDelivery { get; set; }
        public int SCustomerService { get; set; }
        public string ECustomerService { get; set; }

        public ShopReview(int id, User user, Shop shop, DateTime date, int sGeneral, string eGeneral)
            : base(id, user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery,
            string eDelivery)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            EDelivery = eDelivery;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, string eCustomerService,
            int sCustomerService)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SCustomerService = sCustomerService;
            ECustomerService = eCustomerService;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery,
            int sCustomerService)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            SCustomerService = sCustomerService;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery,
            string eDelivery, int sCustomerService)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            EDelivery = eDelivery;
            SCustomerService = sCustomerService;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery,
            int sCustomerService, string eCustomerService)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            SCustomerService = sCustomerService;
            ECustomerService = eCustomerService;
        }

        public ShopReview(User user, Shop shop, DateTime date, int sGeneral, string eGeneral, int sDelivery,
            string eDelivery, int sCustomerService, string eCustomerService)
            : base(user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            EDelivery = eDelivery;
            SCustomerService = sCustomerService;
            ECustomerService = eCustomerService;
        }
    }
}