using FluentValidation;
using Berger.Extensions.Notifications.Tests.Models;

namespace Berger.Extensions.Notifications.Tests.Contracts
{
    public class CustomerContract : AbstractValidator<Customer>
    {
        public CustomerContract()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name could not be empty");
        }
    }
}