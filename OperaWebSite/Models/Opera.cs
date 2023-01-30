using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OperaWebSite.Validations;
namespace OperaWebSite.Models
{
    public class Opera
    {
        public int OperaId { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName ="varchar(50)")]
        [StringLength(50)] //validación para la view, hasta 50 caracteres.
        public string Title { get; set;}

        [Required(ErrorMessage = "Campo obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)] //validación para la view, hasta 50 caracteres.
        public string Composer { get; set; }
        [CheckValidYear]
        public int Year { get; set; }

    }
}
