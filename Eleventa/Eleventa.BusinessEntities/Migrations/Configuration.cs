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
                    CodigoBarras = "753124897648",
                    IdDepartamento = 1,
                    Unidad_Venta = "Por Pza",
                    Costo = 18.530,
                    Ganancia = 2.500,
                    Precio = 20.500,
                    PrecioMayoreo = 0,
                    Use_Inventory = true,
                    Cantidad = 5,
                    InvMinima = 0,
                    InvMaxima = 10

                });

                products.Add(new Product()
                {

                    Descripcion = "HP - Mouse Omen 600 Alábrico - Negro",
                    CodigoBarras = "951753842613",
                    IdDepartamento = 1,
                    Unidad_Venta = "Por Pza",
                    Costo = 800,
                    Ganancia = 199,
                    Precio = 999,
                    PrecioMayoreo = 0,
                    Use_Inventory = true,
                    Cantidad = 20,
                    InvMinima = 0,
                    InvMaxima = 50

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
