﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyFullName { get; set; }
        [MinLength(8, ErrorMessage = "Numer NIP powinien mieć 8 cyfr wpisywane bez pauz.")]
        [MaxLength(8, ErrorMessage = "Numer NIP powinien mieć 8 cyfr wpisywane bez pauz.")]
        public string NIP { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string AppartmentNumber { get; set; }
        [RegularExpression(@"[0-9]{2}-[0-9]{3}", ErrorMessage = "Kod pocztowy nie jest poprawny (##-###")]
        public string PostalCode { get; set; }
        public string City { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Adres email nie jest poprawny,.")]
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<DeliveryAdress> DeliveryAdresses { get; set; }
    }
}