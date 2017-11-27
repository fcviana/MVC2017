using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ADS.Models
{
    [Table("Escolas")]
    public class Escola
    {
        public Escola()
        {
            this.Estudante = new HashSet<Estudante>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int id { get; set; }

        [Display(Name = "Escola")]
        [Required(ErrorMessage ="Campo Nome obrigatório")]
        [StringLength(35,ErrorMessage ="Tamanho máximo de 35 caracteres")]
        public string nome { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Campo Cidade é obrigatório")]
        [StringLength(35, ErrorMessage = "Tamanho máximo 35 caracteres")]
        public string cidade { get; set; }

        [Display(Name ="Estado")]
        [Required(ErrorMessage = "Campo Estado Obrigatório")]
        [StringLength(2, ErrorMessage = "Tamanho maximo de 2 caracteres")]
        public string estado { get; set; }

        [Display(Name ="Quantidade de Alunos")]
        [Required(ErrorMessage = "Campo Quantidade obrigatório ")]
        [Range(0,10000, ErrorMessage ="Valor tem que ser entra 0 e 10000")]
        public int quantidade { get; set; }

        [Display(Name ="Lista de Alunos")]
        public virtual ICollection<Estudante> Estudante { get; set; }



    }
}