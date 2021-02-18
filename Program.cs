using System;
using archivos;
namespace clase04
{
    class Program
    {
        static void Main(string[] args)
        {
            Archivos objArchivo = new Archivos();
            Console.WriteLine("Ingrese el numero (1) si desea leer el archivo, (2) si desea crear la salida, (3) si desea borrar el archivo");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    objArchivo.LeePorLotes();
                    break;
                case 2:
                    objArchivo.CreaSalida();
                    break;
                case 3:
                    objArchivo.BorrarArchivo();
                    break;
                default:
                    throw new ArithmeticException();
            }
        }
    }
}
