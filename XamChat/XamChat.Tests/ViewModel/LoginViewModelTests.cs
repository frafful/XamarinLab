using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamChat.Core;
using XamChat.Core.Model;
using XamChat.Core.ViewModel;

namespace XamChat.Tests.ViewModel
{
    [TestFixture]
    public class LoginViewModelTests
    {
        LoginViewModel loginViewModel;
        ISettings settings;

        [SetUp]
        public void SetUp()
        {
            Test.SetUp();
            settings = ServiceContainer.Resolve<ISettings>();
            loginViewModel = new LoginViewModel();
        }

        [Test]
        public async Task LoginSuccessfully()
        {
            loginViewModel.Username = "testuser";
            loginViewModel.Password = "password";
            await loginViewModel.Login();

            Assert.That(settings.User, Is.Not.Null);
        }

        [Test]
        public async Task LoginWithNoUsernameOrPassword()
        {
            Assert.ThrowsAsync<Exception>(async () => await loginViewModel.Login());
        }
    }
}
