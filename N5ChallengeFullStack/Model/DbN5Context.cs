using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace N5ChallengeFullStack.Model
{
    public partial class DbN5Context : DbContext
    {
        public DbN5Context(DbContextOptions<DbN5Context> options) : base(options)
        {

        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");



                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
                entity.Property(e => e.PermissionTypeId).HasColumnName("PERMISSION_TYPE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("UPDATED_AT")
            .HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.UpdatedBy)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("UPDATED_BY");
                entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
                entity.HasOne(d => d.PermissionType)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_TYPE");

            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.ToTable("PERMISSION_TYPE");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME");
                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.UpdatedAt)
            .HasColumnType("datetime")
            .HasColumnName("UPDATED_AT")
            .HasDefaultValueSql("(getutcdate())");
                entity.Property(e => e.UpdatedBy)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("UPDATED_BY");
                entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");


            });
        }
    }
}
