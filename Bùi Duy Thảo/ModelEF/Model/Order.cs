namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        [Key]
        public int Ord_ID { get; set; }

        public int? Cus_ID { get; set; }

        public decimal? Ord_TotalMoney { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ord_Date { get; set; }

        [StringLength(50)]
        public string Ord_Status { get; set; }

        [StringLength(200)]
        public string Ord_Description { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
