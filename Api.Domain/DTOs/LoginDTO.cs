using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Email é campo obrigatório para Login.")]
        [EmailAddress(ErrorMessage = "Email em formato invalido.")]
        [StringLength(100,ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}
