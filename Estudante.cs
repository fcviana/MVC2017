using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Models
{
    [Table("Estudantes")]

    public class Estudante
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Display(Name ="ID")]
        public int id { get; set; }

        [Display(Name = "Aluno")]
        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(35, ErrorMessage = "Tamanho máximo de 35 caracteres")]
        public string nomeAlu { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola escola{ get; set; }

        public virtual string nomeEscola { get { return escola.nome + "-" + escola.cidade; } }



    }
}