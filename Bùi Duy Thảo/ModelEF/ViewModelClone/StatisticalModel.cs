using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ViewModelClone
{
    public class StatisticalModel
    {
        [Required]
        public int? ProID { get; set; }
        public string CatName { get; set; }
        public string AutName { get; set; }
        public string ProName { get; set; }
        public string ProImg { get; set; }
        public decimal? ProPrice { get; set; }
        public int? ProQuatity { get; set; }
    }
}
