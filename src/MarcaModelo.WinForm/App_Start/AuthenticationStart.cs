using System.Threading;

namespace MarcaModelo.WinForm
{
    public class AuthenticationStart
    {
        public static void Initialize()
        {
            Thread.CurrentPrincipal = new Usuario
            {
                Name = "Usuario con Permiso"
            };
        }
    }
}
