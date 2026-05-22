using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    private Dictionary<int, Alumno> _diccionarioAlumnos = new Dictionary<int, Alumno>();

    public void AgregarAlumno(Alumno alumno)
    {
        if (!_diccionarioAlumnos.ContainsKey(alumno.Id))
        {
            _diccionarioAlumnos.Add(alumno.Id, alumno);
        }
    }

    public Alumno BuscarPorClave(int clave)
    {
        if (_diccionarioAlumnos.TryGetValue(clave, out Alumno alumno))
        {
            return alumno;
        }
        return null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _diccionarioAlumnos;
    }

    public bool EliminarPorClave(int clave)
    {
        return _diccionarioAlumnos.Remove(clave);
    }
}