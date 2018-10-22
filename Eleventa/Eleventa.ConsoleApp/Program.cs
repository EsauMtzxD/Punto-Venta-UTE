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

        static int quantityOfItems = 0;
        static double subtotal = 0;
        static double iva = 0;
        static double total = 0;

        public static int Categoria, Operacion, Repetir_Ope = 0, res;

        public static void Main(string[] args)
        {

            DataTable dtShoopping = new DataTable();

            do
            {

                Console.Clear();

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

                            if (Repetir_Ope >= 3 || Repetir_Ope < 1)
                            {

                                Console.WriteLine("\tPorfavor Eligar una de las opciones Mostradas :D");

                            }

                            Console.Clear();

                        } while (Repetir_Ope == 1);
                        break;
                    #endregion

                    case 2:

                        updateColums(dtShoopping);

                            Ventas(dtShoopping);

                        break;

                    case 3:

                            Inventario();

                        break;

                }

                Console.Clear();

                Console.WriteLine("Desea Hacer otra cosa?\n"
                    +"1.- Si\n"
                    +"2.- No");
                res = Convert.ToInt32(Console.ReadLine());

            } while (res == 1);

            Console.ReadKey();

        }



        #region Identifar la Categoria
        /// <summary>
        /// Metodo Simple para identificar las opciones del usuario
        /// </summary>
        /// <returns></returns>
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

        #region Metodos de Productos

        #region Identificar la Operacion en Productos
        /// <summary>
        /// Metodo simple para observar las operaciones que se pueden hacer en la categoria de producto
        /// </summary>
        /// <returns></returns>
        public static int Operacion_Realizar()
        {

            do
            {

                Console.WriteLine("\n");
                Console.WriteLine("\t:D --------- Productos --------- xD\n");
                Console.WriteLine("\tQue Operacion deseas realizar?... \n"
                                     + "\t1.- Agregar Producto \n"
                                     + "\t2.- Modificar Producto \n"
                                     + "\t3.- Eliminar Producto");

                Operacion = Convert.ToInt32(Console.ReadLine());

                if ((Operacion >= 4) || (Operacion < 1))
                {

                    Console.WriteLine("\n\tPorfavor ingrese una de las opciones mostradas :D");

                }

            } while (Operacion > 3 || Categoria < 1);

            return Operacion;

        }
        #endregion

        #region Agregar Nuevo Producto
        /// <summary>
        /// Metodo para ir ingresando los datos a la BD en la Tabla Producto
        /// </summary>
        public static void Nuevo_Producto()
        {

            int cVen, Inv; bool isCheked = false;

            // Data Table para mostrar los Departamentos Existentes
            DataTable dt = new DataTable();

            // Crear un Objeto de tipo producto para in guardando los datos a ingresar
            Product p = new Product();

            Console.WriteLine("\n");
            Console.Write("\t -// Nuevo Producto \\-\n");
            Console.WriteLine("Descripcion: "); p.Descripcion = Console.ReadLine().ToString().Trim();
            Console.WriteLine("Codigo de Barras"); p.CodigoBarras = Console.ReadLine().ToString().Trim();

            dt = BusinessLogicLayer.DepartmentBLL.Departamentos();

            Console.WriteLine("Los Departamentos son:");

            // FOREACH que ira recorrendo el Data Table y Mostrando los datos que tiene la Entidad
            foreach (DataRow item in dt.Rows)
            {

                Console.WriteLine("\t{0}.- {1}", item["Id"].ToString(), item["Nombre"].ToString(), item["Descripcion"].ToString());

            }
            do
            {

                Console.WriteLine("Departamento: "); p.IdDepartamento = Convert.ToInt32(Console.ReadLine());

            } while (p.IdDepartamento > dt.Rows.Count || p.IdDepartamento < 0);

            do
            {

                Console.WriteLine("Se vende por...\n"
                    + "1.- Uniad/Pza \n"
                    + "2.- A Granel(Usa Decimales) \n"
                    + "3.- Como Paquete (Kit)");

                cVen = Convert.ToInt32(Console.ReadLine());

                if(cVen >= 4 || cVen < 1)
                {

                    Console.WriteLine("\n\tPorfavor elegir una de las Opciones Mostradas :D");

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

            try
            {

                Console.WriteLine("Precio Costo: $");
                p.Costo = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ganancia %");
                p.Ganancia = Convert.ToDouble(Console.ReadLine());

                double ganancia = p.Costo + (p.Costo * (p.Ganancia / 100));

                Console.Write("Precio $: " + ganancia + "\n");
                p.Precio = ganancia;

                Console.WriteLine("Precio al Mayoreo $:");
                p.PrecioMayoreo = Convert.ToDouble(Console.ReadLine());

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

                        Console.WriteLine("\n\tPorfavor eliga una de las Opciones Mostradas");

                    }

                } while (Inv > 2 || Inv < 1);

                switch (Inv)
                {

                    case 1:

                        p.Use_Inventory = isCheked;
                        Console.WriteLine("Cantidad Actual del Producto"); p.Cantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Cantidad Minima en el Inventario:"); p.InvMinima = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Cantidad Maxima en el Inventario: "); p.InvMaxima = Convert.ToInt32(Console.ReadLine());

                        break;

                    case 2:

                        p.Use_Inventory = isCheked;

                        break;

                }

                // Llamar el Metodo de la CLASE PRODUCTBLL e ingresando el objeto producto que creamos antes
                string msgError = BusinessLogicLayer.ProductBLL.NuevoProducto(p);

                // Validar si el  mensaje de error esta vacio o es nulo
                if (string.IsNullOrEmpty(msgError))
                {

                    // Si esta vacio o es nulo entonces mostrara un mensaje que dija que si
                    // Se guardao los datos correctamente
                    Console.Write("\n\tSe inserto el Producto correctamente");
                    Console.ReadLine();

                }
                else
                {

                    //Y sii el mensaje no esta vacio entonces mostrar el mensaje
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
        /// <summary>
        /// Metodo para Eliminar los datos de la BD
        /// </summary>
        public static void Eliminar_Producto()
        {

            DataTable dt = new DataTable(); Product p = new Product(); Product old = new Product();
            string barcode = string.Empty;

            Console.WriteLine("\n");
            Console.WriteLine("-----Eliminar-----\n");
            Console.Write("Codigo de Barras: "); p.CodigoBarras = Console.ReadLine().ToString().Trim();
            
            try
            {

                // Traer todos los datos de la tabla Producto
                dt = BusinessLogicLayer.ProductBLL.Productos(p.CodigoBarras);
                // Traer todos los datos de la tabla producto y guardalos en la clase producto
                // Para poder hacer una validacion
                p = BusinessLogicLayer.ProductBLL.Productos_Buscar(p);

                if(p != null)
                {

                    Console.WriteLine("Se llavara acabo la eliminacion del producto: ");

                    foreach (DataRow item in dt.Rows)
                    {

                        Console.WriteLine("\tId: {0}\n \tDescripcion: {1}\n \tCodigo de Barras: {2}\n \tDepartamento: {3}\n \tUnidad de Venta: {4}\n \tCosto: {5}\n \tGanancia: {6}\n \tPrecio: {7}\n \tPrecio al Mayoreo: {8}\n \tUso de Inventario: {9}\n \tCantidad: {10}\n \tInventario Minimo: {11}\n \tInventario Maximo: {12}\n",
                            item["Id"].ToString(), item["Descripcion"].ToString(), item["Codigo de Barras"].ToString(), item["Departamento"].ToString(), item["Unidad de Venta"].ToString(),
                            item["Costo"].ToString(), item["Ganancia"].ToString(), item["Precio"].ToString(), item["Precio al Mayoreo"].ToString(),
                            item["Uso de Inventario"].ToString(), item["Cantidad"].ToString(), item["Inventario Minimo"].ToString(), item["Inventario Maximo"].ToString());

                    }

                        Console.WriteLine("Desea Borrar el Producto?...\n"
                            + "1.- Si\n"
                            + "2.- No");
                        int delete = Convert.ToInt32(Console.ReadLine());

                    if (delete == 1)
                    {

                        // Llamar el metodo de la clase ProductoBLL y agregar como parametro el codigo de barras
                        // El cual se estara eliminado
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
                else
                {

                    // Si no hay nada en el objeto producto entonces mandar un mensaje
                    // de que no se encontro el producto
                    Console.WriteLine("\n\tPRODUCTO NO ENCONTRADO!!! :'( ");
                    Console.ReadLine();

                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }

        }
        #endregion

        #region Modificar Producto

        /// <summary>
        /// Metodo para modficiar el Producto
        /// </summary>
        public static void Modificar_Producto()
        {

            Product p = new Product(); DataTable dt = new DataTable(); DataTable dep = new DataTable();
            Product old = new Product();
            int modificar, camp, cVen, Inv, mod; bool isCheked = false;
            double pventa;
            string barcode = string.Empty;

            Console.WriteLine("\n");
            Console.WriteLine("----------Modificar Producto-----------\n");
            Console.Write("Codigo de Barras: ");
            barcode = Console.ReadLine().ToString().Trim();
            old.CodigoBarras = barcode;

            try
            {

                // Trar el datos de la tabla segun el codigo de barras ingresado
                dt = BusinessLogicLayer.ProductBLL.Productos(barcode);
                // Guardar los tados en un objeto de la clase porduct para porder hacer una validacion
                p = BusinessLogicLayer.ProductBLL.Productos_Buscar(old);

                //Si el objeto es difetente de nulo entonces podra realizar la operacion
                if (p != null)
                {

                    Console.WriteLine("\nEste el es Producto que deseas modificar?...");

                    // Foreach que ira recorriendo el datatable e ira imprimiendo los datos que contiene
                    foreach (DataRow item in dt.Rows)
                    {

                        Console.WriteLine("\t1.- Id: {0}\n \t2.- Descripcion: {1}\n \t3.- Codigo de Barras: {2}\n \t4.- Departamento: {3}\n \t5.- Unidad de Venta: {4}\n \t6.- Costo: {5}\n \t7.- Ganancia: {6}\n \t8.- Precio: {7}\n \t9.- Precio al Mayoreo: {8}\n \t10.- Uso de Inventario: {9}\n \t11.- Cantidad: {10}\n \t12.- nventario Minimo: {11}\n \t13.- Inventario Maximo: {12}\n",
                            item["Id"].ToString(), item["Descripcion"].ToString(), item["Codigo de Barras"].ToString(), item["Departamento"].ToString(), item["Unidad de Venta"].ToString(),
                            item["Costo"].ToString(), item["Ganancia"].ToString(), item["Precio"].ToString(), item["Precio al Mayoreo"].ToString(),
                            item["Uso de Inventario"].ToString(), item["Cantidad"].ToString(), item["Inventario Minimo"].ToString(), item["Inventario Maximo"].ToString());

                    }
                    do
                    {

                        Console.WriteLine("Desea Modificar el Producto?...\n"
                            + "1.- Si\n"
                            + "2.- No");

                        modificar = Convert.ToInt32(Console.ReadLine());

                    } while (modificar > 2 || modificar < 1);

                    if (modificar == 1)
                    {

                        do
                        {

                            Console.WriteLine("\n Selecciona el campo que deseas modificar");
                            camp = Convert.ToInt32(Console.ReadLine());

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

                                    Console.WriteLine("\nLos Departamentos son...");

                                    // Traer los departamentos en un data table
                                    dep = BusinessLogicLayer.DepartmentBLL.Departamentos();

                                    // Foreach que esta rocorrendo el data table donde guardamos los departamentos
                                    // E ira imprimiendo todos los datos que contiene
                                    foreach (DataRow item in dep.Rows)
                                    {

                                        Console.WriteLine("\t{0}.- {1}", item["Id"].ToString(), item["Nombre"].ToString(), item["Descripcion"].ToString());

                                    }
                                    do
                                    {

                                        Console.WriteLine("Departamento: "); p.IdDepartamento = Convert.ToInt32(Console.ReadLine());

                                    } while (p.IdDepartamento > dep.Rows.Count || p.IdDepartamento < 0);

                                    break;

                                case 5:

                                    do
                                    {

                                        Console.WriteLine("Se vende por...\n"
                                            + "1.- Uniad/Pza \n"
                                            + "2.- A Granel(Usa Decimales) \n"
                                            + "3.- Como Paquete (Kit)");

                                        cVen = Convert.ToInt32(Console.ReadLine());

                                        if (cVen >= 4 || cVen < 1)
                                        {

                                            Console.WriteLine("\n\tPorfavor elegir una de las Opciones Mostradas :D");

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

                                case 6:

                                    Console.WriteLine("\nIngresa el nuevo costo"); p.Costo = Convert.ToDouble(Console.ReadLine());

                                    pventa = p.Costo + (p.Costo * (p.Ganancia / 100));
                                    p.Precio = pventa;

                                    break;

                                case 7:

                                    Console.Write("\nGanancia %"); p.Ganancia = Convert.ToDouble(Console.ReadLine());

                                    pventa = p.Costo + (p.Costo * (p.Ganancia / 100));
                                    p.Precio = pventa;

                                    break;

                                case 8:

                                    pventa = p.Costo + (p.Costo * (p.Ganancia / 100));

                                    Console.WriteLine("\n Ingresa el nuevo Precio del Producto $" + pventa); p.Precio = pventa;

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

                                            Console.WriteLine("\n\tPorfavor eliga una de las Opciones Mostradas");

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
                                + "1.- Si\n"
                                + "2.- No");
                            mod = Convert.ToInt32(Console.ReadLine());

                        } while (mod == 1);

                        // Traer el mensaje de error de la clase ProductoBLL el cual valida si el producto
                        // se puedo modificar
                        string msgError = BusinessLogicLayer.ProductBLL.Modificar_Producto(p);

                        // Si el mensaje esta nulo o vacio entonces mandara un mensaje de operacion
                        // Realizada con exito
                        if (string.IsNullOrEmpty(msgError))
                        {

                            Console.WriteLine("\n\tSE MODIFICO EL PRODUCTO CON EXITO :D!!!!!");
                            Console.ReadLine();

                        }
                        // Pero si no esta vacio
                        else
                        {

                            // Mostrara el mensaje de error traido
                            Console.WriteLine(msgError);

                        }

                    }

                }
                // Pero si el objeto es nulo
                else
                {

                    //Entonces madara un mensaje el cual este diciento que el producto no se encontro
                    Console.WriteLine("\n\t PRODUCTO NO ENCONTRADO :'(");
                    Console.ReadLine();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }

        }

        #endregion

        #endregion

        #region Metodos de Invetario
        /// <summary>
        /// Metodo para checar el inventario del producto
        /// </summary>
        public static void Inventario()
        {

            DataTable dt = new DataTable(); Product p = new Product(); Product product = new Product();
            string BarCode; int res, camp, mod; double pVenta;

            Console.Write("Codigo de Barras: "); BarCode = Console.ReadLine().ToString().Trim();
            product.CodigoBarras = BarCode;
            try
            {

                // Data table el cual estemos guardando los datos del inventario
                dt = BusinessLogicLayer.ProductBLL.Select_Inventario(BarCode);
                // Guardar los datos traidos del data table en un objeto de tipo product
                p = BusinessLogicLayer.ProductBLL.Productos_Buscar(product);

                //Si el bojeto es difetente de nulo entonces podra realizar la operacion
                if(p != null)
                {

                    // Foreach que ira recorriendo el data table y mostrar los datos
                    foreach (DataRow item in dt.Rows)
                    {

                        Console.WriteLine("\t1.- Descripcion: {0}\n \t2.- Codigo de Barras: {1}\n \t3.- Costo: {2}\n \t4.- Precio: {3}\n \t5.- Cantidad: {4}\n \t6.- Inventario Minimo: {5}\n \t7.- Inventario Maximo: {6}\n",
                            item["Descripcion"].ToString(), item["Codigo de Barras"].ToString(),
                            item["Costo"].ToString(), item["Precio"].ToString(),
                            item["Cantidad"].ToString(), item["Inventario Minimo"].ToString(), item["Inventario Maximo"].ToString());

                    }

                    do
                    {

                        Console.WriteLine("\nDeseas Modificar el Inventario?\n"
                                            + "1.- Si\n"
                                            + "2.- No");
                        res = Convert.ToInt32(Console.ReadLine());

                    } while (res > 2 || res < 1);

                    if (res == 1)
                    {

                        do
                        {

                            Console.WriteLine("\nQue campo deseas Modificar?");
                            camp = Convert.ToInt32(Console.ReadLine());

                            switch (camp)
                            {

                                case 1:

                                    Console.Write("\nIngresa una nueva Descripcion: "); p.Descripcion = Console.ReadLine();

                                    break;

                                case 2:

                                    Console.Write("\nIngresa un Nuevo codigo de Barras: "); p.CodigoBarras = Console.ReadLine();

                                    break;

                                case 3:

                                    Console.Write("\nIngresa un nuevo Costo: "); p.Costo = Convert.ToDouble(Console.ReadLine());

                                    pVenta = p.Costo + (p.Costo * (p.Ganancia / 100));
                                    p.Precio = pVenta;

                                    break;

                                case 4:

                                    Console.WriteLine("\nEl Precio se Modifica Automaticamente cuando se Modifica el Costo");

                                    pVenta = p.Costo + (p.Costo - (p.Ganancia / 100));
                                    p.Precio = pVenta;

                                    break;

                                case 5:

                                    Console.Write("\nIngresa la nueva Cantidad actual del Producto: "); p.Cantidad = Convert.ToInt32(Console.ReadLine());

                                    break;

                                case 6:

                                    Console.Write("\nIngresa el nuevo Inventario Minimo del Producto: "); p.InvMinima = Convert.ToInt32(Console.ReadLine());

                                    break;

                                case 7:

                                    Console.Write("\nIngresa la nueva Cantidad Maxima del Producto: "); p.InvMaxima = Convert.ToInt32(Console.ReadLine());

                                    break;
                            }

                            Console.WriteLine("\nDeseas Modificar algun otro campo?\n"
                                + "1.- Si\n"
                                + "2.- No");
                            mod = Convert.ToInt32(Console.ReadLine());

                        } while (mod == 1);

                        // Llamar el metodo de la clase BLL que valida si se pudo modificar el invetario
                        string msgError = BusinessLogicLayer.ProductBLL.Modificar_Inventario(p);

                        // Si el mesaje es nulo o esta vacio entonces mostrara el mensaje de operacion realizada con exito
                        if (string.IsNullOrEmpty(msgError))
                        {

                            Console.WriteLine("\n\t EL INVENTARIO SE MODIFICO EXITOSA MENTE :D");
                            Console.ReadLine();

                        }
                        //Pero si no esta vacio entonces mostrara el mensaje de error
                        else
                        {

                            Console.WriteLine(msgError);
                            Console.ReadLine();

                        }

                    }

                }
                //Si el objeto esta nulo entonces el ooroducto ni se encontro
                else
                {

                    // Y mostrar un mensaje de error
                    Console.WriteLine("\n\t PRODUCTO NO ENCONTRADO :'(");
                    Console.ReadLine();

                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());

            }

        }

        #endregion

        #region Ventas

        /// <summary>
        /// Metodo que realiza la logia de la venta
        /// </summary>
        /// <param name="dt">Data table el cual guardara los datos de la venta</param>
        public static void Ventas(DataTable dt)
        {

            Console.Clear();

            Product p = new Product(); string CodBar = string.Empty; int resp, otherP;

            Console.WriteLine("=================================================================================================");
            Console.WriteLine(" ||\t\t\t\t\t\t!!!VENTAS¡¡¡\t\t\t\t\t\t||");
            Console.WriteLine("=================================================================================================");

            do
            {

                Console.Clear();

                Console.Write("\nCodigo de Barras:"); CodBar = Console.ReadLine();

                // Mandar a llamar el metodo para encontrar el producto por medio del codigo de barras
                findProdoductByBarCode(CodBar, dt);

                // Clase el cual estara imprimiendo el data table enforma de tabla
                ExtensionDataTable.PrintToConsole(dt);

                Console.WriteLine("\n");

                //Metodo que esta mostrando el data table con los datos generales de la venta
                printFooter();

                Console.WriteLine("\nDeseas Comprar otro Articulo?\n"
                                     + "1.- Si\n"
                                     + "2.- No");
                resp = Convert.ToInt32(Console.ReadLine());

                if(resp > 2 || resp < 1)
                {

                    Console.WriteLine("\t !!Porfavor Ingresa una de las Respuestas Mostradas¡¡");

                }

            } while (resp == 1);

            if (resp == 2)
            {

                Console.Clear();

                string msgError = string.Empty;

                // Objeto de la clase venta para guardar los datos
                Sale sale = new Sale();

                sale.Sucursal = "Apodaca Centro";
                sale.Fecha = DateTime.Now;
                sale.Importe = total;
                sale.QuantityOfItems = quantityOfItems;
                sale.Caja = "Default";

                // Llamar al metodo que valida si la insercion de la tabla venta fue realizada
                msgError = BusinessLogicLayer.SaleBLL.insertSale(sale);

                if (string.IsNullOrEmpty(msgError))
                {

                    //Obtener el Ultimo registro actualizado de la Clase SALE
                    int saleId = BusinessLogicLayer.SaleBLL.getLastRegister();
                    
                    //Validar si obtuvimos una id de la clase Sale 
                    if(saleId > 0)
                    {

                        // Foreach que recore el data table con los detalles del producto a comprar
                        foreach(DataRow row in dt.Rows)
                        {

                            //Objeto de la entidad DetalleVenta para guardar los datos
                            DetalleVenta detalleVenta = new DetalleVenta();

                            // Pasar los datos del data table al objeto
                            detalleVenta.IdVenta = saleId;
                            detalleVenta.IdProducto = Convert.ToInt32(BusinessLogicLayer.ProductBLL.getProductIdByCodeBar(row["Codigo_Barras"].ToString()));
                            detalleVenta.Cantidad = Convert.ToInt32(row["CANTIDAD"].ToString());
                            detalleVenta.Importe = Convert.ToDouble(row["Precio_Unitario"].ToString());

                            // Guardar los datos a variables staticas para poder  hacer la modificacion de la resta de cantidad
                            // segun los producto comprado
                            string codBar = row["Codigo_Barras"].ToString();
                            int quantity = Convert.ToInt32(row["CANTIDAD"].ToString());

                            //Una ves Agregado los datos al objeto detalleventa entonces se van a insertar a la tabla

                            // Llamar el metodo a validar la insercion de los datos en la clase DetalleVenta
                            bool isCheked = BusinessLogicLayer.DetalleVentaBLL.insertDetalleVenta(detalleVenta);

                            // Metodo para Modifcar la nueva cantidad de la clase Product
                            BusinessLogicLayer.ProductBLL.modifyQuantityOfItems(codBar, quantity);

                            if (isCheked)
                            {

                                Console.Clear();

                                Console.WriteLine("\n\tGRACIAS POR SU COMPRA, VUELVA PRONTO");
                                Console.ReadLine();

                            }


                        }


                    }

                }
                else
                {

                    Console.WriteLine(msgError);
                    Console.ReadLine();

                }

            }

        }

        /// <summary>
        /// Metodo el cual esta mostrando los datos generales de las venta
        /// </summary>
        public static void printFooter()
        {

            DataTable dtFooter = new DataTable();

            //Agregando las columnas al data table
            dtFooter.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("TIPO_PAGO", typeof(string)),
                new DataColumn("CANTIDAD_ARTICULOS", typeof(int)),
                new DataColumn("SUBTOTAL", typeof(string)),
                new DataColumn("IVA", typeof(string)),
                new DataColumn("TOTAL", typeof(string))

            });

            // e ir ingresando los a las filas segun la columna los datos guardados en las variables staticas
            var row = dtFooter.NewRow();

            row["TIPO_PAGO"] = "EFECTIVO";
            row["CANTIDAD_ARTICULOS"] = quantityOfItems;
            row["SUBTOTAL"] = "$ " + subtotal;
            row["IVA"] = "$ " + iva;
            row["TOTAL"] = "$ " + total;

            dtFooter.Rows.Add(row);

            //Clase para imprimir el data table en forma de tabla
            ExtensionDataTable.PrintToConsole(dtFooter);


        }

        /// <summary>
        /// Metodo para encontrar el producto por medio del codigo de barras
        /// </summary>
        /// <param name="barCode">Codigo de barras para poder encontrar el producto</param>
        /// <param name="dt">Guardar los datos en el data table</param>
        public static void findProdoductByBarCode(string barCode, DataTable dt)
        {

            Product p = new Product();

            // Llamar el el cual encotrara los dato del producto
            p = BusinessLogicLayer.ProductBLL.findProdoductByBarCode(barCode);

            // Si el objeto es diferente de nulo guardara los datos en las filas del data table
            if(p != null)
            {

                // Declarar una variable var el cual estara guardando las filas en el data table
                var row = dt.NewRow();

                // Pasar el datos alas filas segun la columna del data table
                row["Codigo_Barras"] = p.CodigoBarras;
                row["Descripcion"] = p.Descripcion;
                row["CANTIDAD"] = 1;
                row["Precio_Unitario"] = p.Precio;
                row["Importe"] = (p.Precio * .16) + p.Precio;

                // Guardar las filas al data table
                dt.Rows.Add(row);

                // Guardar algunos datos a estas variables staticas para poder ingresarlos al data table con la informacion
                // General de la venta
                quantityOfItems = quantityOfItems + 1;
                subtotal = subtotal + Convert.ToDouble(row["Precio_Unitario"].ToString());
                iva = iva + Convert.ToDouble(row["Precio_Unitario"]) * .16;
                total = total + Convert.ToDouble(row["Importe"].ToString());

            }
            // Pero si el objeto es nulo
            else
            {

                //Entonces mostrar un mensaje de que no se encontro el producto
                Console.WriteLine("\n\tNose encontro el producto");
                Console.ReadLine();

            }

        }

        public static void updateColums(DataTable dt)
        {

            dt.Columns.AddRange(new DataColumn[]
{

                    new DataColumn("Codigo_Barras", typeof(string)),
                    new DataColumn("Descripcion", typeof(string)),
                    new DataColumn("CANTIDAD", typeof(string)),
                    new DataColumn("Precio_Unitario", typeof(double)),
                    new DataColumn("Importe", typeof(double))

            });

        }

        #endregion

    }
}
