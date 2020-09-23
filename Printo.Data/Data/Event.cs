using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Printo.Data.Data
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Kolor")]
        public string BackgroundColor { get; set; }
        [Display(Name = "Start")]
        public DateTime Start { get; set; }
        [Display(Name = "Koniec")]
        public DateTime? End { get; set; }
        [Display(Name = "Cały dzień")]
        public bool AllDay { get; set; }
    }
}
