using GestionEmpleados.Services;

var auth = new AuthServices();
Console.WriteLine("Ingrese su nombre de usuario:");
var username = Console.ReadLine();
Console.WriteLine("Ingrese su contraseña:");
var password = Console.ReadLine();
if (auth.Authenticate(username, password))
{
    Console.WriteLine("Autenticación exitosa. Bienvenido al sistema de gestión de empleados.");
    var services = new EmpleadosServices();
    Console.WriteLine("Agregar un nuevo empleado:");

    Console.WriteLine("Nombre:");
    var nombre = Console.ReadLine();

    Console.WriteLine("Edad:");
    var edad = int.Parse(Console.ReadLine());

    Console.WriteLine("Puesto:");
    var puesto = Console.ReadLine();
    services.AgregarEmpleado(nombre, edad, puesto);
    Console.WriteLine("Empleado agregado exitosamente.");

    Console.WriteLine("Lista de empleados:");
    foreach (var emp in services.ObtenerEmpleados())
    {
        Console.WriteLine($"{emp.Id} - {emp.Nombre} ({emp.Puesto})");
    }

    Console.WriteLine("Actualizar un empleado existente:");
    Console.WriteLine("Ingrese el ID del empleado a actualizar:");
    var idActualizar = int.Parse(Console.ReadLine());
    var empleados = services.ObtenerEmpleadoPorId(idActualizar);
    if (empleados == null)
    {
        Console.WriteLine("Empleado no existe.");
        return;
    }

    Console.WriteLine("Nuevo Nombre:");
    var nuevoNombre = Console.ReadLine();
    Console.WriteLine("Nueva Edad:");
    var nuevaEdad = int.Parse(Console.ReadLine());
    Console.WriteLine("Nuevo Puesto:");
    var nuevoPuesto = Console.ReadLine();
    empleados.Nombre = nuevoNombre;
    empleados.Edad = nuevaEdad;
    empleados.Puesto = nuevoPuesto;
    services.ActualizarEmpleado(empleados);
    Console.WriteLine("Empleado actualizado exitosamente.");

}
else
{
    Console.WriteLine("Autenticación fallida. Nombre de usuario o contraseña incorrectos.");
}
