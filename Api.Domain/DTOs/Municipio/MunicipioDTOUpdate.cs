using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDTOUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório."))]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de município é obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome de município deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é obrigatório.")]
        public Guid UfIf { get; set; }
    }
}
