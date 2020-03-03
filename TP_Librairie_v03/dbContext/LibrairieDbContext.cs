using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TPLibrairiev03;

namespace LibrairieDB
{
    public class LibrairieDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; } // permet de faire automatiquement des collections d'objets !
        public DbSet<Etagere> Etageres { get; set; }
        public DbSet<Secteur> Secteurs { get; set; }
        public DbSet<PositionMagasin> PositionMagasins { get; set; }

        public LibrairieDbContext(DbContextOptions<LibrairieDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
             * 
             * création de la classe de configuration pour l'entité "Article"
             * 
             */
            var ArticleEntity = modelBuilder.Entity<Article>();
            // définition du mapping
            ArticleEntity.HasKey(m => m.Id); // définition du champ clé
            ArticleEntity.Property(m => m.Libelle).HasMaxLength(256).IsRequired();
            ArticleEntity.Property(m => m.SKU).HasMaxLength(256).IsRequired();
            ArticleEntity.Property(m => m.DateSortie).IsRequired();
            ArticleEntity.Property(m => m.PrixInitial).IsRequired();
            ArticleEntity.Property(m => m.Poids).IsRequired();
            // définition des clés étrangères qu'on va retrouver dans PositionMagasins ?
            ArticleEntity
                .HasMany(m => m.PositionMagasins) // Un article a plusieurs positions 
                .WithOne(m => m.Article) // qui font reference à un article
                .HasForeignKey(m => m.IdArticle); // dont la clé etrangère est...


            /**
             * 
             * création de la classe de configuration pour l'entité "SECTEUR"
             * 
             */
            var SecteurEntity = modelBuilder.Entity<Secteur>();
            SecteurEntity.HasKey(m => m.Id);
            SecteurEntity.Property(m => m.Nom).HasMaxLength(256).IsRequired(); // définition de contrainte
            //SecteurEntity.HasMany(m => m.Etageres);
            SecteurEntity
                .HasMany(m => m.Etageres) // A plusieurs étagères, 
                .WithOne(m => m.Secteur) // chaque étagère se référant à un secteur...
                .HasForeignKey(m => m.IdSecteur); // dont la clé etrangère ...


            /**
            * 
            * création de la classe de configuration pour l'entité "ETAGERE"
            * 
            */
            var EtagereEntity = modelBuilder.Entity<Etagere>();
            // définition du mapping
            EtagereEntity.HasKey(m => m.Id);
            EtagereEntity.Property(m => m.PoidsMaximum).IsRequired();
            EtagereEntity.Property(m => m.IdSecteur).IsRequired(); // définition de contrainte
            // définiton des cardinalités et clé étrangère
            EtagereEntity
                .HasOne(m => m.Secteur) // Une étagère est dans un secteur 
                .WithMany(m => m.Etageres) // et un secteur a plusieurs étagères...
                .HasForeignKey(m => m.IdSecteur); // avec la clé etrangère ...
            EtagereEntity
                .HasMany(m => m.PositionMagasins)
                .WithOne(m => m.Etagere)
                .HasForeignKey(m => m.IdEtagere);

            /**
            * 
            * 
            *        création de la classe de configuration pour l'entité "POSITION MAGASIN"
            * 
            */
            var PositionMagasinEntity = modelBuilder.Entity<PositionMagasin>();
            // définition du mapping
            PositionMagasinEntity.HasKey(m => new { m.IdArticle, m.IdEtagere }); // définition d'une clé composée
            //PositionMagasinEntity.Property(m => m.IdArticle);
            PositionMagasinEntity.Property(m => m.Quantite);
            PositionMagasinEntity
                .HasOne(m => m.Etagere)
                .WithMany(m => m.PositionMagasins)
            .HasForeignKey(m => m.IdEtagere);
            PositionMagasinEntity
                .HasOne(m => m.Article)
                .WithMany(m => m.PositionMagasins)
            .HasForeignKey(m => m.IdArticle);



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // définition de la base de données à utiliser ainsi que de la chaine de connexion
            optionsBuilder.UseSqlite("Filename=librairie_tp_dot_net.db");

            base.OnConfiguring(optionsBuilder);
        }

    }
}
