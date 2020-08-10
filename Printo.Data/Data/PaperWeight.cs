using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class PaperWeight
    {
        [Key]
        public int PaperWeightID { get; set; }

        [Required(ErrorMessage = "Gramatura jest wymagana")]
        [Display(Name = "Gramatura")]
        public string Grammature { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
