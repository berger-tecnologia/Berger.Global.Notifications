using FluentValidation;
using Berger.Extensions.Notification.Tests.Models;

namespace Berger.Extensions.Notification.Tests.Contracts
{
    public class CustomerContract : AbstractValidator<Customer>
    {
        public CustomerContract()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name could not be empty");
        }
    }
}