using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public partial class notepadContext : DbContext
    {
        private static bool _created = false;

        public notepadContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite("Data Source=notepadDB.db");
        }

        public notepadContext(DbContextOptions<notepadContext> options)
                : base(options)
        {
        }

        public virtual DbSet<attribute> Attributes { get; set; }
        public virtual DbSet<notes> Notes { get; set; }
        public virtual DbSet<project> Projects { get; set; }
        //    public virtual DbSet<userInformation> Users { get; set; }

        //Attribute Table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<userInformation>().ToTable("userInformation");
            modelBuilder.Entity<userInformation>(entity =>
            {
                entity.Property(e => e.username).IsRequired();
            });

            //Notes Table
            modelBuilder.Entity<notes>(entity =>
            {
                entity.HasKey(e => e.noteId)
                    .HasName("PK__UserInfo__1788CC4C1F5C1650");

                entity.Property(e => e.noteText).HasMaxLength(500);
                ;

                entity.Property(e => e.project);

                entity.Property(e => e.attribute);

                entity.Property(e => e.creation_timestamp)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            //Project Table
            modelBuilder.Entity<project>(entity =>
            {
                entity.HasKey(e => e.projectId);

                entity.Property(e => e.projectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            //Users Table
            modelBuilder.Entity<userInformation>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.username).HasMaxLength(50);

                entity.Property(e => e.password);

                entity.Property(e => e.token);
                entity.Property(e => e.lastlogin_timestamp)
                                   .IsRequired()
                                   .HasMaxLength(30)
                                   .IsUnicode(false);

                entity.Property(e => e.creation_timestamp)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}