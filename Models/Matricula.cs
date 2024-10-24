using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurricularizacaoADS2024.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Curso: ")]
        public string Curso { get; set; }

        [Required]
        [Display(Name = "Data de Matricula: ")]
        public DateTime DataMatricula { get; set; }

        [Display(Name = "Aluno: ")]
        [StringLength(35)]
        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }
    }
}
