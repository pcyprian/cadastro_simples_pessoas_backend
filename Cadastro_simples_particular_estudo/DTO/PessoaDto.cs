using Cadastro_simples_particular_estudo.Models;

namespace Cadastro_simples_particular_estudo.DTO
{
    public class PessoaDto
    {
        public Guid? Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public DateTime? dataNascimento { get; set; }
    }
}
