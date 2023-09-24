using CrudDotNetMVC.Data;
using CrudDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudDotNetMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuariosModel BuscarUsuario(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuariosModel ValidarUsuario(string usuario)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Usuario == usuario);
        }
        public UsuariosModel AddUsuario(UsuariosModel usuario)
        {
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public UsuariosModel AtualizarUsuario(UsuariosModel attUsuario)
        {
            UsuariosModel usuarioValidado = ValidarUsuario(attUsuario.Usuario);

            if (usuarioValidado != null)
            {
                throw new Exception("Este nome de usuário está sendo utilizado por outra pessoa!");
            } else
            {
                UsuariosModel oldInfos = BuscarUsuario(attUsuario.Id);

                if (oldInfos == null)
                {
                    throw new Exception("Erro na atualização do perfil!");
                }
                else
                {
                    if (attUsuario.UrlImg != null)
                    {
                        oldInfos.UrlImg = attUsuario.UrlImg;
                    }

                    if (attUsuario.Usuario != null)
                    {
                        oldInfos.Usuario = attUsuario.Usuario;
                    }

                    _bancoContext.Usuarios.Update(oldInfos);
                    _bancoContext.SaveChanges();

                    return attUsuario;
                }
            }            
        }
        public UsuariosModel Login(string usuario, string senha)
        {
            return _bancoContext.Usuarios.FirstOrDefault(y => y.Usuario == usuario && y.Senha == senha);
        }        
    }
}
