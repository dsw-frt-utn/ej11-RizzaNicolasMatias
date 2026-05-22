using System.Globalization;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    // 1. Obtener el primer libro
    public Libro GetPrimero(List<Libro> libros)
    {
        return libros.FirstOrDefault();
    }

    // 2. Obtener el último libro
    public Libro GetUltimo(List<Libro> libros)
    {
        return libros.LastOrDefault();
    }

    // 3. Obtener la suma de precios
    public decimal GetTotalPrecios(List<Libro> libros)
    {
        return libros.Sum(l => l.Precio);
    }

    // 4. Obtener el promedio de precios
    public decimal GetPromedioPrecios(List<Libro> libros)
    {
        return libros.Any() ? libros.Average(l => l.Precio) : 0;
    }

    // 5. Obtener la lista de libros con Id mayor a 15
    public List<Libro> GetListById(List<Libro> libros)
    {
        return libros.Where(l => l.Id > 15).ToList();
    }

    // 6. Obtener una lista de cada libro con su título y precio en formato moneda (retorna List<string>)
    public List<string> GetLibros(List<Libro> libros)
    {
        
        var culturaCba = new CultureInfo("es-AR");
        return libros.Select(l => $"{l.Titulo} - {l.Precio.ToString("C", culturaCba)}").ToList();
    }

    // 7. Obtener el libro con el precio más alto
    public Libro GetMayorPrecio(List<Libro> libros)
    {
        return libros.OrderByDescending(l => l.Precio).FirstOrDefault();
    }

    // 8. Obtener el libro con el precio más bajo
    public Libro GetMenorPrecio(List<Libro> libros)
    {
        return libros.OrderBy(l => l.Precio).FirstOrDefault();
    }

    // 9. Obtener los libros cuyo precio sea mayor al promedio
    public List<Libro> GetMayorPromedio(List<Libro> libros)
    {
        decimal promedio = GetPromedioPrecios(libros);
        return libros.Where(l => l.Precio > promedio).ToList();
    }

    // 10. Obtener los libros ordenados por título de forma descendente
    public List<Libro> GetLibrosOrdenadosDescendente(List<Libro> libros)
    {
        return libros.OrderByDescending(l => l.Titulo).ToList();
    }
}