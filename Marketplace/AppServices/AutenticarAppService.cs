using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.ServicoDeAutenticacao;

namespace Marketplace.AppServices
{
    public class AutenticarAppService
    {
        public async Task<bool> AutenticarAsync(string login, string senha)
        {
            var repositorio = new RepositorioDeUsuario();
            var usuarioLocal = repositorio.Listar().FirstOrDefault();

            //Valida na base local
            if (usuarioLocal != null)
            {
                if (login.Equals(usuarioLocal) && senha.Equals(usuarioLocal.Senha))
                    return true;
                else
                {
                    //Tentar login online
                    return false;
                }
            }
            else
            {
                var proxy = new ServicoDeAutenticacao.ServicoDeAutenticacaoClient();
                proxy.AutenticarComOrigemCompleted += new EventHandler<ServicoDeAutenticacao.AutenticarComOrigemCompletedEventArgs>(AutenticarComOrigemCallBack);
                proxy.AutenticarComOrigemAsync(login, senha, "App Teste");

                //if()
            }   

            return true;
        }

        private void AutenticarComOrigemCallBack(object sender, AutenticarComOrigemCompletedEventArgs e)
        {
            var result = e.Result;
        }
    }
}
