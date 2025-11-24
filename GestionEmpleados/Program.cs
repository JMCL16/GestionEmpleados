using GestionEmpleados.Services;

var auth = new AuthServices();
Console.WriteLine("Ingrese su nombre de usuario:");
var username = Console.ReadLine();
Console.WriteLine("Ingrese su contraseña:");
var password = Console.ReadLine();
if (auth.Authenticate(username, password))
{
    Console.WriteLine("Autenticación exitosa. Bienvenido al sistema de gestión de empleados.");
    // Aquí iría la lógica principal del sistema de gestión de empleados
}
else
{
    Console.WriteLine("Autenticación fallida. Nombre de usuario o contraseña incorrectos.");
}
