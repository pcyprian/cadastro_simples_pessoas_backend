using Cadastro_simples_particular_estudo.DTO;
using Microsoft.EntityFrameworkCore;

namespace Cadastro_simples_particular_estudo.Infra
{
    public class PessoaRepository
    {
        private readonly CadastroPessoaContext _context;
        public PessoaRepository()
        {
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
            .GetSection("ConnectionString:DefaultConnection").Value;

            var optionsBuilder = new DbContextOptionsBuilder<CadastroPessoaContext>();
            optionsBuilder.UseSqlServer(connString);

            _context = new CadastroPessoaContext(optionsBuilder.Options);
        }

        public IEnumerable<PessoaDto> GetAllPessoa()
        {
            try
            {
                var pessoas = _context.Pessoas?.ToList();
                return pessoas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public PessoaDto? GetById(Guid id)
        {
            try
            {
                var pessoas = _context.Pessoas.SingleOrDefault(a => a.Id == id);

                return pessoas;
            }

            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public bool InsertPessoa(PessoaDto pessoaDto)
        {
            try
            {
                _context.Pessoas.Add(pessoaDto);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        public PessoaDto UpdatePessoa(PessoaDto pessoaDto)
        {
            try
            {
                var pessoas = _context.Pessoas.SingleOrDefault(a => a.Id == pessoaDto.Id);

                if (pessoas is not null)
                {
                    _context.Entry(pessoas).State = EntityState.Detached;

                    _context.Pessoas.Update(pessoaDto);
                    _context.SaveChanges();

                    return pessoas;
                }
                return pessoas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool DeletePessoa(Guid id)
        {
            try
            {
                var pessoa = _context.Pessoas.First(a => a.Id == id);

                if (pessoa is null)
                {
                    throw new Exception($"Pessoa com o Id `{id}` não encontrado");
                }

                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
