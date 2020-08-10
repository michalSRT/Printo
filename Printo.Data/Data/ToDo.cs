using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Printo.Data.Data
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Wybierz datę jeżeli dotyczy")]
        public DateTime? Date { get; set; }

        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
