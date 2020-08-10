﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class VatRate
    {
        [Key]
        public int VatRateID { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Wartość")]
        public int Rate { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
