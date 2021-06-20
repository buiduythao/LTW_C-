using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModelClone
{
    public class OrderDetailModel
    {
        [Required]
        public int OrdDetID { get; set; }
        public int? OrdID { get; set; }
        public decimal? ProPrice { get; set; }
        public string ProName { get; set; }
        public int? OrdDetQuantity { get; set; }
    }
}
