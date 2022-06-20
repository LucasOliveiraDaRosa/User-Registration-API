using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Cep
{
    public class CepDTOUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "Município é obrigatório.")]
        public Guid MunicipioId { get; set; }
    }
}
