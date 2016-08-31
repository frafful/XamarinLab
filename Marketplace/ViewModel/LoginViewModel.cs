using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.ViewModel
{
    public class LoginViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ErrosValidacao { get; private set; }

        public bool PodeEntrar
        {
            get
            {
                ErrosValidacao = string.Empty;

                if (string.IsNullOrEmpty(Login))
                    ErrosValidacao = "Por favor, preencha o campo Login.";

                if (string.IsNullOrEmpty(Senha))
                    ErrosValidacao += "Por favor, preencha o campo Senha.";

                return string.IsNullOrEmpty(ErrosValidacao);
            }
        }

        public LoginViewModel()
        {
            Login = string.Empty;
            Senha = string.Empty;
        }

    }
}
