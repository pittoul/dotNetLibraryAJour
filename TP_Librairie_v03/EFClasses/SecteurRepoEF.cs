using LibrairieDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPLibrairiev03.Abstraction;

namespace TPLibrairiev03.EFClasses
{
    // le implement est ici représenté par ':'
    public class SecteurRepoEF : ISecteur

    {
        //public LibrairieDbContext db = new LibrairieDbContext();

        public LibrairieDbContext db;
        private readonly IArticleRepository articleRepository;
        private readonly IPositionMagasin positionMagasin;

        public SecteurRepoEF(LibrairieDbContext db, IArticleRepository articleRepository, IPositionMagasin positionMagasin)
        {
            this.db = db;
            this.articleRepository = articleRepository;
            this.positionMagasin = positionMagasin;
        }

        public Secteur FindById(int id)
        {
            Secteur secteur = new Secteur();
            try
            {
                secteur = db.Secteurs.Include(s => s.Etageres).First(i => i.Id == id);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Oups, erreur dans FindById mais on continue !");
                secteur.Id = 0;
            }
            //finally
            //{
            //}

            return secteur;
        }


        public List<Secteur> GetAllSecteur()
        {
            return db.Secteurs.Include(s => s.Etageres).ToList();
        }



        public void Insert(Secteur secteur)
        {
            db.Secteurs.Add(secteur);
            db.SaveChanges();
        }

        public void Remove(Secteur secteur)
        {
            db.Remove(secteur);
            db.SaveChanges();
        }


        public void Update(Secteur secteur)
        {
            db.Update(secteur);
            db.SaveChanges();
        }

        public decimal GetPrixMoyenParSecteur(Secteur secteur)
        {
            //    ArticleRepoEF aef = new ArticleRepoEF();
            ICollection<Etagere> etageres = secteur.Etageres;
            var prix = 0m;

            List<Article> articles = articleRepository.GetAllArticlesBySecteur(secteur);

            foreach (Article a in articles)
            {
                prix += a.PrixInitial;
            }

            return prix / articles.Count();
        }

        public decimal GetQteArticlesParSecteur(Secteur secteur)
        {
            var qte = 0m;
            //PositionMagasinRepoEF posEF = new PositionMagasinRepoEF();

            List<PositionMagasin> positions = positionMagasin.GetAllPositions();

            //ArticleRepoEF aef = new ArticleRepoEF();

            List<Article> articles = articleRepository.GetAllArticlesBySecteur(secteur);

            ICollection<Etagere> etList = secteur.Etageres;

            foreach (Etagere et in etList)
            {
                foreach (PositionMagasin etPos in positions)
                {
                    if (et.Id == etPos.IdEtagere)
                    {
                        qte += etPos.Quantite;
                    }
                }
            }

            return qte;
        }

        public decimal GetNombreEtageresParSecteur(Secteur secteur)
        {
            ICollection<Etagere> etList = secteur.Etageres;
            return etList.Count();
        }

        public decimal GetTauxRemplissageParSecteur(Secteur secteur)
        {

            var poidsSecteur = 0m;
            //ArticleRepoEF aef = new ArticleRepoEF();

            ICollection<Etagere> etList = secteur.Etageres;

            var poidsEtagere = 0m;

            foreach (Etagere et in etList)
            {
                poidsSecteur += articleRepository.GetPoidsArticlesSurEtagere(et);
                poidsEtagere += et.PoidsMaximum;
            }

            return (poidsSecteur / poidsEtagere) * 100;
        }
    }
}
