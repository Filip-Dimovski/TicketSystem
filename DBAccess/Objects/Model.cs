namespace DBAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelsTicket")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Kino> Kino { get; set; }
        public virtual DbSet<KinoAkter> KinoAkter { get; set; }
        public virtual DbSet<Koncert> Koncert { get; set; }
        public virtual DbSet<KoncertPejac> KoncertPejac { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KreditnaKartichka> KreditnaKartichka { get; set; }
        public virtual DbSet<Nastan> Nastan { get; set; }
        public virtual DbSet<NastanOdrzhuvanje> NastanOdrzhuvanje { get; set; }
        public virtual DbSet<Poseta> Poseta { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }
        public virtual DbSet<Teatar> Teatar { get; set; }
        public virtual DbSet<TeatarIzveduvach> TeatarIzveduvach { get; set; }
        public virtual DbSet<Tim> Tim { get; set; }
        public virtual DbSet<Zooloshka> Zooloshka { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kino>()
                .HasMany(e => e.KinoAkter)
                .WithRequired(e => e.Kino)
                .HasForeignKey(e => e.KinoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Koncert>()
                .HasMany(e => e.KoncertPejac)
                .WithRequired(e => e.Koncert)
                .HasForeignKey(e => e.KoncertId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korisnik>()
                .Property(e => e.Pol)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KreditnaKartichka>()
                .HasMany(e => e.Korisnik)
                .WithOptional(e => e.KreditnaKartichka)
                .HasForeignKey(e => e.IdKreditnaKartichka);

            modelBuilder.Entity<Nastan>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<Nastan>()
                .HasOptional(e => e.Kino)
                .WithRequired(e => e.Nastan);

            modelBuilder.Entity<Nastan>()
                .HasMany(e => e.NastanOdrzhuvanje)
                .WithRequired(e => e.Nastan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nastan>()
                .HasOptional(e => e.Sport)
                .WithRequired(e => e.Nastan);

            modelBuilder.Entity<Nastan>()
                .HasOptional(e => e.Teatar)
                .WithRequired(e => e.Nastan);

            modelBuilder.Entity<Nastan>()
                .HasOptional(e => e.Zooloshka)
                .WithRequired(e => e.Nastan);

            modelBuilder.Entity<Teatar>()
                .HasMany(e => e.TeatarIzveduvach)
                .WithRequired(e => e.Teatar)
                .HasForeignKey(e => e.TeatarId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tim>()
                .HasMany(e => e.Sport)
                .WithOptional(e => e.Tim)
                .HasForeignKey(e => e.DomashenTimId);

            modelBuilder.Entity<Tim>()
                .HasMany(e => e.Sport1)
                .WithOptional(e => e.Tim1)
                .HasForeignKey(e => e.GostinskiTimId);
        }
    }
}
