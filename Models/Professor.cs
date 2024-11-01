using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurricularizacaoADS2024.Models
{
    [Table("Professores")]
    public class Professor
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
    }
}
