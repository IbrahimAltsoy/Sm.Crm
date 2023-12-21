using FluentValidation;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Features.Commands.Customers.CreateCustomer;

namespace Sm.Crm.Application.Validator.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                    .WithMessage("Lütfen UserId giriniz")
                .Must(c => c > 0)
                    .WithMessage("UserId alanı 0 dan büyük olmalıdır.");

            RuleFor(p => p.IdentityNumber)
                 .NotEmpty()
                 .NotNull()
                     .WithMessage("Lutfen urun ismi giriniz")
                 .MaximumLength(15)
                     .WithMessage("Ürunu en fazla {MaxLength} karakter olmalidir.")
                 .MinimumLength(2)
                     .WithMessage("Ürunu en az {MinLength} karakter olmalidir.");
        }
    }
}
