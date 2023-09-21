using CrudDotNetMVC.Models;

namespace CrudDotNetMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuariosModel AddUsuario(UsuariosModel usuario);
        UsuariosModel ValidarUsuario(string usuario);
    }
}
