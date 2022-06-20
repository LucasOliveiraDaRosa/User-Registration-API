using Domain.DTOs.Municipio;
using System;

namespace Domain.DTOs.Cep
{
    public class CepDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDTOCompleto Municipio { get; set; }
    }
}
