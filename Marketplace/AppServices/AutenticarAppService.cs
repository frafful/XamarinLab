using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.ServicoDeAutenticacao;
using System.ServiceModel;
using System.Diagnostics;

namespace Marketplace.AppServices
{
    public class AutenticarAppService
    {
        ServicoDeAutenticacao.ServicoDeAutenticacao servicoDeAutenticacao;

        public AutenticarAppService()
        {
            servicoDeAutenticacao = new ServicoDeAutenticacaoClient();
        }
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
                try
                {
                    var token = await Task.Factory.FromAsync(servicoDeAutenticacao.BeginAutenticarComOrigem, servicoDeAutenticacao.EndAutenticarComOrigem
                        , login, senha, "Xamarin App", TaskCreationOptions.None);

                    return true;
                }
                catch(FaultException fe)
                {
                    Debug.WriteLine(@"			{0}", fe.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"				ERROR {0}", ex.Message);
                }

                return false;
            }
        }
    }
}
