using GestionEmpleados.Services;

bool salir = false;
var auth = new AuthServices();
var empleados = new EmpleadosServices();

Console.WriteLine("Sistema de Gestión de Empleados");
Console.WriteLine("-------------------------------");
Console.WriteLine("Por favor, inicie sesión para continuar.");
Console.WriteLine();
Console.WriteLine("\n===== Autenticación de Usuario =====");
Console.WriteLine("Ingrese su nombre de usuario:");
var username = Console.ReadLine();
Console.WriteLine("Ingrese su contraseña:");
var password = Console.ReadLine();

if (!auth.Authenticate(username, password)) { 
    Console.WriteLine("Autenticación fallida. Nombre de usuario o contraseña incorrectos.");
    return;
}

while(!salir)
{
    Console.WriteLine();
    Console.WriteLine("\n===== MENU PRINCIPAL =====");
    Console.WriteLine("1. Agregar Empleado");
    Console.WriteLine("2. Ver Empleados");
    Console.WriteLine("3. Actualizar Empleado");
    Console.WriteLine("4. Eliminar Empleado");
    Console.WriteLine("5. Salir");
    Console.WriteLine("Seleccione una opción (1-5):");
    var opcion = Console.ReadLine();
    Console.Clear();
    switch (opcion)
    {
        case "1":
            CrearEmpleado(empleados);
            break;
        case "2":
            ListarEmpleados(empleados);
            break;
        case "3":
            ActualizarEmpleado(empleados);
            break;
        case "4":
            EliminarEmpleado(empleados);
            break;
        case "5":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            break;
    }
}

static void CrearEmpleado(EmpleadosServices services)
{
    Console.WriteLine("\n ====== AGREGAR UN NUEVO EMPLEADO ==========");
    Console.WriteLine("Nombre:");
    string nombre = Console.ReadLine();
    Console.WriteLine("Edad:");
    int edad = int.Parse(Console.ReadLine());
    Console.WriteLine("Puesto:");
    string puesto = Console.ReadLine();
    services.AgregarEmpleado(nombre, edad, puesto);
    Console.WriteLine("Empleado agregado exitosamente.");
}

static void ListarEmpleados(EmpleadosServices empleados)
{
    Console.WriteLine("\n===== LISTA DE EMPLEADOS: ======");

    var lista = empleados.ObtenerEmpleados();
    if (lista.Count == 0)
    {
        Console.WriteLine("No hay empleados registrados.");
        return;
    }

    foreach (var emp in lista)
    {
        Console.WriteLine($"{emp.Id} - {emp.Nombre} ({emp.Puesto})");
    }
}

static void ActualizarEmpleado(EmpleadosServices empleados)
{
    Console.WriteLine("\n ===== EDITAR EMPLEADOS ==========");
    Console.WriteLine("Ingrese el ID del empleado a actualizar:");
    var idActualizar = int.Parse(Console.ReadLine());
    var empleado = empleados.ObtenerEmpleadoPorId(idActualizar);
    if (empleado == null)
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
    empleado.Nombre = nuevoNombre;
    empleado.Edad = nuevaEdad;
    empleado.Puesto = nuevoPuesto;
    empleados.ActualizarEmpleado(empleado);
    Console.WriteLine("Empleado actualizado exitosamente.");
}

static void EliminarEmpleado(EmpleadosServices empleados)
{
    Console.WriteLine("\n===== ELIMINAR EMPLEADO: ==========");
    Console.WriteLine("Ingrese el ID del empleado a eliminar:");
    var idEliminar = int.Parse(Console.ReadLine());

    var emp = empleados.ObtenerEmpleadoPorId(idEliminar);
    if (emp == null)
    {
        Console.WriteLine("Empleado no existe.");
        return;
    }
    empleados.EliminarEmpleado(idEliminar);
    Console.WriteLine("Empleado eliminado exitosamente.");
}
