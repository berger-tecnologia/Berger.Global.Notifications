using System.Linq;
using Berger.Extensions.Notifications.Tests.Models;
using Berger.Extensions.Notifications.Tests.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Berger.Extensions.Notifications.Tests.Patterns
{
    [TestClass]
    public class NotificationContract : BaseConfiguration
    {
        private readonly Customer _customer = new Customer();

        public override void Dispose(){ }

        [TestMethod]
        [TestCategory("NotificationPattern")]
        public void IfInvalidContract()
        {
            var _notification = Create();

            _notification.IfInvalidContract(_customer, new CustomerContract());
            
            Assert.IsTrue(_notification.Messages.Any(x => x.Message.Equals("Name could not be empty")), "Contract message error is different");
        }
    }
}