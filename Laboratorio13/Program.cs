using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = Interfaz.PantallaPrincipal();
            do
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        opcion = Interfaz.EncuestaSatisfaccion();
                        break;
                    case 2:
                        Console.Clear();
                        opcion = Interfaz.DatosRegistrados();
                        break;
                    case 3:
                        Console.Clear();
                        opcion = Interfaz.ElimirasDatos();
                        break;
                    case 4:
                        Console.Clear();
                        opcion = Interfaz.Ordenar();
                        break;
                    case 0:
                    default:
                        Console.Clear();
                        opcion = Interfaz.PantallaPrincipal();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
