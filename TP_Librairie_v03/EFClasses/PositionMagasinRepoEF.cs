using LibrairieDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPLibrairiev03.Abstraction;

namespace TPLibrairiev03.EFClasses
{
    // le implement est ici représenté par ':'
    public class PositionMagasinRepoEF : IPositionMagasin
    {
        public LibrairieDbContext db = new LibrairieDbContext();

        public PositionMagasin FindById(int idArticle, int idEtagere)
        {
            PositionMagasin positionMagasin = new PositionMagasin();
            try
            {
                positionMagasin = db.PositionMagasins.First(i => i.IdArticle == idArticle && i.IdEtagere == idEtagere);
                db.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Oups, erreur dans FindById mais on continue !");
                positionMagasin.IdArticle = 0;
                positionMagasin.IdEtagere = 0;
            }
            //finally
            //{
            //}

            return positionMagasin;
        }


        public List<PositionMagasin> GetAllPositions()
        {
            return db.PositionMagasins.ToList();
        }

        public void Insert(PositionMagasin positionMagasin)
        {
            db.PositionMagasins.Add(positionMagasin);
            db.SaveChanges();
        }

        public void Remove(PositionMagasin positionMagasin)
        {
            db.Remove(positionMagasin);
            db.SaveChanges();
        }


        public void Update(PositionMagasin positionMagasin)
        {
            db.Update(positionMagasin);
            db.SaveChanges();


        }
    }
}
