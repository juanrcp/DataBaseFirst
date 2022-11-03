using Microsoft.EntityFrameworkCore;
namespace EntityBasicoDAL.Modelo
{
    public partial class entityBasicoContext : DbContext
    {
        public entityBasicoContext()
        {
        }

        public entityBasicoContext(DbContextOptions<entityBasicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<NivelAcceso> NivelAccesos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=entityBasico;User Id=postgres;Password=fp13DAW");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.NombreEmpleado).HasColumnName("nombre_empleado");
            });

            modelBuilder.Entity<NivelAcceso>(entity =>
            {
                entity.ToTable("nivel_accesos");

                entity.HasIndex(e => e.EmpleadoId, "IX_nivel_accesos_empleadoId");

                entity.Property(e => e.DescAcceso).HasColumnName("desc_acceso");

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.NivelAcceso1).HasColumnName("nivel_acceso");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.NivelAccesos)
                    .HasForeignKey(d => d.EmpleadoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
