using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEmpleados.Models;

namespace GestionEmpleados.Services
{
    public class EmpleadosServices
    {
        public List<Empleados> empleados = new();
        public int contador = 1;

        public void AgregarEmpleado(string nombre, decimal edad, string puesto)
        {
            var empleado = new Empleados
            {
                Id = contador++,
                Nombre = nombre,
                Edad = edad,
                Puesto = puesto
            };
            empleados.Add(empleado);
        }

        public List<Empleados> ObtenerEmpleados()
        {
            return empleados;
        }

        public Empleados ObtenerEmpleadoPorId(int id)
        {
            return empleados.FirstOrDefault(e => e.Id == id);
        }
    }
}
