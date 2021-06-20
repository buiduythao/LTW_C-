namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Cus_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string Cus_UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string Cus_Pass { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Cus_Name { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Trạng thái")]
        public string Cus_Status { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Cus_Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]
        public string Cus_Phone { get; set; }

        [StringLength(200)]
        [Display(Name = "Địa chỉ")]
        public string Cus_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
