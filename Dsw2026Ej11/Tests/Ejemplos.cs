using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;

internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("--- EJEMPLO DE LIST ---");
        CasoList casoList = new CasoList();


        Alumno a1 = new Alumno(101, "Juan Perez", 8.5);
        Alumno a2 = new Alumno(102, "Maria Lopez", 9.2);
        Alumno a3 = new Alumno(103, "Carlos Gomez", 6.8);

        casoList.AgregarAlumno(a1);
        casoList.AgregarAlumno(a2);
        casoList.AgregarAlumno(a3);


        Console.WriteLine("\nLista inicial de alumnos:");
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }


        Console.WriteLine("\nBuscar por nombre 'Maria Lopez':");
        var encontrado = casoList.BuscarPorNombre("Maria Lopez");
        Console.WriteLine(encontrado != null ? encontrado.ToString() : "No existe");


        Console.WriteLine("\nBuscar por nombre 'Ana Arce':");
        var noEncontrado = casoList.BuscarPorNombre("Ana Arce");
        Console.WriteLine(noEncontrado != null ? noEncontrado.ToString() : "No existe");


        Console.WriteLine("\nEliminando a Maria Lopez y listando:");
        casoList.EliminarAlumno(a2);
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }


        Console.WriteLine("\nEliminando el primer elemento de la lista (posicion 0) y listando:");
        casoList.EliminarEnPosicion(0);
        foreach (var alu in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alu);
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("--- EJEMPLO DE DICTIONARY ---");
        CasoDictionary casoDict = new CasoDictionary();


        casoDict.AgregarAlumno(new Alumno(501, "Lucia Fernandez", 7.4));
        casoDict.AgregarAlumno(new Alumno(502, "Pedro Martinez", 8.9));
        casoDict.AgregarAlumno(new Alumno(503, "Sofía Rodriguez", 9.5));


        Console.WriteLine("\nAlumnos en el diccionario:");
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave (Legajo): {kvp.Key} -> {kvp.Value}");
        }
        Console.WriteLine("\nBuscar alumno con clave 502:");
        var aluClave = casoDict.BuscarPorClave(502);
        Console.WriteLine(aluClave != null ? aluClave.ToString() : "No existe");


        Console.WriteLine("\nBuscar alumno con clave 999:");
        var aluClaveFalsa = casoDict.BuscarPorClave(999);
        Console.WriteLine(aluClaveFalsa != null ? aluClaveFalsa.ToString() : "No existe");


        Console.WriteLine("\nEliminando alumno con clave 501 y listando:");
        casoDict.EliminarPorClave(501);
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"Clave (Legajo): {kvp.Key} -> {kvp.Value}");
        }
    }

    public static void EjemploLinq()
    {
        Console.WriteLine("--- EJEMPLO DE LINQ ---");
        CasoLinq casoLinq = new CasoLinq();
        List<Libro> listaLibros = Libro.CrearLista();

        // 1. Primero
        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero(listaLibros)?.Titulo}");

        // 2. Último
        Console.WriteLine($"2. Ultimo libro: {casoLinq.GetUltimo(listaLibros)?.Titulo}");

        // 3. Total Precios
        Console.WriteLine($"3. Total de precios: {casoLinq.GetTotalPrecios(listaLibros):C}");

        // 4. Promedio Precios
        decimal promedio = casoLinq.GetPromedioPrecios(listaLibros);
        Console.WriteLine($"4. Promedio de precios: {promedio:C}");

        // 5. Libros con ID > 15
        Console.WriteLine("\n5. Libros con Id mayor a 15:");
        var idMayor15 = casoLinq.GetListById(listaLibros);
        idMayor15.ForEach(l => Console.WriteLine($"   Id: {l.Id} - {l.Titulo}"));

        // 6. Libros formato título y moneda
        Console.WriteLine("\n6. Lista de libros formateada:");
        var librosFormateados = casoLinq.GetLibros(listaLibros);
        // Mostramos los primeros 5 para no saturar la pantalla de la consola
        librosFormateados.Take(5).ToList().ForEach(s => Console.WriteLine($"   {s}"));
        Console.WriteLine("   ... (y continúan los demás)");

        // 7. Mayor precio
        var maxPrecio = casoLinq.GetMayorPrecio(listaLibros);
        Console.WriteLine($"\n7. Libro con precio mas alto: {maxPrecio?.Titulo} ({maxPrecio?.Precio:C})");

        // 8. Menor precio
        var minPrecio = casoLinq.GetMenorPrecio(listaLibros);
        Console.WriteLine($"8. Libro con precio mas bajo: {minPrecio?.Titulo} ({minPrecio?.Precio:C})");

        // 9. Mayor al promedio
        Console.WriteLine($"\n9. Libros con precio mayor al promedio ({promedio:C}):");
        var mayorPromedio = casoLinq.GetMayorPromedio(listaLibros);
        // Mostramos solo 3 ejemplos para verificar
        mayorPromedio.Take(3).ToList().ForEach(l => Console.WriteLine($"   {l.Titulo} - {l.Precio:C}"));
        Console.WriteLine("   ... (y continúan los demás)");

        // 10. Ordenados descendente por título
        Console.WriteLine("\n10. Primeros 5 libros ordenados por titulo de forma descendente:");
        var ordenadosDesc = casoLinq.GetLibrosOrdenadosDescendente(listaLibros);
        ordenadosDesc.Take(5).ToList().ForEach(l => Console.WriteLine($"    {l.Titulo}"));
    }
}