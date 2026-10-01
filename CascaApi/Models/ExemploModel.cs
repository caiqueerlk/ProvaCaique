using System.ComponentModel.DataAnnotations;

namespace CascaApi.Models
{
    public class ExemploModel
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; } = "";

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ter 11 dígitos numéricos")]
        public string Cpf { get; set; } = "";

        [Required, StringLength(500)]
        public string Descricao { get; set; } = "";

        [Required, PosicaoValida]
        public string Posicao { get; set; } = "";

        public bool? Aprovado { get; set; } 
    }

    internal class PosicaoValidaAttribute : Attribute //correção
    {
    }
}