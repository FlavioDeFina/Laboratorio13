using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio13
{
    internal class Interfaz
    {
        public static int[] Limite = new int[100];
        public static int cont = 0;
        public static int PantallaPrincipal()
        {
            string texto1 = "================================\n" +
              "Encuestas de Calidad\n" +
              "================================\n" +
              "1: Realizar Encuesta\n" +
              "2: Ver datos registrados\n" +
              "3: Eliminar un dato\n" +
              "4: Ordenar datos de menor a mayor\n" +
              "5: Salir\n" +
              "================================\n";

            Console.Write(texto1);
            return getEntero("Ingrese una opción: ", texto1);
        }
        public static int EncuestaSatisfaccion()
        {
            Console.WriteLine("===================================\n" +
              "Nivel de Satisfacción\n" +
              "===================================\n" +
              "¿Qué tan satisfecho está con la\n" +
              "atención de nuestra tienda?\n" +
              "1: Nada satisfecho\n" +
              "2: No muy satisfecho\n" +
              "3: Tolerable\n" +
              "4: Satisfecho\n" +
              "5: Muy satisfecho\n" +
              "===================================\n");
            Console.Write("Ingrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());
            if (opcion <= 5 && opcion > 0)
            {
                Limite[cont] = opcion;
                cont++;
                return NivelSatisfaccion();
            }
            else
            {
                Console.Clear();
                return EncuestaSatisfaccion();
            }

        }
        public static int NivelSatisfaccion()
        {
            Console.Clear();
            Console.WriteLine("===================================\n" +
              "Nivel de Satisfacción\n" +
              "===================================\n" +
              "\n\n" +
              "¡Gracias por participar!\n" +
              "\n\n" +
              "===================================\n" +
              "Presione una tecla para\n" +
              "regresar al menú ...\n");

            Console.ReadKey();
            return PantallaPrincipal();
        }
        public static int DatosRegistrados()
        {
            Console.WriteLine("===================================\n" +
              "Ver datos registrados\n" +
              "===================================\n");
            if (cont == 0)
            {
                Console.WriteLine("No extisten notas");
            }

            for (int i = 0; i < cont; i++)
            {
                Console.Write("[" + Limite[i] + "] ");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" \n" +
                "================================\n" +
                "(1) = Nada satisfecho\n" +
                "(2) = No muy satisfecho\n" +
                "(3) = Tolerable\n" +
                "(4) = Satisfecho\n" +
                "(5) = Muy satisfecho\n" +
                "================================\n");
            int[] conteoOpciones = new int[6];

            for (int i = 0; i < cont; i++)
            {
                int OPCION = Limite[i];
                conteoOpciones[OPCION]++;
            }

            Console.Write("\n\n");
            for (int i = 1; i < conteoOpciones.Length; i++)
            {
                Console.WriteLine(i + ": " + conteoOpciones[i] + " personas\t\t");
            }
            Console.WriteLine("\n===================================\n" +
              "Presione una tecla para regresar ...\n");
            Console.ReadLine();
            Console.Clear();

            return PantallaPrincipal();
        }
        public static int ElimirasDatos()
        {
            Console.WriteLine("===================================\n" +
              "Eliminar un dato\n" +
              "===================================\n\n");

            for (int i = 0; i < cont; i++)
            {
                Console.Write(i + ":[" + Limite[i] + "] ");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n===================================\n" +
              "Ingrese la posición a eliminar: ");
            int posicion = int.Parse(Console.ReadLine());

            Console.Write("\n===================================\n");

            if (posicion >= 0 && posicion < Limite.Length)
            {
                int i;
                for (i = posicion; i < cont - 1; i++)
                {
                    Limite[i] = Limite[i + 1];
                }
                cont = cont - 1;
            }
            else
            {
                Console.WriteLine("La posición ingresada no es válida.");
            }
            for (int i = 0; i < cont; i++)
            {
                Console.Write(i + ":[" + Limite[i] + "] ");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n===================================\n" +
              "Presione una tecla para regresar ...\n");

            Console.ReadLine();
            Console.Clear();

            return PantallaPrincipal();
        }
        public static int Ordenar()
        {
            Console.Clear();
            Console.WriteLine("===================================\n" +
              "Ordenar datos\n" +
              "===================================\n\n");
            for (int i = 0; i < cont; i++)
            {
                Console.Write(i + ":[" + Limite[i] + "] ");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n===================================\n");
            int ordenado = 0;
            while (ordenado == 0)
                ordenado = 1;

            for (int i = 0; i < cont; i++)
            {
                for (int j = 0; j < cont - 1; j++)
                {
                    if (Limite[j] > Limite[j + 1])
                    {
                        int aux = Limite[j + 1];
                        Limite[j + 1] = Limite[j];
                        Limite[j] = aux;
                        ordenado = 0;
                    }
                }
            }

            if (cont == 0)
            {
                Console.WriteLine("No extisten notas");
            }

            for (int i = 0; i < cont; i++)
            {
                Console.Write(i + ":[" + Limite[i] + "]");
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n===================================\n" +
              "Presione una tecla para regresar ...\n");

            Console.ReadLine();
            Console.Clear();

            return PantallaPrincipal();
        }
        public static int getEntero(string prefijo, string reemplazo)
        {
            int respuesta = 0;
            bool correcto = false;

            do
            {
                string numeroTexto = getTextoPantalla(prefijo);
                correcto = int.TryParse(numeroTexto, out respuesta);

                if (!correcto)
                {
                    Console.Clear();
                    Console.WriteLine(reemplazo);
                    Console.WriteLine("Ingresa un número válido");
                }

            } while (!correcto);

            return respuesta;
        }
        public static string getTextoPantalla(string prefijo)

        {
            Console.Write(prefijo);

            return Console.ReadLine();
        }
    }
}
