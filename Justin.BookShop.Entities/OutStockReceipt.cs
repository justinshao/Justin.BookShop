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
    
    public partial class OutStockReceipt
    {
        public OutStockReceipt()
        {
            this.IsAudited = false;
            this.Details = new HashSet<OutStockReceiptDetail>();
        }
    
        public System.Guid ID { get; set; }
        public string NO { get; set; }
        public decimal Freight { get; set; }
        public string Remark { get; set; }
        public System.DateTime SubmitDate { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public bool IsAudited { get; set; }
        public Nullable<System.Guid> OrderID { get; set; }
    
        public virtual User SubmittedBy { get; set; }
        public virtual User AuditedBy { get; set; }
        public virtual ICollection<OutStockReceiptDetail> Details { get; set; }
        public virtual Order Order { get; set; }
        public virtual OutStockReceipt InvalidReceipt { get; set; }
        public virtual OutStockReceipt BeforeVoidReceipt { get; set; }
    }
}