namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        [Key]
        public int Pro_ID { get; set; }
        [Display(Name = "Thể loại")]
        public int? Cat_ID { get; set; }
        [Display(Name = "Tác giả")]
        public int? Aut_ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Sách")]
        public string Pro_Name { get; set; }
        [Display(Name = "Số lượng")]
        public int? Pro_Quantity { get; set; }

        [StringLength(200)]
        [Display(Name = "Hình ảnh")]
        public string Pro_Img { get; set; }
        [Display(Name = "Đơn giá")]
        public decimal? Pro_Price { get; set; }
        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string Pro_Status { get; set; }
        [Display(Name = "Chi tiết")]
        [Column(TypeName = "text")]
        public string Pro_Description { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
