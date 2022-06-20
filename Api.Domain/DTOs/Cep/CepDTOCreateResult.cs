using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Cep
{
    public class CepDTOCreateResult
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
