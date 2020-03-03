using LibrairieDB;
using System;
using System.Collections.Generic;
using System.Reflection;
using TPLibrairiev03;
using TPLibrairiev03.EFClasses;

namespace ConsoleAppTD_Librairie
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TP Librairie \nBruno Andrieu");
            ArticleRepoEF truc = new ArticleRepoEF();
            truc.db.Database.EnsureDeleted();
            truc.db.Database.EnsureCreated();
            using (var ctx = new LibrairieDbContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                ctx.Secteurs.AddRange(
                    new[] {
                        new Secteur
                        {
                            Id = 1,
                            Nom = "Secteur A"
                        },
                        new Secteur
                        {
                            Id = 2,
                            Nom = "Secteur B"
                        }
                    });
                ctx.Etageres.AddRange(
                    new[] {
                        new Etagere
                        {
                            Id = 1,
                            PoidsMaximum = 15000,
                            IdSecteur = 1

                        },
                        new Etagere
                        {
                            Id = 2,
                            PoidsMaximum = 17000,
                            IdSecteur =1
                        },
                        new Etagere
                        {
                            Id = 3,
                            PoidsMaximum = 15500,
                            IdSecteur =1
                        },
                        new Etagere
                        {
                            Id = 4,
                            PoidsMaximum = 12000,
                            IdSecteur =2
                        }
                    });
                ctx.Articles.AddRange(
                    new[] {
                        new Article
                        {
                            Id = 1,
                            Libelle = "Tablette",
                            SKU = "123456",
                            DateSortie = new DateTime(2019, 02, 10),
                            PrixInitial = 499.99m,
                            Poids = 499m,
                        },
                        new Article
                        {
                            Id = 2,
                            Libelle = "Telephone",
                            SKU = "789101",
                            DateSortie = new DateTime(2019, 03, 02),
                            PrixInitial = 299.59m,
                            Poids = 258m,
                        },
                        new Article
                        {
                            Id = 3,
                            Libelle = "PC",
                            SKU = "147852",
                            DateSortie = new DateTime(2018, 05, 05),
                            PrixInitial = 1566.23m,
                            Poids = 1890m,
                        },
                        new Article
                        {
                            Id = 4,
                            Libelle = "Bureau",
                            SKU = "258963",
                            DateSortie = new DateTime(2010, 06, 02),
                            PrixInitial = 350m,
                            Poids = 9500m,
                        }
                    });
                ctx.PositionMagasins.AddRange(
                    new[]{
                        new PositionMagasin
                        {
                            IdArticle = 1,
                            IdEtagere = 1,
                            Quantite = 10
                        },
                        new PositionMagasin
                        {
                            IdArticle = 2,
                            IdEtagere = 1,
                            Quantite = 2
                        },
                        new PositionMagasin
                        {
                            IdArticle = 1,
                            IdEtagere = 3,
                            Quantite = 15
                        }
                });

                ctx.SaveChanges();
            }
            Etagere uneEtagere = new Etagere();
            uneEtagere.Id = 1;
            uneEtagere.PoidsMaximum = 15000;
            uneEtagere.IdSecteur = 1;

            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            //Console.WriteLine("Poids TOTAL de produits sur l'etagere: ");
            Console.WriteLine(truc.GetPoidsArticlesSurEtagere(uneEtagere));

            //var poids = truc.GetPoidsArticlesSurEtagere(uneEtagere);
            //Console.WriteLine($"Poids total : {poids}");

            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            List<Article> lesArticles = truc.GetAllArticlesByEtagere(uneEtagere);
            int count = 0;
            Console.WriteLine($"Poids Max Etagère numéro {uneEtagere.Id} : {uneEtagere.PoidsMaximum}");
            foreach (Article unArticle in lesArticles)
            {
                count++;
                Console.WriteLine($"Rang de l'Element #{count}: \nLibellé de l'article: {unArticle.Libelle}");
                Console.WriteLine($"Poids de l'article: {unArticle.Poids}");
                Console.WriteLine("- - - - - - - - -      - - - -        - -  -");
                ICollection<PositionMagasin> p = truc.GetPositionMagasins(unArticle);
                foreach (PositionMagasin pos in unArticle.PositionMagasins)
                {
                    if (pos.IdEtagere == uneEtagere.Id)
                    {
                        Console.WriteLine($"Qté de {unArticle.Libelle} à cette position : {pos.Quantite}");
                    }
                    Console.WriteLine("- - - - - - - - -      - - - -        - -  -");

                }
            }
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine($"Nombre d'articles sur cette étagère : {lesArticles.Count}");
            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * ");

            Console.WriteLine("\n\nTest article inexistant : id = 123456 ");
            var articleX = truc.FindById(123456);
            Console.WriteLine(articleX.Libelle);


            /*
             Type t = typeof(Article);
            // Get the public properties.
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("The number of public properties: {0}.\n",
                              propInfos.Length);
            // Display the public properties.
            DisplayPropertyInfo(propInfos);

            // Get the nonpublic properties.
            PropertyInfo[] propInfos1 = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("The number of non-public properties: {0}.\n",
                              propInfos1.Length);
            // Display all the nonpublic properties.
            DisplayPropertyInfo(propInfos1);
        }

        public static void DisplayPropertyInfo(PropertyInfo[] propInfos)
        {
            // Display information for all properties.
            foreach (var propInfo in propInfos)
            {
                bool readable = propInfo.CanRead;
                bool writable = propInfo.CanWrite;

                Console.WriteLine("   Property name: {0}", propInfo.Name);
                Console.WriteLine("   Property type: {0}", propInfo.PropertyType);
                Console.WriteLine("   Read-Write:    {0}", readable & writable);
                if (readable)
                {
                    MethodInfo getAccessor = propInfo.GetMethod;
                    Console.WriteLine("   Visibility:    {0}",
                                      GetVisibility(getAccessor));
                }
                if (writable)
                {
                    MethodInfo setAccessor = propInfo.SetMethod;
                    Console.WriteLine("   Visibility:    {0}",
                                      GetVisibility(setAccessor));
                }
                Console.WriteLine();
            }
        */
        }

        public static String GetVisibility(MethodInfo accessor)
        {
            if (accessor.IsPublic)
                return "Public";
            else if (accessor.IsPrivate)
                return "Private";
            else if (accessor.IsFamily)
                return "Protected";
            else if (accessor.IsAssembly)
                return "Internal/Friend";
            else
                return "Protected Internal/Friend";
        }
    }
}

