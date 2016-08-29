using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.AppServices
{
    public class AutenticarAppService
    {
        public bool Autenticar(string login, string senha)
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
                //var proxy = new ServicoDeAutenticacao.ServicoDeAutenticacaoClient();
                //proxy.
            }   

            return true;
        }
    }
}
