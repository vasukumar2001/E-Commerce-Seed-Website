
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace IMS_Project.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Order
{

    public Order()
    {

        this.OrderDetails = new HashSet<OrderDetail>();

    }


    public int OrderID { get; set; }

    public int CustomerID { get; set; }

    public Nullable<int> PaymentID { get; set; }

    public Nullable<int> ShippingID { get; set; }

    public Nullable<int> Discount { get; set; }

    public Nullable<int> Taxes { get; set; }

    public Nullable<int> TotalAmount { get; set; }

    public Nullable<System.DateTime> OrderDate { get; set; }

    public Nullable<bool> DIspatched { get; set; }

    public Nullable<System.DateTime> DispatchedDate { get; set; }

    public Nullable<bool> Shipped { get; set; }

    public Nullable<System.DateTime> ShippingDate { get; set; }

    public Nullable<bool> Deliver { get; set; }

    public Nullable<System.DateTime> DeliveryDate { get; set; }

    public string Notes { get; set; }

    public Nullable<bool> CancelOrder { get; set; }

    public Nullable<bool> isCompleted { get; set; }

    public Nullable<int> StatusId { get; set; }



    public virtual Customer Customer { get; set; }

    public virtual Payment Payment { get; set; }

    public virtual ShippingDetail ShippingDetail { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    public virtual Status Status1 { get; set; }

}

}
