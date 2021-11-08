using FluentValidation;
using Berger.Global.Notifications.Tests.Models;

namespace Berger.Global.Notifications.Tests.Contracts
{
    public class CustomerContract : AbstractValidator<Customer>
    {
        public CustomerContract()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}