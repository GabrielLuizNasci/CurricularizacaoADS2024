using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(40)]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefone: ")]
        public int Telefone { get; set; }

        [Required]
        [Display(Name = "CPF: ")]
        public int CPF { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "E-mail: ")]
        public string Endereco { get; set; }
    }
}
