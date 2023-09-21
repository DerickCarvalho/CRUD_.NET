using CrudDotNetMVC.Data;
using CrudDotNetMVC.Models;

namespace CrudDotNetMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
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
    }
}
