using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class DeliveryAdress
    {
        [Key]
        public int DeliveryAdressID { get; set; }

        [Display(Name = "Osoba kontaktowa")]
        public string ContactName { get; set; }
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; }
        [Display(Name = "Numer mieszkania")]
        public string AppartmentNumber { get; set; }
        [RegularExpression(@"[0-9]{2}-[0-9]{3}", ErrorMessage = "Kod pocztowy nie jest poprawny (##-###")]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }

        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}
