
using Domain.DTOs.Uf;
using System;

namespace Domain.DTOs.Municipio
{
    public class MunicipioDTOCompleto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int CodIBGE { get; set; }
        public Guid UfId { get; set; }

        public UfDTO Uf { get; set; }
    }
}
