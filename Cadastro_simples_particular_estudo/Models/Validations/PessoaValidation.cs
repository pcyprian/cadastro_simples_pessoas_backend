using FluentValidation;

namespace Cadastro_simples_particular_estudo.Models.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation()
        {
            RuleFor(x => x.nome).NotNull().NotEmpty();
            RuleFor(x => x.cpf).NotNull().NotEmpty().Length(11);
            RuleFor(x => x.email).NotNull().NotEmpty().EmailAddress();

        }

    }
}
