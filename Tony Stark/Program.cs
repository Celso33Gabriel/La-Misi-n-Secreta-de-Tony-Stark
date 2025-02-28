using System;
using System.IO;

class Program
{
    // Directorio y archivo donde se guardan los inventos de Tony Stark
    static string directorio = "LaboratorioAvengers";
    static string archivo = Path.Combine(directorio, "inventos.txt");

    static void Main()
    {
        // Verifica si el directorio existe, si no, lo crea
        if (!Directory.Exists(directorio))
            Directory.CreateDirectory(directorio);

        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("--- Misión Secreta de Tony Stark ---");
            Console.WriteLine("1. Crear archivo de inventos");
            Console.WriteLine("2. Agregar invento");
            Console.WriteLine("3. Leer inventos línea por línea");
            Console.WriteLine("4. Leer todo el archivo");
            Console.WriteLine("5. Copiar archivo a Backup");
            Console.WriteLine("6. Mover archivo a ArchivosClasificados");
            Console.WriteLine("7. Crear carpeta ProyectosSecretos");
            Console.WriteLine("8. Listar archivos en LaboratorioAvengers");
            Console.WriteLine("9. Eliminar archivo inventos.txt");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1: CrearArchivo(); break;
                case 2:
                    Console.Write("Ingrese el invento: ");
                    AgregarInvento(Console.ReadLine());
                    break;
                case 3: LeerLineaPorLinea(); break;
                case 4: LeerTodoElTexto(); break;
                case 5: CopiarArchivo("Backup"); break;
                case 6: MoverArchivo("ArchivosClasificados"); break;
                case 7: CrearCarpeta("ProyectosSecretos"); break;
                case 8: ListarArchivos(); break;
                case 9: EliminarArchivo(); break;
            }
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        } while (opcion != 0);
    }

    // Crea el archivo de inventos con datos iniciales
    static void CrearArchivo()
    {
        try
        {
            File.WriteAllText(archivo, "1. Traje Mark I\n2. Reactor Arc\n3. Inteligencia Artificial JARVIS\n");
            Console.WriteLine("Archivo creado exitosamente.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Agrega un invento al archivo sin sobrescribir el contenido
    static void AgregarInvento(string invento)
    {
        try
        {
            File.AppendAllText(archivo, invento + "\n");
            Console.WriteLine("Invento agregado.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Lee y muestra el archivo línea por línea
    static void LeerLineaPorLinea()
    {
        try
        {
            foreach (var linea in File.ReadLines(archivo))
                Console.WriteLine(linea);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Lee y muestra todo el contenido del archivo de una vez
    static void LeerTodoElTexto()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(archivo));
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Copia el archivo inventos.txt a una carpeta de respaldo
    static void CopiarArchivo(string destino)
    {
        try
        {
            Directory.CreateDirectory(destino);
            File.Copy(archivo, Path.Combine(destino, "inventos_backup.txt"), true);
            Console.WriteLine("Archivo copiado a " + destino);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Mueve el archivo a la carpeta especificada
    static void MoverArchivo(string destino)
    {
        try
        {
            Directory.CreateDirectory(destino);
            File.Move(archivo, Path.Combine(destino, "inventos.txt"));
            Console.WriteLine("Archivo movido a " + destino);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Crea una nueva carpeta en el directorio de trabajo
    static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            Directory.CreateDirectory(nombreCarpeta);
            Console.WriteLine("Carpeta creada: " + nombreCarpeta);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Lista todos los archivos en la carpeta del laboratorio
    static void ListarArchivos()
    {
        try
        {
            string[] archivos = Directory.GetFiles(directorio);
            foreach (var arch in archivos) Console.WriteLine(arch);
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }

    // Elimina el archivo después de hacer una copia de seguridad
    static void EliminarArchivo()
    {
        try
        {
            if (File.Exists(archivo))
            {
                CopiarArchivo("Backup");
                File.Delete(archivo);
                Console.WriteLine("Archivo eliminado.");
            }
            else Console.WriteLine("El archivo no existe.");
        }
        catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); }
    }
}
