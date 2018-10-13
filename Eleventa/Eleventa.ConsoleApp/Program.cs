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

                #region Productos
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

                                Console.Clear();
                                Modificar_Producto();

                                break;

                            case 3:

                                Console.Clear();

                                Eliminar_Producto();

                                break;
                        }

                        Console.Clear();

                        Console.WriteLine("\tDesea Realizar otra operacion?:\n" +
                                        "\t1.- Si.\n" +
                                        "\t2.- No.");

                        Repetir_Ope = Convert.ToInt32(Console.ReadLine());

                        if(Repetir_Ope >= 3 || Repetir_Ope < 1)
                        {

                            Console.WriteLine("\tPorfavor Eligar una de las opciones Mostradas :D");

                        }

                        Console.Clear();

                    } while (Repetir_Ope == 1);
                    break;
                #endregion

                case 2:

                    //Ventas

                    break;

                case 3:

                    //Inventario

                    break;

            }

            Console.ReadKey();

        }

        #region Metodos de Productos

        #region Identifar la Categoria
        public static int Identificar_Categoria()
        {

            do
            {

                Console.WriteLine("\n");
                Console.WriteLine("\tIndica la operacion que quieras hacer \n"
                                    + "\t1.- Productos \n"
                                    + "\t2.- Ventas \n"
                                    + "\t3.- Inventario");
                Categoria = Convert.ToInt32(Console.ReadLine());

                if((Categoria >= 4) || (Categoria < 1))
                {

                    Console.WriteLine("\tPorfavor ingrese una de las opciones mostradas :D");

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

                Console.WriteLine("\n");
                Console.WriteLine("\t:D --------- Productos --------- xD\n");
                Console.WriteLine("\tQue Operacion desear realizar?... \n"
                                     + "\t1.- Agregar Producto \n"
                                     + "\t2.- Modificar Producti \n"
                                     + "\t3.- Eliminar Producto");

                Operacion = Convert.ToInt32(Console.ReadLine());

                if ((Operacion >= 4) || (Operacion < 1))
                {

                    Console.WriteLine("\tPorfavor ingrese una de las opciones mostradas :D");

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

            Console.WriteLine("\n");
            Console.Write("\t -// Nuevo Producto \\-\n");
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

                    Console.WriteLine("\tPorfavor elegir una de las Opciones Mostradas :D");

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

                    Console.WriteLine("\t{0}.- {1}", item["Id"].ToString(), item["Nombre"].ToString(), item["Descripcion"].ToString());

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

                    Console.Write("\nSe inserto el Producto correctamente");
                    Console.ReadLine();

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

        #region Eliminar Producto
        public static void Eliminar_Producto()
        {

            DataTable dt = new DataTable(); Product p = new Product();

            Console.WriteLine("\n");
            Console.WriteLine("-----Eliminar-----\n");
            Console.WriteLine("Ingresa el Codifo de Barras que quieres Eliminar"); p.CodigoBarras = Console.ReadLine().ToString().Trim();

            try
            {

                Console.WriteLine("Se llavara acabo la eliminacion del producto: ");
                dt = BusinessLogicLayer.ProductBLL.Productos(p.CodigoBarras);

                foreach (DataRow item in dt.Rows)
                {

                    Console.WriteLine("\tId: {0}\n \tDescripcion: {1}\n \tCodigo de Barras: {2}\n \tUnidad de Venta: {3}\n \tDepartamento: {4}\n \tCantidad: {5}\n \tCosto: {6}\n \tPrecio: {7}\n \tPrecio al Mayoreo: {8}\n \tGanancia: {9}\n \tUso de Inventario: {10}\n \tInventario Minimo: {11}\n \tInventario Maximo: {12}\n",
                        item["Id"].ToString(), item["Descripcion"].ToString(), item["Codigo de Barras"].ToString(), item["Unidad de Venta"].ToString(),
                        item["Departamento"].ToString(), item["Cantidad"].ToString(), item["Costo"].ToString(), item["Precio"].ToString(), item["Precio al Mayoreo"].ToString(), item["Ganancia"].ToString(),
                        item["Uso de Inventario"].ToString(), item["Inventario Minimo"].ToString(), item["Inventario Maximo"].ToString());

                    Console.WriteLine("Desea Borrar el Producto?...\n"
                        + "1.- Si\n"
                        +"2.- No");
                    int delete = Convert.ToInt32(Console.ReadLine());

                    if(delete == 1)
                    {

                        string msgError = BusinessLogicLayer.ProductBLL.Eliminar_Producto(p.CodigoBarras);

                        if (string.IsNullOrEmpty(msgError))
                        {

                            Console.WriteLine("\n \t Se Borro el Producto correctamente");
                            Console.ReadLine();
                        }
                        else
                        {

                            Console.Write(msgError);

                        }

                    }

                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }

        }
        #endregion

        #region Modificar Producto

        public static void Modificar_Producto()
        {

            Product p = new Product(); DataTable dt = new DataTable(); DataTable dep = new DataTable();
            int modificar, camp, cVen, Inv, mod; bool isCheked = false;

            Console.WriteLine("\n");
            Console.WriteLine("----------Modificar Producto-----------\n");
            Console.WriteLine("Ingrese el codigo de barras del producto que quiera eliminar");
            p.CodigoBarras = Console.ReadLine();

            try
            {

                Console.WriteLine("Este el es Producto que deseas modificar?...");
                dt = BusinessLogicLayer.ProductBLL.Productos(p.CodigoBarras);

                foreach (DataRow item in dt.Rows)
                {

                    Console.WriteLine("\t1.- Id: {0}\n \t2.- Descripcion: {1}\n \t3.- Codigo de Barras: {2}\n \t4.- Unidad de Venta: {3}\n \t5.- Departamento: {4}\n \t6.- Cantidad: {5}\n \t7.-Costo: {6}\n \t8.- Precio: {7}\n \t9.- Precio al Mayoreo: {8}\n \t10. Ganancia: {9}\n \t11.- Uso de Inventario: {10}\n \t12.- Inventario Minimo: {11}\n \t13.- Inventario Maximo: {12}\n",
                        item["Id"].ToString(), item["Descripcion"].ToString(), item["Codigo de Barras"].ToString(), item["Unidad de Venta"].ToString(),
                        item["Departamento"].ToString(), item["Cantidad"].ToString(), item["Costo"].ToString(), item["Precio"].ToString(), item["Precio al Mayoreo"].ToString(), item["Ganancia"].ToString(),
                        item["Uso de Inventario"].ToString(), item["Inventario Minimo"].ToString(), item["Inventario Maximo"].ToString());

                }
                do
                {

                    Console.WriteLine("Desea Modificar el Producto?...\n"
                        + "1.- Si\n"
                        + "2.- No");

                    modificar = Convert.ToInt32(Console.ReadLine());

                } while (modificar > 2 || modificar < 1);

                if(modificar == 1)
                {

                    Console.WriteLine("\n Selecciona el campo que deseas modificar");
                    camp = Convert.ToInt32(Console.ReadLine());

                    do
                    {

                        switch (camp)
                        {

                            case 1:

                                Console.WriteLine("\n\tLo sentimos no podemos modificar el Id del Producto");

                                break;

                            case 2:

                                Console.WriteLine("\nIngresa una nueva Descripcion"); p.Descripcion = Console.ReadLine();

                                break;

                            case 3:

                                Console.WriteLine("\nIngresa un nuevo Codigo de Barras"); p.CodigoBarras = Console.ReadLine();

                                break;

                            case 4:
                                do
                                {

                                    Console.WriteLine("Se vende por...\n"
                                        + "1.- Uniad/Pza \n"
                                        + "2.- A Granel(Usa Decimales) \n"
                                        + "3.- Como Paquete (Kit)");

                                    cVen = Convert.ToInt32(Console.ReadLine());

                                    if (cVen >= 4 || cVen < 1)
                                    {

                                        Console.WriteLine("\tPorfavor elegir una de las Opciones Mostradas :D");

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

                                break;

                            case 5:

                                Console.WriteLine("\nLos Departamentos son...");

                                dep = BusinessLogicLayer.DepartmentBLL.Departamentos();

                                foreach (DataRow item in dep.Rows)
                                {

                                    Console.WriteLine("\t{0}.- {1}", item["Id"].ToString(), item["Nombre"].ToString(), item["Descripcion"].ToString());

                                }
                                do
                                {

                                    Console.WriteLine("Departamento: "); p.IdDepartamento = Convert.ToInt32(Console.ReadLine());

                                } while (p.IdDepartamento > dep.Rows.Count || p.IdDepartamento < 0);

                                break;

                            case 7:

                                Console.WriteLine("\nIngrasa el nuevo costo"); p.Costo = Convert.ToDouble(Console.ReadLine());

                                break;

                            case 8:

                                Console.WriteLine("\n Ingresa el nuevo Precio del Producto"); p.Precio = Convert.ToDouble(Console.ReadLine());

                                break;

                            case 9:

                                Console.WriteLine("\n Ingresa el nuevo Precio de Mayoreo"); p.PrecioMayoreo = Convert.ToDouble(Console.ReadLine());

                                break;

                            case 10:

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
                                        p.InvMinima = 0;
                                        p.InvMaxima = 0;

                                        break;

                                }

                                break;

                        }

                        Console.WriteLine("Deseas modificar algun otro campo?\n"
                            +"1.- Si\n"
                            +"2.- No");
                        mod = Convert.ToInt32(Console.ReadLine());

                    } while (mod == 1);

                    string msgError = BusinessLogicLayer.ProductBLL.Modificar_Producto(p);

                    if (string.IsNullOrEmpty(msgError))
                    {

                        Console.WriteLine("\tSE MODIFICO EL PRODUCTO CON EXITO :D!!!!!");
                        Console.ReadLine();

                    }
                    else
                    {

                        Console.WriteLine(msgError);

                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }

        }

        #endregion

        #endregion

    }
}
