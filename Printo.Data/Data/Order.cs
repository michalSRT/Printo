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
        [Required(ErrorMessage = "Wybierz klienta")]
        [Display(Name = "Klient")]
        public int? ClientID { get; set; }   // klient
        [Required(ErrorMessage = "Wybierz rodzaj dostawy")]
        [Display(Name = "Rodzaj dostawy")]
        public int? DeliveryTypeID { get; set; }    // rodzaj dostawy
        [Required(ErrorMessage = "Wybierz uszlachetnienie")]
        [Display(Name = "Uszlachetnienia druku")]
        public int? FinishingID { get; set; }     // uszlachetnienia druku
        [Required(ErrorMessage = "Wybierz format")]
        [Display(Name = "Format lub wymiary produktu")]
        public int FormatID { get; set; }     // format/wymiary produktu
        [Required(ErrorMessage = "Wybierz maszynę")]
        [Display(Name = "Maszyna drukująca")]
        public int? MachineID { get; set; }   // maszyna drukująca
        [Required(ErrorMessage = "Wybierz gramaturę")]
        [Display(Name = "Gramatura papieru")]
        public int PaperWeightID { get; set; }
        [Required(ErrorMessage = "Wybierz rodzaj papieru")]
        [Display(Name = "Rodzaj papieru")]
        public int PaperTypeID { get; set; }
        [Required(ErrorMessage = "Wybierz metodę płatności")]
        [Display(Name = "Metoda płatności")]
        public int? PaymentTypeID { get; set; }
        [Required(ErrorMessage = "Wybierz metodę obróbki introligatorskiej")]
        [Display(Name = "Postpress - introligatornia")]
        public int? PostPressID { get; set; }
        [Required(ErrorMessage = "Wybierz kolorystykę druku")]
        [Display(Name = "Kolorystyka wydruku")]
        public int PrintColorID { get; set; }
        [Required(ErrorMessage = "Wybierz rodzaj produktu")]
        [Display(Name = "Produkt")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Wybierz etap produkcji")]
        [Display(Name = "Etap produkcji")]
        public int? ProductionStageID { get; set; }
        [Required(ErrorMessage = "Wybierz format arkusza")]
        [Display(Name = "Format arkusza do druku")]
        public int? SheetSizeID { get; set; }
        [Required(ErrorMessage = "Wybierz stawkę Vat")]
        [Display(Name = "Stawka VAT")]
        public int? VatRateID { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "Podaj nazwę zamówienia")]
        [Display(Name = "Nazwa zamówienia")]
        public string OrderName { get; set; }
        [Display(Name = "Dodatkowy opis zamówienia")]
        public string Description { get; set; }
        [Display(Name = "Cena netto")]
        public string NetPrice { get; set; }
        [Display(Name = "Czy dodruk?")]
        public bool IsReprint { get; set; }
        [Required(ErrorMessage = "Podaj nakład zamówienia")]
        [Display(Name = "Ilość zamówionego produktu")]
        public string Quantity { get; set; }
        [Display(Name = "Ilość arkuszy do druku")]
        public string SheetsNumber { get; set; }
        [Display(Name = "Ilość arkuszy wydrukowanych")]
        public string SheetsNumberPrinted { get; set; }
        [Display(Name = "Uwagi do druku")]
        public string Comments { get; set; }
        [Display(Name = "Szczegóły dostawy")]
        public string DeliveryDetails { get; set; }


        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? AddedUserID { get; set; }
        public virtual User AddedUser { get; set; }
        public int? UpdatedUserID { get; set; } 
        public virtual User UpdatedUser { get; set; }

        public virtual Client Client { get; set; }

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
