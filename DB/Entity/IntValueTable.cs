using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB.Entity
{
    public class IntValueTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
