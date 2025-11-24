using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEmpleados.Models;

namespace GestionEmpleados.Services
{
    public class AuthServices
    {
        private List<Usuarios> usuarios = new List<Usuarios>
        {
            new Usuarios { Username = "admin", Password = "admin123" },
            new Usuarios { Username = "user", Password = "user123" }
        };

        public bool Authenticate(string username, string password)
        {
            return usuarios.Any(u => u.Username == username && u.Password == password);
        }
    }
}
