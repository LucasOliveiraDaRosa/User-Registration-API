
using System;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfIf { get; set; }
    }
}
