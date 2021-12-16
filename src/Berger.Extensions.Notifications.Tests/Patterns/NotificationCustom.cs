using Berger.Extensions.Notifications.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Berger.Extensions.Notifications.Tests.Patterns
{
    [TestClass]
    public class NotificationCustom : BaseConfiguration
    {
        private readonly Customer _customer = new Customer();

        public override void Dispose(){ }
    }
}