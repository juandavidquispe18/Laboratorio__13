using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio__13
{
    internal class Program {

        static List<int> resultados = new List<int>();
        static void Main() {

            int opcion;
            do {

                Console.Clear();
                mostrar_menu();
                opcion = leer_opcion();
                procesar_opcion(opcion);

            } while (opcion != 5);
        }

        static void mostrar_menu() {

            Console.WriteLine("" +
                "================================\n" +
                "Encuestas de Calidad\n" +
                "================================\n" +
                "1: Realizar Encuesta\n" +
                "2: Ver datos registrados\n" +
                "3: Eliminar un dato\n" +
                "4: Ordenar datos de menor a mayor\n" +
                "5: Salir\n" +
                "================================");
        }

        static void procesar_opcion(int opcion) {

            switch (opcion) {

                case 1:
                    crear_encuesta();
                    break;
                case 2:
                    visualizar_registro();
                    break;
                case 3:
                    anular_dato();
                    break;
                case 4:
                    organizar_datos();
                    break;
                case 5:
                    Console.WriteLine("Cerrando Programa. ¡Hasta luego!");
                    break;
            }
        }

        static int leer_opcion() {

            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5) {

                Console.WriteLine("Error: Opción no válida.");
                Console.Write("Ingrese una opción: ");
            }
            return opcion;
        }

        static void crear_encuesta() {

            Console.Clear();
            Console.WriteLine("" +
                "================================\n" +
                "Nivel de Satisfacción\n" +
                "================================\n" +
                "¿Qué tan satisfecho está con la\n" +
                "atención de nuestra tienda?\n" +
                "1: Nada satisfecho\n" +
                "2: No muy satisfecho\n" +
                "3: Tolerable\n" +
                "4: Satisfecho\n" +
                "5: Muy satisfecho\n" +
                "================================");

            int respuesta;
            do {
                Console.Write("Ingrese una opción: ");
            } while (!int.TryParse(Console.ReadLine(), out respuesta) || respuesta < 1 || respuesta > 5);

            Console.Clear();
            resultados.Add(respuesta);
            Console.WriteLine("====================================");
            Console.WriteLine("Nivel de Satisfacción");
            Console.WriteLine("====================================");
            Console.WriteLine("¡Gracias por participar!");
            Console.WriteLine("====================================");
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
        }

        static void visualizar_registro() {

            Console.Clear();
            Console.WriteLine("Resultados de las encuestas:");

            if (resultados.Count > 0) {

                Dictionary<int, int> conteo_opc = new Dictionary<int, int>();
                for (int i = 0; i < resultados.Count; i++) {

                    Console.Write($"[{resultados[i]}]   ");
                }

                for (int i = 0; i < resultados.Count; i++) {

                    int opcion = resultados[i];

                    if (conteo_opc.ContainsKey(opcion)) {

                        conteo_opc[opcion]++;
                    }
                    else
                    {
                        conteo_opc[opcion] = 1;
                    }
                }

                for (int i = 1; i <= 5; i++) {

                    Console.WriteLine("");
                    if (conteo_opc.ContainsKey(i)) {

                        Console.WriteLine($"{conteo_opc[i]:D2} personas: {opcion_satisfaccion(i)}");
                    }
                    else
                    {
                        Console.WriteLine($"00 personas: {opcion_satisfaccion(i)}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay datos registrados.");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
        }

        static string opcion_satisfaccion(int opcion) {

            switch (opcion) {

                case 1:
                    return "Nada satisfecho";
                case 2:
                    return "No muy satisfecho";
                case 3:
                    return "Tolerable";
                case 4:
                    return "Satisfecho";
                case 5:
                    return "Muy satisfecho";
                default:
                    return "Opción no válida";
            }
        }

        static void anular_dato() {

            Console.Clear();
            if (resultados.Count > 0) {

                Console.WriteLine("====================================");
                Console.WriteLine("Eliminar un dato");
                Console.WriteLine("====================================");

                mostrar_conteo_opciones(resultados);

                int eliminar_psc;
                do
                {
                    Console.Write("Ingrese la posición a eliminar: ");
                } while (!int.TryParse(Console.ReadLine(), out eliminar_psc) || eliminar_psc < 1 || eliminar_psc > resultados.Count);

                resultados.RemoveAt(eliminar_psc - 1);

                Console.WriteLine("\n====================================");
                Console.WriteLine("Resultados de las encuestas después de eliminar:");
                Console.WriteLine("====================================");

                mostrar_conteo_opciones(resultados);
            }
            else
            {
                Console.WriteLine("No hay datos registrados para eliminar.");
            }
            Console.WriteLine("");    
            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
        }

        static void organizar_datos() {

            Console.Clear();
            if (resultados.Count > 0) {

                Console.WriteLine("====================================");
                Console.WriteLine("Ordenar datos");
                Console.WriteLine("====================================");
                mostrar_conteo_opciones(resultados);
                resultados.Sort();
                Console.WriteLine("\nResultados de las encuestas después de ordenar:");
                Console.WriteLine("====================================");
                mostrar_conteo_opciones(resultados);
            }
            Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
            Console.ReadKey(true);
        }

        static void mostrar_conteo_opciones(List<int> opciones) {

            for (int i = 0; i < opciones.Count; i++)
            {
                Console.Write($"{i:D3}:[{opciones[i]:D2}]   ");
            }
            Console.WriteLine("\n====================================");
        }
    }
}
