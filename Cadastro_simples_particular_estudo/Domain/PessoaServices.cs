using Cadastro_simples_particular_estudo.DTO;
using Cadastro_simples_particular_estudo.Infra;
using Cadastro_simples_particular_estudo.Models;

namespace Cadastro_simples_particular_estudo.Domain
{
    public class PessoaServices
    {
        public IEnumerable<Pessoa> GetAllPessoa()
        {
            var pessoas = new List<Pessoa>();
            var pessoaRepository = new PessoaRepository();
            var pessoasDto = pessoaRepository.GetAllPessoa();

            foreach (var pessoa in pessoasDto)
            {
                pessoas.Add
                (
                    new Pessoa
                    {
                        Id = pessoa.Id,
                        nome = pessoa.nome,
                        cpf = pessoa.cpf,
                        email = pessoa.email,
                        dataNascimento = pessoa.dataNascimento
                    }
                );
            }
            return pessoas;
        }

        public PessoaDto GetPessoaById(Guid id)
        {
            var pessoaRepository = new PessoaRepository();
            var pessoa = pessoaRepository.GetById(id);

            return pessoa;

        }

        public void InsertPessoa(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.nome))
            {
                throw new ArgumentException("O nome é obrigatório para o cadastro.");
            }

            if (string.IsNullOrEmpty(pessoa.cpf))
            {
                throw new ArgumentException("O CPF é obrigatório para o cadastro.");
            }

            if (string.IsNullOrEmpty(pessoa.email))
            {
                throw new ArgumentException("O e-mail é obrigatório para o cadastro.");
            }

            var pessoaDto = new PessoaDto();

            pessoaDto.nome = pessoa.nome;
            pessoaDto.cpf = pessoa.cpf;
            pessoaDto.email = pessoa.email;
            pessoaDto.dataNascimento = pessoa.dataNascimento;

            var pessoaServices = new PessoaRepository();
            pessoaServices.InsertPessoa(pessoaDto);

        }


        public Pessoa UpdatePessoa(Pessoa pessoa, Guid id)
        {

            var pessoaRepository = new PessoaRepository();

            var pessoaDto = new PessoaDto();

            pessoaDto.Id = id;
            pessoaDto.nome = pessoa.nome;
            pessoaDto.cpf = pessoa.cpf;
            pessoaDto.email = pessoa.email;
            pessoaDto.dataNascimento = pessoa.dataNascimento;

            var pessoaDb = pessoaRepository.UpdatePessoa(pessoaDto);

            if (pessoaDb is not null)
            {

                return pessoa;
            }

            return null;


        }

        public bool DeletePessoa(Guid id)
        {
            var pessoaRepository = new PessoaRepository();
            var pessoaDb = pessoaRepository.GetById(id);

            if (pessoaDb is not null)
            {
                pessoaRepository.DeletePessoa(id);
                return true;
            }

            return false;
        }

    }
}
