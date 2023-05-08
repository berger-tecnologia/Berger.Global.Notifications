using Berger.Extensions.Notification.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Berger.Extensions.Notification.Tests.Patterns
{
    [TestClass]
    public class NotificationObject : BaseConfiguration
    {
        private readonly Customer _customer = new Customer();
        public override void Dispose(){ }
    }
}