using Eleventa.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleventa.ConsoleApp
{
    public class Program
    {

        public static int Categoria, Operacion, Repetir_Ope;

        public static void Main(string[] args)
        {

            Identificar_Categoria();

            switch (Categoria)
            {

                case 1:

                    Console.Clear();

                    do
                    {

                        Operacion_Realizar();

                        switch (Operacion)
                        {

                            case 1:

                                Console.Clear();

                                Nuevo_Producto();

                                break;

                            case 2:

                                //Modificar Producto;

                                break;

                            case 3:

                                //Eliminar Producto

                                break;
                        }

                        Console.Clear();

                        Console.WriteLine("Desea Realizar otra operacion?:\n" +
                                        "1.- Si.\n" +
                                        "2.- No.");

                        Repetir_Ope = Convert.ToInt32(Console.ReadLine());

                        if(Repetir_Ope >= 3 || Repetir_Ope < 1)
                        {

                            Console.WriteLine("Porfavor Eligar una de las opciones Mostradas :D");

                        }

                    } while (Repetir_Ope > 2 || Repetir_Ope < 1);
                    break;

                case 2:

                    //Ventas

                    break;

                case 3:

                    //Inventario

                    break;

            }

            Console.ReadKey();

        }

        #region Identifar la Categoria
        public static int Identificar_Categoria()
        {

            do
            {

                Console.WriteLine("Indica la operacion que quieras hacer \n"
                                    + "1.- Productos \n"
                                    + "2.- Ventas \n"
                                    + "3.- Inventario");
                Categoria = Convert.ToInt32(Console.ReadLine());

                if((Categoria >= 4) || (Categoria < 1))
                {

                    Console.WriteLine("Porfavor ingrese una de las opciones mostradas :D");

                }

            } while (Categoria > 3 || Categoria < 1);

            return Categoria;

        }
        #endregion

        #region Identificar la Operacion en Productos
        public static int Operacion_Realizar()
        {

            do
            {

                Console.WriteLine("  :D --------- Productos --------- xD");
                Console.WriteLine("Que Operacion desear realizar?... \n"
                                     + "1.- Agregar Producto \n"
                                     + "2.- Modificar Producti \n"
                                     + "3.- Eliminar Producto");

                Operacion = Convert.ToInt32(Console.ReadLine());

                if ((Operacion >= 4) || (Operacion < 1))
                {

                    Console.WriteLine("Porfavor ingrese una de las opciones mostradas :D");

                }

            } while (Operacion > 3 || Categoria < 1);

            return Operacion;

        }
        #endregion

        #region Agregar Nuevo Producto
        public static void Nuevo_Producto()
        {

            int cVen, Inv; bool isCheked = false;

            DataTable dt = new DataTable();

            Product p = new Product();

            Console.Write(" -// Nuevo Producto \\-");
            Console.WriteLine("Descripcion: "); p.Descripcion = Console.ReadLine().ToString().Trim();
            Console.WriteLine("Codigo de Barras"); p.CodigoBarras = Console.ReadLine().ToString().Trim();

            do
            {

                Console.WriteLine("Se vende por...\n"
                    + "1.- Uniad/Pza \n"
                    + "2.- A Granel(Usa Decimales) \n"
                    + "3.- Como Paquete (Kit)");

                cVen = Convert.ToInt32(Console.ReadLine());

                if(cVen >= 4 || cVen < 1)
                {

                    Console.WriteLine("Porfavor elegir una de las Opciones Mostradas :D");

                }


            } while (cVen > 3 || cVen < 1);

            switch (cVen)
            {

                case 1:
                    p.Unidad_Venta = "Por Unidad/Pza";
                    break;

                case 2:
                    p.Unidad_Venta = "A Granel(Usa Decimales)";
                    break;

                case 3:
                    p.Unidad_Venta = "Como Paquete";
                    break;

            }

            Console.WriteLine("Los Departamentos son:");

            try
            {

                dt = BusinessLogicLayer.DepartmentBLL.Departamentos();

                foreach(DataRow item in dt.Rows)
                {

                    Console.WriteLine("{0}.- {1}", item["Id"].ToString(), item["Nombre"].ToString(), item["Descripcion"].ToString());

                }
                do
                {

                    Console.WriteLine("Departamento: "); p.IdDepartamento = Convert.ToInt32(Console.ReadLine());

                } while (p.IdDepartamento > dt.Rows.Count || p.IdDepartamento < 0);

                Console.WriteLine("Cantidad Actual del Producto");
                p.Cantidad = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Precio Costo: $");
                p.Costo = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Precio $: ");
                p.Precio = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Precio al Mayoreo $:");
                p.PrecioMayoreo = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ganancia $:");
                p.Ganancia = Convert.ToDouble(Console.ReadLine());

                do
                {

                    Console.WriteLine("El Producto usa Inventario \n"
                        + "1.- Si \n"
                        + "2.- No");

                    Inv = Convert.ToInt32(Console.ReadLine());

                    if (Inv == 1)
                    {

                        isCheked = true;

                    }
                    else if (Inv == 2)
                    {

                        isCheked = false;

                    }
                    else
                    {

                        Console.WriteLine("Porfavor eliga una de las Opciones Mostradas");

                    }

                } while (Inv > 2 || Inv < 1);

                switch (Inv)
                {

                    case 1:

                        p.Use_Inventory = isCheked;
                        Console.WriteLine("Cantidad Minima en el Inventario:"); p.InvMinima = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Cantidad Maxima en el Inventario: "); p.InvMaxima = Convert.ToInt32(Console.ReadLine());

                        break;

                    case 2:

                        p.Use_Inventory = isCheked;

                        break;

                }

                string msgError = BusinessLogicLayer.ProductBLL.NuevoProducto(p);

                if (string.IsNullOrEmpty(msgError))
                {

                    Console.WriteLine("Se inserte el Producto correctamente");

                }
                else
                {

                    Console.WriteLine(msgError);

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message.ToString());

            }

        }
        #endregion

    }
}
