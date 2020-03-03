using LibrairieDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPLibrairiev03.Abstraction;

namespace TPLibrairiev03.EFClasses
{
    // le implement est ici représenté par ':'
    public class ArticleRepoEF : IArticleRepository
    {
        //public LibrairieDbContext db = new LibrairieDbContext();

        public LibrairieDbContext db;
        private readonly IPositionMagasin positionMagasin;


        public ArticleRepoEF(LibrairieDbContext db, IPositionMagasin positionMagasin)
        {
            this.db = db;
            this.positionMagasin = positionMagasin;
        }

        public Article FindById(int id)
        {
            Article article = new Article();
            try
            {

                article = db.Articles.First(i => i.Id == id);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Oups, erreur dans FindById mais on continue !");
                article.Id = 0;
                article.Libelle = "Cet article n'existe pas !";
            }
            //finally
            //{
            //}

            return article;
        }


        public List<Article> GetAllArticles()
        {
            return db.Articles.ToList();
        }

        //public PositionMagasin GetPosition(Article Article)
        //public List<PositionMagasin> GetPositionMagasins(Article Article)
        //{
        //    List<PositionMagasin> PositionMagasins = db.PositionMagasins(p => p.IdArticle == Article.Id);
        //    return PositionMagasins;
        //}

        public List<Article> GetAllArticlesByEtagere(Etagere Etagere)
        {
            // d'oú vient la collection PositionMagasins ???
            return db.Articles.Where(a => a.PositionMagasins.Any(p => p.IdEtagere == Etagere.Id)).ToList();
        }

        public List<Article> GetAllArticlesBySecteur(Secteur Secteur)
        {
            List<Article> lesArticlesDuSecteur = new List<Article>();
            List<Etagere> listingEtageres = db.Etageres.Where(e => e.IdSecteur == Secteur.Id).ToList();
            foreach (Etagere etag in listingEtageres)
            {
                lesArticlesDuSecteur.AddRange(GetAllArticlesByEtagere(etag));
            }
            return lesArticlesDuSecteur;
        }

        public decimal GetPoidsArticlesSurEtagere(Etagere etagere)
        {
            var poidsTotal = 0m;
            var qte = 0;
            ICollection<Article> articles = GetAllArticlesByEtagere(etagere);

            foreach (Article article in articles)
            {

                ICollection<PositionMagasin> p = GetPositionMagasins(article);
                foreach (PositionMagasin pos in article.PositionMagasins)
                {
                    //Console.WriteLine($"Qté de la POSITION : {pos.Quantite}");
                    if (pos.IdEtagere == etagere.Id)
                    {
                        qte += pos.Quantite;
                        //Console.WriteLine("Quantite de produits : ", qte);
                        poidsTotal += article.Poids * qte;
                    }
                }
            }
            //Console.WriteLine("Poids TOTAL de produits sur l'etagere: ", poidsTotal);
            Console.WriteLine($"Poids actuellement sur l'étagère numéro {etagere.Id} :\n{poidsTotal}");

            return poidsTotal;
        }

        public decimal GetNombreOcurrenceArticle(Article article)
        {
            var qte = 0;
            //PositionMagasinRepoEF pos = new PositionMagasinRepoEF();
            ICollection<PositionMagasin> positionsMagasin = positionMagasin.GetAllPositions();

            foreach (PositionMagasin posi in positionsMagasin)
            {
                if (posi.IdArticle == article.Id)
                {
                    qte += posi.Quantite;
                }
            }

            return qte;
        }

        public bool VerifPoidsEtagere(Etagere etagere)
        {
            var poids = GetPoidsArticlesSurEtagere(etagere);

            return (etagere.PoidsMaximum > poids);
        }

        public ICollection<PositionMagasin> GetPositionMagasins(Article Article)
        {
            Article.PositionMagasins = (ICollection<PositionMagasin>)db.PositionMagasins.Where(p => p.IdArticle == Article.Id).ToList();
            return Article.PositionMagasins;

        }

        public decimal GetPrixMoyenParSecteur(Secteur Secteur)
        {
            var somme = 0m;
            List<Article> maListe = GetAllArticlesBySecteur(Secteur);
            foreach (Article article in maListe)
            {
                somme += article.PrixInitial;
            }
            return somme / maListe.Count();
        }

        public void Insert(Article Article)
        {
            db.Articles.Add(Article);
            db.SaveChanges();
        }

        public void Remove(Article Article)
        {
            db.Remove(Article);
            db.SaveChanges();
        }


        public void Update(Article Article)
        {
            db.Update(Article);
            db.SaveChanges();


        }

    }
}
