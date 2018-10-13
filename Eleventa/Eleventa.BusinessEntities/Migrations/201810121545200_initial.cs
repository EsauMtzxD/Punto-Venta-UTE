namespace Eleventa.BusinessEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cut",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FondoInicial = c.Double(nullable: false),
                        CantidadFinal = c.Double(nullable: false),
                        Diferencia = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        IdVenta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sale", t => t.IdVenta, cascadeDelete: true)
                .Index(t => t.IdVenta);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Articulo = c.String(nullable: false, unicode: false),
                        Precio = c.Double(nullable: false),
                        CantidadArticulos = c.Int(nullable: false),
                        Subtotal = c.Double(nullable: false),
                        Iva = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Pago = c.Double(nullable: false),
                        Cambio = c.Double(nullable: false),
                        NombreEmpleado = c.String(nullable: false, unicode: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        CodigoBarras = c.String(nullable: false, maxLength: 12, unicode: false, storeType: "nvarchar"),
                        Unidad_Venta = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        IdDepartamento = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Costo = c.Double(nullable: false),
                        Precio = c.Double(nullable: false),
                        PrecioMayoreo = c.Double(nullable: false),
                        Ganancia = c.Double(nullable: false),
                        Use_Inventory = c.Boolean(nullable: false),
                        InvMinima = c.Int(nullable: false),
                        InvMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.IdDepartamento, cascadeDelete: true)
                .Index(t => t.IdDepartamento);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                        Descripcion = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cut", "IdVenta", "dbo.Sale");
            DropForeignKey("dbo.Sale", "IdProducto", "dbo.Product");
            DropForeignKey("dbo.Product", "IdDepartamento", "dbo.Department");
            DropIndex("dbo.Cut", new[] { "IdVenta" });
            DropIndex("dbo.Sale", new[] { "IdProducto" });
            DropIndex("dbo.Product", new[] { "IdDepartamento" });
            DropTable("dbo.Department");
            DropTable("dbo.Product");
            DropTable("dbo.Sale");
            DropTable("dbo.Cut");
        }
    }
}
