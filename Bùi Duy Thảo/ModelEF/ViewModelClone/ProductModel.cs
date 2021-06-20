using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModelClone
{
    public class ProductModel
    {
        [Required]
        public int ProID { get; set; }
        public string CatName { get; set; }
        public string AutName { get; set; }
        public string ProName { get; set; }
        public string ProImg { get; set; }
        public int? ProQuantity { get; set; }
        public decimal? ProPrice { get; set; }
        public string ProStatus { get; set; }
        public string ProDescription { get; set; }
    }
}
