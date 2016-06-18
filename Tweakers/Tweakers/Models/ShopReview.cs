using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for ShopReview
    /// </summary>
    public class ShopReview : Review
    {
        public int SGeneral { get; set; }
        public string EGeneral { get; set; }
        public int SDelivery { get; set; }
        public string EDelivery { get; set; }
        public int SCustomerService { get; set; }
        public string ECustomerService { get; set; }

        #region Constructor
        /// <summary>
        /// Constructor for getting a ShopReview out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="shop"></param>
        /// <param name="date"></param>
        /// <param name="sGeneral"></param>
        /// <param name="eGeneral"></param>
        /// <param name="sDelivery"></param>
        /// <param name="eDelivery"></param>
        /// <param name="sCustomerService"></param>
        /// <param name="eCustomerService"></param>
        public ShopReview(int id, User user, Shop shop, DateTime date, int sGeneral, string eGeneral,
            int sDelivery, string eDelivery, int sCustomerService, string eCustomerService)
            : base(id, user, shop, date)
        {
            SGeneral = sGeneral;
            EGeneral = eGeneral;
            SDelivery = sDelivery;
            EDelivery = eDelivery;
            SCustomerService = sCustomerService;
            ECustomerService = eCustomerService;
        }

        /// <summary>
        /// Constructor for inserting a ShopReview into the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="shop"></param>
        /// <param name="date"></param>
        /// <param name="sGeneral"></param>
        /// <param name="eGeneral"></param>
        /// <param name="sDelivery"></param>
        /// <param name="eDelivery"></param>
        /// <param name="sCustomerService"></param>
        /// <param name="eCustomerService"></param>
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
        #endregion
    }
}