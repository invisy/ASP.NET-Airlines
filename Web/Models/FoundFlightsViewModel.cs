using System;
using System.ComponentModel.DataAnnotations;

namespace Airlines.Web.Models
{
    public class FoundFlightsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Місто відправлення")]
        public string DepartureCity { get; set; }
        [Display(Name = "Місто прибуття")]
        public string IncomingCity { get; set; }
        [Display(Name = "Дата відправлення")]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Дата прибуття")]
        public DateTime IncomingDate { get; set; }
        [Display(Name = "Ціна квитка від")]
        public int MinimalPrice { get; set; }
        [Display(Name = "Назва літака")]
        public string PlaneName { get; set; }
        [Display(Name = "Модель літака")]
        public string PlaneModel { get; set; }
        [Display(Name = "Загальна кількість місць")]
        public int NumberOfAllPlaces { get; set; }
        [Display(Name = "Кількість вільних місць")]
        public int NumberOfFreePlaces { get; set; }
        public bool OrderButtonIsActive { get; set; }
    }
}