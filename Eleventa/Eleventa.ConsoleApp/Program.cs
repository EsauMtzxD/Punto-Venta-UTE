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

                Console.WriteLine("Desea Hacer otra cosa?\n"
                    +"1.- Si\n"
                    +"2.- No");
                res = Convert.ToInt32(Console.ReadLine());

            } while (res == 1);

            Console.ReadKey();

        }



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

        #region Metodos de Productos

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

            dt = BusinessLogicLayer.DepartmentBLL.Departamentos();

            Console.WriteLine("Los Departamentos son:");

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

                        Console.WriteLine("Porfavor eliga una de las Opciones Mostradas");

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

            DataTable dt = new DataTable(); Product p = new Product(); Product old = new Product();
            string barcode = string.Empty;

            Console.WriteLine("\n");
            Console.WriteLine("-----Eliminar-----\n");
            Console.WriteLine("Ingresa el Codigo de Barras que quieres Eliminar"); p.CodigoBarras = Console.ReadLine().ToString().Trim();
            
            try
            {

                dt = BusinessLogicLayer.ProductBLL.Productos(p.CodigoBarras);
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

        public static void Modificar_Producto()
        {

            Product p = new Product(); DataTable dt = new DataTable(); DataTable dep = new DataTable();
            Product old = new Product();
            int modificar, camp, cVen, Inv, mod; bool isCheked = false;
            double pventa;
            string barcode = string.Empty;

            Console.WriteLine("\n");
            Console.WriteLine("----------Modificar Producto-----------\n");
            Console.WriteLine("Ingrese el codigo de barras del producto que quiera eliminar");
            barcode = Console.ReadLine().ToString().Trim();
            old.CodigoBarras = barcode;

            try
            {

                dt = BusinessLogicLayer.ProductBLL.Productos(barcode);
                p = BusinessLogicLayer.ProductBLL.Productos_Buscar(old);

                if (p != null)
                {

                    Console.WriteLine("\nEste el es Producto que deseas modificar?...");


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

                                case 6:

                                    Console.WriteLine("\nIngrasa el nuevo costo"); p.Costo = Convert.ToDouble(Console.ReadLine());

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
                                + "1.- Si\n"
                                + "2.- No");
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
                else
                {

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

        public static void Inventario()
        {

            DataTable dt = new DataTable(); Product p = new Product(); Product product = new Product();
            string BarCode; int res, camp, mod; double pVenta;

            Console.Write("Ingresa el codigo de Barras: "); BarCode = Console.ReadLine().ToString().Trim();
            product.CodigoBarras = BarCode;
            try
            {

                dt = BusinessLogicLayer.ProductBLL.Select_Inventario(BarCode);
                p = BusinessLogicLayer.ProductBLL.Productos_Buscar(product);

                if(p != null)
                {

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

                        string msgError = BusinessLogicLayer.ProductBLL.Modificar_Inventario(p);

                        if (string.IsNullOrEmpty(msgError))
                        {

                            Console.WriteLine("\n\t EL INVENTARIO SE MODIFICO EXITOSA MENTE :D");
                            Console.ReadLine();

                        }
                        else
                        {

                            Console.WriteLine(msgError);
                            Console.ReadLine();

                        }

                    }

                }
                else
                {

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

                findProdoductByBarCode(CodBar, dt);

                ExtensionDataTable.PrintToConsole(dt);

                Console.WriteLine("\n");

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

                Sale sale = new Sale();

                sale.Sucursal = "Apodaca Centro";
                sale.Fecha = DateTime.Now;
                sale.Importe = total;
                sale.QuantityOfItems = quantityOfItems;
                sale.Caja = "Default";

                msgError = BusinessLogicLayer.SaleBLL.insertSale(sale);

                if (string.IsNullOrEmpty(msgError))
                {

                    //Obtener el Ultimo registro actualizado de la Clase SALE
                    int saleId = BusinessLogicLayer.SaleBLL.getLastRegister();
                    
                    //Validar si obtuvimos una id de la clase Sale 
                    if(saleId > 0)
                    {

                        //Insertar los datos dentro de la Tabla DetalleVenta
                        foreach(DataRow row in dt.Rows)
                        {

                            DetalleVenta detalleVenta = new DetalleVenta();

                            detalleVenta.IdVenta = saleId;
                            detalleVenta.IdProducto = Convert.ToInt32(BusinessLogicLayer.ProductBLL.getProductIdByCodeBar(row["Codigo_Barras"].ToString()));
                            detalleVenta.Cantidad = Convert.ToInt32(row["CANTIDAD"].ToString());
                            detalleVenta.Importe = Convert.ToDouble(row["Precio_Unitario"].ToString());

                            //Una ves Agregado los datos al objeto detalleventa entonces se van a insertar a la tabla

                            bool isCheked = BusinessLogicLayer.DetalleVentaBLL.insertDetalleVenta(detalleVenta);

                            if (isCheked)
                            {

                                Console.WriteLine("\n\tGRACIAS POR SU COMPRA, VUELVA PRONTO");

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

        public static void printFooter()
        {

            DataTable dtFooter = new DataTable();

            dtFooter.Columns.AddRange(new DataColumn[]
            {

                new DataColumn("TIPO_PAGO", typeof(string)),
                new DataColumn("CANTIDAD_ARTICULOS", typeof(int)),
                new DataColumn("SUBTOTAL", typeof(string)),
                new DataColumn("IVA", typeof(string)),
                new DataColumn("TOTAL", typeof(string))

            });

            var row = dtFooter.NewRow();

            row["TIPO_PAGO"] = "EFECTIVO";
            row["CANTIDAD_ARTICULOS"] = quantityOfItems;
            row["SUBTOTAL"] = "$ " + subtotal;
            row["IVA"] = "$ " + iva;
            row["TOTAL"] = "$ " + total;

            dtFooter.Rows.Add(row);

            ExtensionDataTable.PrintToConsole(dtFooter);


        }

        public static void findProdoductByBarCode(string barCode, DataTable dt)
        {

            Product p = new Product();

            p = BusinessLogicLayer.ProductBLL.findProdoductByBarCode(barCode);

            if(p != null)
            {

                var row = dt.NewRow();

                row["Codigo_Barras"] = p.CodigoBarras;
                row["Descripcion"] = p.Descripcion;
                row["CANTIDAD"] = 1;
                row["Precio_Unitario"] = p.Precio;
                row["Importe"] = (p.Precio * .16) + p.Precio;

                dt.Rows.Add(row);

                quantityOfItems = quantityOfItems + 1;
                subtotal = subtotal + Convert.ToDouble(row["Precio_Unitario"].ToString());
                iva = iva + Convert.ToDouble(row["Precio_Unitario"]) * .16;
                total = total + Convert.ToDouble(row["Importe"].ToString());

            }
            else
            {

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
