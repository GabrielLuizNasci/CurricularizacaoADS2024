using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurricularizacaoADS2024.Models
{
    [Table("Admins")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }
    }
}
