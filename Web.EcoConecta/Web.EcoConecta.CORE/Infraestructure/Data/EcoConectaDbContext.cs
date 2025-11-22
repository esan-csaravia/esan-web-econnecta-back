using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web.EcoConecta.CORE.Core.Entities;

namespace Web.EcoConecta.CORE.Infraestructure.Data;

public partial class EcoConectaDbContext : DbContext
{
    public EcoConectaDbContext()
    {
    }

    public EcoConectaDbContext(DbContextOptions<EcoConectaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BloqueosUsuarios> BloqueosUsuarios { get; set; }

    public virtual DbSet<Calificaciones> Calificaciones { get; set; }

    public virtual DbSet<CampanasReciclaje> CampanasReciclaje { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Comentarios> Comentarios { get; set; }

    public virtual DbSet<ImagenesPublicacion> ImagenesPublicacion { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<Publicaciones> Publicaciones { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=EcoConectaDB;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BloqueosUsuarios>(entity =>
        {
            entity.HasKey(e => e.IdBloqueo).HasName("PK__Bloqueos__CC383307A9FB48FD");

            entity.Property(e => e.IdBloqueo).HasColumnName("id_bloqueo");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Motivo).HasColumnName("motivo");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.BloqueosUsuariosIdAdminNavigation)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BloqueosU__id_ad__68487DD7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.BloqueosUsuariosIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BloqueosU__id_us__6754599E");
        });

        modelBuilder.Entity<Calificaciones>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PK__Califica__38CEF35CCF94953B");

            entity.HasIndex(e => e.IdTransaccion, "UQ__Califica__1EDAC09838E49211").IsUnique();

            entity.Property(e => e.IdCalificacion).HasColumnName("id_calificacion");
            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCalificador).HasColumnName("id_calificador");
            entity.Property(e => e.IdTransaccion).HasColumnName("id_transaccion");
            entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

            entity.HasOne(d => d.IdCalificadorNavigation).WithMany(p => p.CalificacionesIdCalificadorNavigation)
                .HasForeignKey(d => d.IdCalificador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__id_ca__5EBF139D");

            entity.HasOne(d => d.IdTransaccionNavigation).WithOne(p => p.Calificaciones)
                .HasForeignKey<Calificaciones>(d => d.IdTransaccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__id_tr__5DCAEF64");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.CalificacionesIdVendedorNavigation)
                .HasForeignKey(d => d.IdVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__id_ve__5FB337D6");
        });

        modelBuilder.Entity<CampanasReciclaje>(entity =>
        {
            entity.HasKey(e => e.IdCampana).HasName("PK__Campanas__CAA2C8F7A08D4276");

            entity.Property(e => e.IdCampana).HasColumnName("id_campana");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCampana).HasColumnName("fecha_campana");
            entity.Property(e => e.FechaPublicacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.CampanasReciclaje)
                .HasForeignKey(d => d.IdAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CampanasR__id_ad__6383C8BA");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5A794A1585");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Comentarios>(entity =>
        {
            entity.HasKey(e => e.IdComentario).HasName("PK__Comentar__1BA6C6F4E30909E5");

            entity.Property(e => e.IdComentario).HasColumnName("id_comentario");
            entity.Property(e => e.Comentario)
                .HasMaxLength(200)
                .HasColumnName("comentario");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__id_pu__571DF1D5");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__id_us__5812160E");
        });

        modelBuilder.Entity<ImagenesPublicacion>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__27CC2689F4C5ECB9");

            entity.Property(e => e.IdImagen).HasColumnName("id_imagen");
            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(255)
                .HasColumnName("ruta_imagen");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.ImagenesPublicacion)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImagenesP__id_pu__46E78A0C");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__8270F9A585981EA4");

            entity.Property(e => e.IdNotificacion).HasColumnName("id_notificacion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Leido)
                .HasDefaultValue(false)
                .HasColumnName("leido");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(255)
                .HasColumnName("mensaje");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__id_pu__534D60F1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificac__id_us__52593CB8");
        });

        modelBuilder.Entity<Publicaciones>(entity =>
        {
            entity.HasKey(e => e.IdPublicacion).HasName("PK__Publicac__7C38517362E2CD86");

            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.EstadoPublicacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("pendiente")
                .HasColumnName("estado_publicacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.MotivoRechazo).HasColumnName("motivo_rechazo");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Publicaci__id_ca__440B1D61");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Publicaci__id_us__4316F928");
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__Transacc__1EDAC099D67694AC");

            entity.Property(e => e.IdTransaccion).HasColumnName("id_transaccion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdComprador).HasColumnName("id_comprador");
            entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");
            entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdCompradorNavigation).WithMany(p => p.TransaccionesIdCompradorNavigation)
                .HasForeignKey(d => d.IdComprador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_co__4CA06362");

            entity.HasOne(d => d.IdPublicacionNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_pu__4BAC3F29");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.TransaccionesIdVendedorNavigation)
                .HasForeignKey(d => d.IdVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__id_ve__4D94879B");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD8FD623A0");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__2A586E0B2562DD23").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(120)
                .HasColumnName("correo");
            entity.Property(e => e.Distrito)
                .HasMaxLength(80)
                .HasColumnName("distrito");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ciudadano")
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
