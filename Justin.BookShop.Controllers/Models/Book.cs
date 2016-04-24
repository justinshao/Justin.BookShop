using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Justin.BookShop.Controllers.Models
{
    public class Book
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string MainTitle { get; set; }
        public string MinorTitle { get; set; }
        public decimal OfficialPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public DateTime PublicationDate { get; set; }
        public DateTime PrintingTime { get; set; }
        public decimal AccountPrice { get; set; }
        public string ISBN { get; set; }
        public string Picture { get; set; }
        public string Thumbnail { get; set; }
        public int PageNum { get; set; }
        public string Language { get; set; }
        public int SalesVolume { get; set; }
        public bool PromotedOnFront { get; set; }
        public bool OnSale { get; set; }
        public bool ShowOnBanner { get; set; }
        [AllowHtml]
        public string Introduction { get; set; }
        [AllowHtml]
        public string Catalog { get; set; }
        [AllowHtml]
        public string Digest { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime StorageTime { get; set; }
        public string _state { get; set; }

        public int[] AuthorIDs { get; set; }
        public string[] AuthorNames { get; set; }
        public int[] PressIDs { get; set; }
        public string[] PressNames { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}
