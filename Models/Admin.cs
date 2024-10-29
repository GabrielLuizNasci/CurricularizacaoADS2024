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

        [Required]
        [StringLength(11)]
        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
