using ConsoleTables;
using Ejercicio01Vector;
using System.Formats.Asn1;
using Ejercicio01Vector;


namespace Ejecicio1DeVector1._0
{
    internal class Program
    {
        const double Min_temperatura = -10;
        const double Max_temperatura = 40;
        static void Main(string[] args)
        {
            double[] temperaturas = new double[7];
             bool seguir= true;
            do
            {
                 
               
                MostarMenu();
                int OpcionesSeleccionar =IngresoDeDatos.PedirIntEnRango("Seleccione:", 1, 8);
                switch (OpcionesSeleccionar)
                {
                    case 1:
                        GenerarLasTemperaturas(temperaturas);
                        break;
                    case 2:
                        ModificarDatos(temperaturas);
                        break;
                    case 3:
                        ListarTemperaturas(temperaturas);
                        break;
                    case 4:
                        DatosEstadisticos(temperaturas);
                        break;
                    case 5:
                        MostrarSuperiorPromedio(temperaturas);
                        break;
                    case 6:
                        MostrarInferiorPromedio(temperaturas);
                        break;
                    case 7:
                        seguir = false;
                        break;
                }

            } while (seguir);
            Console.WriteLine("Fin de la Aplicación");
        }

        private static void MostrarInferiorPromedio(double[] temperaturas)
        {
            var Promedio = HallarPromedio(temperaturas);
            Console.Clear();
            Console.WriteLine("Marcar Inferiores al promedio");
            Console.WriteLine(value: $"El promedio es:{Promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Celsius", "Inf.Promedio");
            foreach (var TempEnArray in temperaturas)
            {
                if (TempEnArray < Promedio)
                {
                    tabla.AddRow(TempEnArray, "*");
                }
                else
                {
                    tabla.AddRow(TempEnArray, "");
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizda("Mostar superior al promedio");
        }

        private static void MostrarSuperiorPromedio(double[] temperaturas)
        {
            var Promedio = HallarPromedio(temperaturas);
            Console.Clear();
            Console.WriteLine("Marcar Superiores al promedio");
            Console.WriteLine(value: $"El promedio es:{Promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Celsius", "Sup.Promedio");
            foreach (var TempEnArray in temperaturas)
            {
                if (TempEnArray>Promedio)
                {
                    tabla.AddRow(TempEnArray, "*");
                }
                else
                {
                    tabla.AddRow(TempEnArray, "");
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizda("Mostar superior al promedio");
        }

        private static void DatosEstadisticos(double[] temperaturas)
        {
            var Maxtemp = HallarMax(temperaturas);
            var Mintemp = HallarMinimo(temperaturas);
            var Promedio = HallarPromedio(temperaturas);
            Console.WriteLine($"La maxima temperatura es :{Maxtemp}");
            Console.WriteLine($"La minima temperatura es :{Mintemp}");
            Console.WriteLine($"El promedio es de:{Promedio.ToString("N2")} ");
            Console.ReadLine();
            TareaFinalizda("Datos estadisticos");
        }

        private static double HallarPromedio(double[] temperaturas)
        {
            double promedio = 0;
            foreach (var TempEnArray in temperaturas)
            {
                promedio += TempEnArray;
            }
            return promedio / temperaturas.Length;
        }

        private static object HallarMinimo(double[] temperaturas)
        {
            double Minimo = Max_temperatura;
            foreach (var TempEnArray in temperaturas)
            {
                if (TempEnArray  < Minimo)
                {
                    Minimo = TempEnArray;
                }
            }
            return Minimo;
        }

        private static double HallarMax(double[] temperaturas)
        {
            double Maximo = Min_temperatura;
            foreach (var TempEnArray in temperaturas)
            {
                if (TempEnArray>Maximo)
                {
                    Maximo = TempEnArray;
                }
            }
            return Maximo;
        }

        private static void ModificarDatos(double[] temperaturas)
        {
           do
           {
            Console.Clear();
            Console.Write("Modificación de datos");
            ListarTemperaturas(temperaturas);
           
                var index =IngresoDeDatos.PedirDoubleEnRango("Ingrese el indice para modificar:", 1, temperaturas.Length);
                Console.WriteLine($"Valor anterior:{temperaturas[(int)(index - 1)]} ");
                double nuevatemperatura;
               do
               {
                    nuevatemperatura =IngresoDeDatos.PedirDoubleEnRango("Ingrese una nueva temperatura:", Min_temperatura, Max_temperatura);

                    if (Existe(nuevatemperatura, temperaturas))
                    {
                        Console.WriteLine("La temperatura ya existe");
                    }
                    else
                    {
                        break;
                    }

               } while (true);
                temperaturas[(int)(index - 1)] = nuevatemperatura;
                var siguirModificando =IngresoDeDatos.PedirCharEnRango("Desea seguir Modificando S/N",'s','n');
           } while (true);
             TareaFinalizda("Modificacion finalizada");
        }

       

        private static void ListarTemperaturas(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Listados de Temperaturas");
            var tabla = new ConsoleTable("Celcius","Farenheit");
            foreach (double TempEnArray in temperaturas)
            {
                var Farenheit = convertToFah(TempEnArray);
                tabla.AddRow(TempEnArray, Farenheit);
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizda("Listado finalizado");
        }

        private static double convertToFah(double celcius) => 1.8 * celcius + 32;
       

        private static void GenerarLasTemperaturas(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Temperaturas");
            for (int i = 0; i <temperaturas.Length; i++)
            {
                double TempIngresada;
                do
                {
                    TempIngresada =IngresoDeDatos.PedirDoubleEnRango("Ingrese las temperatuas:", Min_temperatura, Max_temperatura);
                   
                    
                    if (Existe(TempIngresada,temperaturas))
                    {
                        Console.WriteLine("Esa temperatura ya existe");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                temperaturas[i] = TempIngresada;
            }
            TareaFinalizda("Ingreso de datos finalizado");
        }

        private static bool Existe(double tempIngresada, double[] temperaturas)
        {
          
            foreach (double tempEnArray in temperaturas)
            {
                if (tempIngresada==tempEnArray)
                {
                    return true;
                }
            }
            return false;
        }

        private static void TareaFinalizda(string mensaje)
        {
            Console.WriteLine($"{mensaje }...ENTER para continuar");
            Console.ReadLine();
        }

        private static void MostarMenu()
        {
            Console.Clear();
            Console.WriteLine("1-Ingresar datos");
            Console.WriteLine("2-Modificar datos");
            Console.WriteLine("3-Listar temperaturas con sus equivalentes");
            Console.WriteLine("4-Datos estadisticos");
            Console.WriteLine("5-Ver superiores al promedio");
            Console.WriteLine("6-Ver inferiores al promedio");
            Console.WriteLine("7-Salir");

        }
    }
}