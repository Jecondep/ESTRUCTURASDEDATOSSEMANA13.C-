using System;

public class Nodo
{
    public string Titulo;
    public Nodo Izquierdo, Derecho;

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = null;
        Derecho = null;
    }
}

public class CatalogoRevistas
{
    private Nodo raiz;

    public CatalogoRevistas()
    {
        raiz = null;
    }

    // Método para insertar un título en el árbol binario
    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        else if (comparacion > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }

    // Método para buscar un título en el árbol binario
    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(raiz, titulo);
    }

    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }

        int comparacion = string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase);
        if (comparacion == 0)
        {
            return true; // Título encontrado
        }
        else if (comparacion < 0)
        {
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecho, titulo);
        }
    }

    // Método para mostrar el menú
    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=====================");
            Console.WriteLine("   MENÚ DE BÚSQUEDA  ");
            Console.WriteLine("=====================");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("\nSeleccione una opción: ");
            
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string tituloBuscar = Console.ReadLine();
                bool encontrado = Buscar(tituloBuscar);
                Console.WriteLine(encontrado ? "Título encontrado." : "Título no encontrado.");
            }
            else if (opcion == "2")
            {
                Console.WriteLine("Cerrando el programa. ¡Hasta luego!");
                break;
            }
            else
            {
                Console.WriteLine("Opción incorrecta, por favor intente de nuevo.");
            }
        }
    }

    // Método principal para ejecutar el programa
    public static void Main(string[] args)
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Insertar títulos en el catálogo
        catalogo.Insertar("Revista de Ciencias");
        catalogo.Insertar("Revista de Tecnología");
        catalogo.Insertar("Revista de Historia");
        catalogo.Insertar("Revista de Arte");
        catalogo.Insertar("Revista de Salud");
        catalogo.Insertar("Revista de Naturaleza");
        catalogo.Insertar("Revista de Deportes");
        catalogo.Insertar("Revista de Educación");
        catalogo.Insertar("Revista de Música");
        catalogo.Insertar("Revista de Literatura");

        // Mostrar el menú
        catalogo.MostrarMenu();
    }
}
