using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Printo.Data.Data
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Display(Name = "Klient")]
        public int ClientID { get; set; }   // klient
        [Display(Name = "Adres dostawy")]
        public int? DeliveryAdressID { get; set; }   // adres dostawy
        [Display(Name = "Rodzaj dostawy")]
        public int? DeliveryTypeID { get; set; }    // rodzaj dostawy
        [Display(Name = "Uszlachetnienia druku")]
        public int? FinishingID { get; set; }     // uszlachetnienia druku
        [Required(ErrorMessage = "Pole format jest wymagane")]
        [Display(Name = "Format lub wymiary produktu")]
        public int FormatID { get; set; }     // format/wymiary produktu
        [Display(Name = "Maszyna drukująca")]
        public int? MachineID { get; set; }   // maszyna drukująca
        [Required(ErrorMessage = "Pole gramatura jest wymagane")]
        [Display(Name = "Gramatura papieru")]
        public int PaperWeightID { get; set; }
        [Required(ErrorMessage = "Pole rodzaj papieru jest wymagane")]
        [Display(Name = "Rodzaj papieru")]
        public int PaperTypeID { get; set; }
        [Display(Name = "Metoda płatności")]
        public int? PaymentTypeID { get; set; }
        [Display(Name = "Postpress - introligatornia")]
        public int? PostPressID { get; set; }
        [Required(ErrorMessage = "Pole kolor jest wymagane")]
        [Display(Name = "Kolorystyka wydruku")]
        public int PrintColorID { get; set; }
        [Required(ErrorMessage = "Pole produkt jest wymagane")]
        [Display(Name = "Produkt")]
        public int ProductID { get; set; }
        [Display(Name = "Etap produkcji")]
        public int? ProductionStageID { get; set; }
        [Display(Name = "Format arkusza do druku")]
        public int? SheetSizeID { get; set; }
        [Display(Name = "Stawka VAT")]
        public int? VatRateID { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Display(Name = "Dodatkowy opis")]
        public string Description { get; set; }
        [Display(Name = "Cena netto")]
        public string NetPrice { get; set; }
        [Display(Name = "Czy dodruk?")]
        public bool IsReprint { get; set; }
        [Display(Name = "Data ostatniego druku i dodatkowe informacje")]
        public string ReprintDateAndInfo { get; set; }
        [Display(Name = "Ilość arkuszy do druku")]
        public string SheetsNumber { get; set; }
        [Display(Name = "Ilość arkuszy wydrukowanych")]
        public string SheetsNumberPrinted { get; set; }
        [Display(Name = "Uwagi do druku")]
        public string Comments { get; set; }


        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? AddedUserID { get; set; }
        public virtual User AddedUser { get; set; }
        public int? UpdatedUserID { get; set; } 
        public virtual User UpdatedUser { get; set; }

        public virtual Client Client { get; set; }

        public virtual DeliveryAdress DeliveryAdress { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }

        public virtual Finishing Finishing { get; set; }

        public virtual Format Format { get; set; }

        public virtual Machine Machine { get; set; }

        public virtual PaperWeight PaperWeight { get; set; }

        public virtual PaperType PaperType { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual PostPress PostPress { get; set; }

        public virtual PrintColor PrintColor { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductionStage ProductionStage { get; set; }

        public virtual SheetSize SheetSize { get; set; }

        public virtual VatRate VatRate { get; set; }

    }
}
