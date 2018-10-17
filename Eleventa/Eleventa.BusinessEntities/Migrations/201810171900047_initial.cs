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
                        Sucursal = c.String(nullable: false, unicode: false),
                        Fecha = c.DateTime(nullable: false, precision: 0),
                        Importe = c.Double(nullable: false),
                        Pago = c.Double(nullable: false),
                        Cambio = c.Double(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                        Caja = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.DetalleVenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdVenta = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Importe = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.IdVenta, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdVenta);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, unicode: false),
                        CodigoBarras = c.String(nullable: false, maxLength: 12, unicode: false, storeType: "nvarchar"),
                        IdDepartamento = c.Int(nullable: false),
                        Unidad_Venta = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Costo = c.Double(nullable: false),
                        Ganancia = c.Double(nullable: false),
                        Precio = c.Double(nullable: false),
                        PrecioMayoreo = c.Double(nullable: false),
                        Use_Inventory = c.Boolean(nullable: false),
                        Cantidad = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cut", "IdVenta", "dbo.Sale");
            DropForeignKey("dbo.Sale", "IdEmpleado", "dbo.Employee");
            DropForeignKey("dbo.DetalleVenta", "IdVenta", "dbo.Sale");
            DropForeignKey("dbo.DetalleVenta", "IdProducto", "dbo.Product");
            DropForeignKey("dbo.Product", "IdDepartamento", "dbo.Department");
            DropIndex("dbo.Cut", new[] { "IdVenta" });
            DropIndex("dbo.Sale", new[] { "IdEmpleado" });
            DropIndex("dbo.DetalleVenta", new[] { "IdVenta" });
            DropIndex("dbo.DetalleVenta", new[] { "IdProducto" });
            DropIndex("dbo.Product", new[] { "IdDepartamento" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.Product");
            DropTable("dbo.DetalleVenta");
            DropTable("dbo.Sale");
            DropTable("dbo.Cut");
        }
    }
}
