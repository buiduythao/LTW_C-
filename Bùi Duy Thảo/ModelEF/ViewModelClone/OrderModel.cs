using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModelClone
{
    public class OrderModel
    {
        [Required]
        public int OrdID { get; set; }
        public string CusName { get; set; }
        public string CusAddress { get; set; }
        public decimal? OrdTotal { get; set; }
        public DateTime OrdDate { get; set; }

        public string OrdStatus { get; set; }
        public string OrdDescription { get; set; }
    }
}
