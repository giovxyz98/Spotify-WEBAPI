using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2.Models
{
    public partial class SpotifyContext : DbContext
    {
        public SpotifyContext()
        {
        }

        public SpotifyContext(DbContextOptions<SpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ListSongPlaylist> ListSongPlaylists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Spotify; User id = sa ; password = Pass@word01;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.Titolo)
                    .HasName("PK__Album__D53B5FEB8EB28555");

                entity.ToTable("Album");

                entity.Property(e => e.Titolo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("titolo");

                entity.Property(e => e.AnnoDiPubblicazione)
                    .HasColumnType("date")
                    .HasColumnName("annoDiPubblicazione");

                entity.Property(e => e.Artist)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("artist");

                entity.Property(e => e.Genere)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("genere");

                entity.HasOne(d => d.ArtistNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.Artist)
                    .HasConstraintName("FK__Album__artist__14270015");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.NomeDArte)
                    .HasName("PK__Artitst__7629357564686837");

                entity.ToTable("Artist");

                entity.Property(e => e.NomeDArte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nome_d_arte");

                entity.Property(e => e.NomePlaylist)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomePlaylist");
            });

            modelBuilder.Entity<ListSongPlaylist>(entity =>
            {
                entity.HasKey(e => e.CodiceIdentificativoPlaylist)
                    .HasName("PK__ListSong__BBA147D5E4162B56");

                entity.ToTable("ListSongPlaylist");

                entity.Property(e => e.CodiceIdentificativoPlaylist)
                    .ValueGeneratedNever()
                    .HasColumnName("codiceIdentificativoPlaylist");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.TitleNavigation)
                    .WithMany(p => p.ListSongPlaylists)
                    .HasForeignKey(d => d.Title)
                    .HasConstraintName("FK__ListSongP__title__1BC821DD");
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Playlist");

                entity.Property(e => e.Cod).HasColumnName("cod");

                entity.Property(e => e.CodiceIdentificativoPlaylist)
                    .HasColumnName("codiceIdentificativoPlaylist")
                    .HasComputedColumnSql("([cod])", false);

                entity.Property(e => e.DataDiCreazione)
                    .HasColumnType("date")
                    .HasColumnName("dataDiCreazione");

                entity.Property(e => e.DataUltimaModifica)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Cod)
                    .HasConstraintName("FK__Playlist__cod__1DB06A4F");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("PK__Song__2CB664DD9DFDCAA7");

                entity.ToTable("Song");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Album)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Artist)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.HasOne(d => d.AlbumNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.Album)
                    .HasConstraintName("FK__Song__Album__17F790F9");

                entity.HasOne(d => d.ArtistNavigation)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.Artist)
                    .HasConstraintName("FK__Song__Artist__17036CC0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
