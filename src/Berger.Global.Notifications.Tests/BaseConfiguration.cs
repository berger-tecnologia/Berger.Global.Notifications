using System;
using Microsoft.Extensions.Configuration;

namespace Berger.Global.Notifications.Tests
{
    public abstract class BaseConfiguration : IDisposable
    {
        public static IConfiguration Configuration { get; }

        protected void Initialize()
        {
        }
        public abstract void Dispose();
    }
}