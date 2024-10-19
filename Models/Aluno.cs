using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurricularizacaoADS2024.Models
{
    [Table("Professores")]
    public class Aluno
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
        [Display(Name = "Nascimento: ")]
        public string Nascimento { get; set; }

        [Required]
        [Display(Name = "Endereco: ")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "CPF: ")]
        public int CPF { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "RG: ")]
        public string RG { get; set; }

        [Required]
        [Display(Name = "Telefone: ")]
        public int Telefone { get; set; }

        [Required]
        [Display(Name = "Sexo: ")]
        public int Sexo { get; set; }
    }
}
