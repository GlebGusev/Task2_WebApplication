using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class StaffModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Фамилия - обязательное поле")]
        [StringLength(15)]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Имя - обязательное поле")]
        [StringLength(15)]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Отчество - обязательное поле")]
        [StringLength(15)]
        public string father_name { get; set; }

        [Required(ErrorMessage = "Дата рождения - обязательное поле")]
        public System.DateTime birth_dt { get; set; }

        [EmailAddress(ErrorMessage = "Неверный формат email")]
        [StringLength(50)]
        public string email { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Неверный формат телефона")]
        [StringLength(13)]
        public string phone_nbr { get; set; }

        //public virtual ICollection<OtherModel> Subject { get; set; } - link to another table
    }
}