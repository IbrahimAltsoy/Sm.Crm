using FluentValidation;
using Sm.Crm.Application.DTOs.Customers;
using Sm.Crm.Application.Features.Commands.Customers.CreateCustomer;

namespace Sm.Crm.Application.Validator.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommandRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(p => p.CompanyName)
                .NotEmpty()
                 .NotNull()
                     .WithMessage("Lutfen şirket ismi giriniz")
                 .MaximumLength(250)
                     .WithMessage("Şirket ismi en fazla {MaxLength} karakter olmalidir.")
                 .MinimumLength(3)
                     .WithMessage("Şirket en az {MinLength} karakter olmalidir.");


            RuleFor(p => p.IdentityNumber)
                 .NotEmpty()
                 .NotNull()
                     .WithMessage("Lutfen Identy numarasını giriniz")
                 .MaximumLength(15)
                     .WithMessage("Identy numarası en fazla {MaxLength} karakter olmalidir.")
                 .MinimumLength(2)
                     .WithMessage("Identy numarası en az {MinLength} karakter olmalidir.");
        }
    }
}
