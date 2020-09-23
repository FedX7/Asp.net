using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Many1.Models
{
    [DateStartDateEndEqualAttribute]
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Компания заказчик")]
        [StringLength(20, MinimumLength = 3)]
        public string Customer { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Компания исполнитель")]
        [StringLength(20, MinimumLength = 3)]
        public string Performer { get; set; }
        public string Leader { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Начальная дата")]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Конечная дата")]
        public DateTime DateEnd { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
        public Project()
        {
            Workers = new List<Worker>();
        }
    }
    
 
public class DateStartDateEndEqualAttribute : ValidationAttribute
    {
        public DateStartDateEndEqualAttribute()
        {
            ErrorMessage = "Начальная дата больше конечной";
        }
        public override bool IsValid(object value)
        {
            Project p = value as Project;

            if (p.DateStart > p.DateEnd)
            {
                return false;
            }
            return true;
        }
    }
}