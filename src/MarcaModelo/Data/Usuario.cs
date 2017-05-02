using System.Security.Principal;

namespace MarcaModelo
{
    public class Usuario : IIdentity, IPrincipal
    {
        public string Name { get; set; }

        public string AuthenticationType
        {
            get { return "Windows"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public bool IsInRole(string role)
        {
            return "Usuario con Permiso".Equals(Name);
        }

        public IIdentity Identity
        {
            get { return this; }
        }
    }
}
