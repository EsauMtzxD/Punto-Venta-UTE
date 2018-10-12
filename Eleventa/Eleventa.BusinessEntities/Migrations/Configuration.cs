namespace Eleventa.BusinessEntities.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Eleventa.BusinessEntities.EleventaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Eleventa.BusinessEntities.EleventaDbContext dbCtx)
        {

            try
            {

                #region Departaments List
                List<Department> departments = new List<Department>();
                departments.Add(new Department()
                {

                    Nombre = "Electronica",
                    Descripcion = "Solo productos Electronicos"

                });

                departments.Add(new Department()
                {

                    Nombre = "Vinos y Licores",
                    Descripcion = "Bebidas Alcoholica"

                });

                departments.Add(new Department()
                {

                    Nombre = "Fruteria",
                    Descripcion = "Frutas y Verduras"

                });
                dbCtx.Departments.AddRange(departments);
                dbCtx.SaveChanges();
                #endregion

                #region Products List
                List<Product> products = new List<Product>();
                products.Add(new Product()
                {

                    Descripcion = "Laptop DELL '15.5' - Core - i5 - 8 RAM - 1 TB Disco Duro",
                    IdDepartamento = 1,
                    CodigoBarras = "753124897648",
                    Cantidad = 5,
                    Costo = 18.530,
                    Precio = 20.500,
                    PrecioMayoreo = 0,
                    Ganancia = 2.500,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 10

                });

                products.Add(new Product()
                {

                    Descripcion = "HP - Mouse Omen 600 Alábrico - Negro",
                    IdDepartamento = 1,
                    CodigoBarras = "951753842613",
                    Cantidad = 20,
                    Costo = 800,
                    Precio = 999,
                    PrecioMayoreo = 0,
                    Ganancia = 199,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 50

                });

                products.Add(new Product()
                {

                    Descripcion = "Razer - Audífonos Gaming estéreo Kraken Pro \n" +
                                    "V2 - Verde",
                    IdDepartamento = 1,
                    CodigoBarras = "486257913258",
                    Cantidad = 20,
                    Costo = 1000,
                    Precio = 1999,
                    PrecioMayoreo = 0,
                    Ganancia = 999,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 50

                });

                products.Add(new Product()
                {

                    Descripcion = "Whisky Crown Royal 750 ml",
                    IdDepartamento = 2,
                    CodigoBarras = "542687193753",
                    Cantidad = 10,
                    Costo = 100,
                    Precio = 196,
                    PrecioMayoreo = 150,
                    Ganancia = 96,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 20

                });

                products.Add(new Product()
                {

                    Descripcion = "Cervez Oscura Indio 6 botellas 355ml c/u",
                    IdDepartamento = 2,
                    CodigoBarras = "123789456753",
                    Cantidad = 15,
                    Costo = 10,
                    Precio = 75,
                    PrecioMayoreo = 0,
                    Ganancia = 15,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 50

                });

                products.Add(new Product()
                {

                    Descripcion = "Vino blanco concha y toro espumoso brut 700 ml",
                    IdDepartamento = 2,
                    CodigoBarras = "741852963754",
                    Cantidad = 5,
                    Costo = 100,
                    Precio = 179,
                    PrecioMayoreo = 0,
                    Ganancia = 79,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 10

                });

                products.Add(new Product()
                {

                    Descripcion = "Mango ataulfo por kilo",
                    IdDepartamento = 3,
                    CodigoBarras = "654753159875",
                    Cantidad = 500,
                    Costo = 10,
                    Precio = 28.9,
                    PrecioMayoreo = 0,
                    Ganancia = 18.9,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 1000

                });

                products.Add(new Product()
                {

                    Descripcion = "Durazno por kilo",
                    IdDepartamento = 3,
                    CodigoBarras = "364751249876",
                    Cantidad = 500,
                    Costo = 30,
                    Precio = 49.9,
                    PrecioMayoreo = 0,
                    Ganancia = 19.9,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 1000

                });

                products.Add(new Product()
                {

                    Descripcion = "Kiwi importado por kilo",
                    IdDepartamento = 3,
                    CodigoBarras = "457812967521",
                    Cantidad = 500,
                    Costo = 30,
                    Precio = 69,
                    PrecioMayoreo = 0,
                    Ganancia = 39,
                    Use_Inventory = true,
                    InvMinima = 0,
                    InvMaxima = 100

                });
                dbCtx.Products.AddRange(products);
                dbCtx.SaveChanges();
                #endregion

            }
            catch (DbEntityValidationException ex)
            {

                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );

            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
