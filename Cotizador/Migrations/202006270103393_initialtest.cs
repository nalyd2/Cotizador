namespace Cotizador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialtest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Componente",
                c => new
                    {
                        IDComponente = c.Int(nullable: false, identity: true),
                        IDSistema = c.Int(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDComponente)
                .ForeignKey("dbo.Sistema", t => t.IDSistema)
                .Index(t => t.IDComponente)
                .Index(t => t.IDSistema);
            
            CreateTable(
                "dbo.Costos",
                c => new
                    {
                        IDCosto = c.Int(nullable: false, identity: true),
                        TipoCosto = c.Int(nullable: false),
                        IDProducto = c.Int(nullable: false),
                        IDComponente = c.Int(nullable: false),
                        Costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InicioVigencia = c.DateTime(nullable: false),
                        FinVigencia = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDCosto)
                .ForeignKey("dbo.Componente", t => t.IDComponente)
                .ForeignKey("dbo.Producto", t => t.IDProducto)
                .Index(t => t.IDProducto)
                .Index(t => t.IDComponente);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        IDProducto = c.Int(nullable: false, identity: true),
                        IDSistema = c.Int(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDProducto)
                .ForeignKey("dbo.Sistema", t => t.IDSistema)
                .Index(t => t.IDSistema);
            
            CreateTable(
                "dbo.Cotizacion",
                c => new
                    {
                        IDCotizacion = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Cliente = c.String(),
                        Direccion = c.String(),
                        CodigoPostal = c.String(),
                        IDProducto = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Creada = c.DateTime(nullable: false),
                        Modificada = c.DateTime(nullable: false),
                        Vigencia = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDCotizacion)
                .ForeignKey("dbo.Producto", t => t.IDProducto)
                .Index(t => t.IDCotizacion)
                .Index(t => t.IDProducto);
            
            CreateTable(
                "dbo.CotizacionDet",
                c => new
                    {
                        IDCotizacionDet = c.Int(nullable: false, identity: true),
                        IDCotizacion = c.Int(nullable: false),
                        Linea = c.Short(nullable: false),
                        Componente = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDCotizacionDet)
                .ForeignKey("dbo.Cotizacion", t => t.IDCotizacion)
                .Index(t => t.IDCotizacionDet)
                .Index(t => t.IDCotizacion);
            
            CreateTable(
                "dbo.Sistema",
                c => new
                    {
                        IDSistema = c.Int(nullable: false, identity: true),
                        IDModelo = c.Int(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDSistema)
                .ForeignKey("dbo.Modelo", t => t.IDModelo)
                .Index(t => t.IDSistema)
                .Index(t => t.IDModelo);
            
            CreateTable(
                "dbo.Modelo",
                c => new
                    {
                        IDModelo = c.Int(nullable: false, identity: true),
                        IDMarca = c.Int(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDModelo)
                .ForeignKey("dbo.Marca", t => t.IDMarca)
                .Index(t => t.IDModelo)
                .Index(t => t.IDMarca);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        IDMarca = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDMarca)
                .Index(t => t.IDMarca);
            
            CreateTable(
                "dbo.TipoCosto",
                c => new
                    {
                        IDTipoCosto = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IDTipoCosto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "IDSistema", "dbo.Sistema");
            DropForeignKey("dbo.Sistema", "IDModelo", "dbo.Modelo");
            DropForeignKey("dbo.Modelo", "IDMarca", "dbo.Marca");
            DropForeignKey("dbo.Componente", "IDSistema", "dbo.Sistema");
            DropForeignKey("dbo.Cotizacion", "IDProducto", "dbo.Producto");
            DropForeignKey("dbo.CotizacionDet", "IDCotizacion", "dbo.Cotizacion");
            DropForeignKey("dbo.Costos", "IDProducto", "dbo.Producto");
            DropForeignKey("dbo.Costos", "IDComponente", "dbo.Componente");
            DropIndex("dbo.Marca", new[] { "IDMarca" });
            DropIndex("dbo.Modelo", new[] { "IDMarca" });
            DropIndex("dbo.Modelo", new[] { "IDModelo" });
            DropIndex("dbo.Sistema", new[] { "IDModelo" });
            DropIndex("dbo.Sistema", new[] { "IDSistema" });
            DropIndex("dbo.CotizacionDet", new[] { "IDCotizacion" });
            DropIndex("dbo.CotizacionDet", new[] { "IDCotizacionDet" });
            DropIndex("dbo.Cotizacion", new[] { "IDProducto" });
            DropIndex("dbo.Cotizacion", new[] { "IDCotizacion" });
            DropIndex("dbo.Producto", new[] { "IDSistema" });
            DropIndex("dbo.Costos", new[] { "IDComponente" });
            DropIndex("dbo.Costos", new[] { "IDProducto" });
            DropIndex("dbo.Componente", new[] { "IDSistema" });
            DropIndex("dbo.Componente", new[] { "IDComponente" });
            DropTable("dbo.TipoCosto");
            DropTable("dbo.Marca");
            DropTable("dbo.Modelo");
            DropTable("dbo.Sistema");
            DropTable("dbo.CotizacionDet");
            DropTable("dbo.Cotizacion");
            DropTable("dbo.Producto");
            DropTable("dbo.Costos");
            DropTable("dbo.Componente");
        }
    }
}
