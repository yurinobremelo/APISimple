using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UserGetAllViewModel 
    { 

        /* public UserGetAllViewModel(string nome, string endereco, string numero)
        {
            Nome = nome;
            Endereco = endereco;
            Numero = numero;
        }
        */
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
    }
}
