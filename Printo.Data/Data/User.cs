using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Wpisz login")]
        [MinLength(3, ErrorMessage = "Minimalna długość loginu to 3 znaki.")]
        [MaxLength(20, ErrorMessage = "Maksymalna długość loginu to 20 znaków.")]
        [Display(Name = "Login użytkownika")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Wpisz hasło")]
        [MinLength(3, ErrorMessage = "Minimalna długość hasła to 3 znaki.")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę lub imię i nazwisko użytkownika")]
        [MinLength(3, ErrorMessage = "Minimalna długość to 3 znaki.")]
        [MaxLength(20, ErrorMessage = "Maksymalna długość to 20 znaków.")]
        [Display(Name = "Nazwa użytkownika")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? AddedUserID { get; set; }
        public int? UpdatedUserID { get; set; }

        [Required(ErrorMessage = "Wybierz rodzaj użytkownika!")]
        public int UserTypeID { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
