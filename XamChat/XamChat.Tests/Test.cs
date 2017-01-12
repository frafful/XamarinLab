using System;
using XamChat.Core;
using XamChat.Core.Model;
using NUnit.Framework;

namespace XamChat.Tests
{
    [TestFixture]
    public static class Test
    {
       public static void SetUp()
       {
            ServiceContainer.Register<IWebService>(() => new FakeWebService
            {
                SleepDuration = 0
            });
            ServiceContainer.Register<ISettings>(() => new FakeSettings());
        }
    }
}
