//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Justin.BookShop.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.ShowOnBanner = false;
            this.Comments = new HashSet<BookComment>();
            this.Presses = new HashSet<Press>();
            this.Authors = new HashSet<Author>();
            this.CartItems = new HashSet<CartItem>();
            this.OrderItems = new HashSet<OrderItem>();
            this.StockHistories = new HashSet<BookStockHistory>();
            this.SpecialCategories = new HashSet<BookCategory>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string MainTitle { get; set; }
        public string MinorTitle { get; set; }
        public decimal OfficialPrice { get; set; }
        public Nullable<decimal> AccountPrice { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public System.DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string Picture { get; set; }
        public string Thumbnail { get; set; }
        public Nullable<System.DateTime> PrintingTime { get; set; }
        public int PageNum { get; set; }
        public string Language { get; set; }
        public Nullable<int> SalesVolume { get; set; }
        public string Introduction { get; set; }
        public string Catalog { get; set; }
        public string Digest { get; set; }
        public Nullable<System.DateTime> AddedTime { get; set; }
        public Nullable<System.DateTime> StorageTime { get; set; }
        public bool OnSale { get; set; }
        public bool PromotedOnFront { get; set; }
        public bool ShowOnBanner { get; set; }
        public EntityState State { get; set; }
    
        public virtual ICollection<BookComment> Comments { get; set; }
        public virtual PromotionInfo Promotion { get; set; }
        public virtual BookCategory Category { get; set; }
        public virtual ICollection<Press> Presses { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual BookStock Stock { get; set; }
        public virtual ICollection<BookStockHistory> StockHistories { get; set; }
        public virtual ICollection<BookCategory> SpecialCategories { get; set; }
    }
}
