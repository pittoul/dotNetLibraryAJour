using LibrairieDB;
using System;
using TPLibrairiev03;
using TPLibrairiev03.EFClasses;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace UnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test01InsererDonneesEtFindFirstArticle()
        {
            // On crée la bdd poour les tests (attention ! la bdd est suppr avant d'être crée !)
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
            // Arrange
            ArticleRepoEF accesBdd = new ArticleRepoEF();

            // Act
            Article monArticle = accesBdd.FindById(1);

            // Assert
            monArticle.Libelle.Should().Be("Tablette");
        }



        [Fact]
        public void Test02GetArticleById()
        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();

            // Act
            Article monArticle = accesBdd.FindById(3);

            // Assert
            monArticle.SKU.Should().Be("147852");

        }

        [Fact]
        public void Test03DeleteArticle()
        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();
            ICollection<Article> articles = accesBdd.GetAllArticles();
            int longueurListe = articles.Count;

            // Act
            Article monArticle = accesBdd.FindById(2);
            accesBdd.Remove(monArticle);
            ICollection<Article> articles2 = accesBdd.GetAllArticles();
            int longueurListe2 = articles2.Count;


            // Comparer la longueur de la liste de tous les articles avant et après le Remove()


            // Assert
            longueurListe.Should().Be(longueurListe2 + 1);
        }

        [Fact]
        public void Test04GetCollectionTousArticles()

        {
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

            // Arrange
            ArticleRepoEF accesBdd = new ArticleRepoEF();

            // Act
            ICollection<Article> articles = accesBdd.GetAllArticles();

            // Assert
            articles.Should().HaveCount(4);
        }


        [Fact]
        public void Test05GetCollectionArticlesParEtagere()

        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();
            Etagere uneEtagere = new Etagere();
            uneEtagere.Id = 1;
            uneEtagere.PoidsMaximum = 15000;
            uneEtagere.IdSecteur = 1;


            // Act
            ICollection<Article> articles = accesBdd.GetAllArticlesByEtagere(uneEtagere);

            // Assert
            articles.Should().HaveCount(2);
        }

        [Fact]
        public void Test06GetCollectionArticlesParSecteur()
        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();
            Secteur unSecteur = new Secteur();
            unSecteur.Id = 1;
            unSecteur.Nom = "Secteur A";



            // Act
            ICollection<Article> articles = accesBdd.GetAllArticlesBySecteur(unSecteur);

            // Assert
            articles.Should().HaveCount(3);
        }

        [Fact]
        public void Test07GetPoidsDeEtagere()

        {
            // Arrange
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
            var article = new Article();
            var poidsMax = 15000;
            Etagere uneEtagere = new Etagere();
            uneEtagere.Id = 1;
            uneEtagere.PoidsMaximum = 15000;
            uneEtagere.IdSecteur = 1;
            // Act

            // Assert
            uneEtagere.PoidsMaximum.Should().Be(poidsMax);
        }


        [Fact]
        public void Test08GetPoidsArticlesSurEtagere()
        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();
            Etagere uneEtagere = new Etagere();
            uneEtagere.Id = 1;
            uneEtagere.PoidsMaximum = 15000;
            uneEtagere.IdSecteur = 1;
            var reponseSouhaitee = 8086m;

            // Act
            var poidsSurEtagere = accesBdd.GetPoidsArticlesSurEtagere(uneEtagere);

            // Assert
            poidsSurEtagere.Should().Be(reponseSouhaitee);
        }


        [Fact]
        public void Test09NePasPouvoirDepasserPoidsMaximumEtagere()

        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();
            Etagere uneEtagere = new Etagere();
            uneEtagere.Id = 1;
            uneEtagere.PoidsMaximum = 8000m;
            uneEtagere.IdSecteur = 1;

            PositionMagasin pos = new PositionMagasin();
            pos.Etagere = uneEtagere;

            var poidsTotal = 0m;


            // Act
            var result = accesBdd.VerifPoidsEtagere(uneEtagere);


            // Assert
            result.Should().Be(false);
        }

        [Fact]
        public void Test10ChercherUnArticleInexistant()

        {
            // Arrange
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
            ArticleRepoEF accesBdd = new ArticleRepoEF();

            var article = accesBdd.FindById(123456);


            // Act

            // Assert
            article.Libelle.Should().Be("Cet article n'existe pas !");
        }

        [Fact]
        public void Test11NombreOccurencesArticle()

        {
            // Arrange
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

            ArticleRepoEF accesBdd = new ArticleRepoEF();
            var article = new Article();
            article.Id = 1;
            article.Libelle = "Tablette";
            article.SKU = "123456";
            article.DateSortie = new DateTime(2019, 02, 10);
            article.PrixInitial = 499.99m;
            article.Poids = 499m;
            var nbreSouhaite = 25;

            // Act
            var nbreOccurence = accesBdd.GetNombreOcurrenceArticle(article);

            // Assert
            nbreOccurence.Should().Be(nbreSouhaite);

        }

        [Fact]
        public void Test12PrixMoyenParSecteur()
        {
            // Arrange
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

            SecteurRepoEF sef = new SecteurRepoEF();

            Secteur secteur = new Secteur();
            secteur.Id = 1;
            var prixMoyen = 0m;


            // Act
            prixMoyen = sef.GetPrixMoyenParSecteur(secteur);

            // Assert
            prixMoyen.Should().Be(433.19m);
        }

        [Fact]
        public void Test13QteArticlesParSecteur()
        {
            // Arrange
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

            SecteurRepoEF sef = new SecteurRepoEF();

            Secteur secteur = sef.FindById(1);

            // Act
           var qte = sef.GetQteArticlesParSecteur(secteur);

            // Assert
            qte.Should().Be(27m);
        }

        [Fact]
        public void Test14NombreEtageresParSecteur()
        {
            // Arrange
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
            SecteurRepoEF sef = new SecteurRepoEF();

            Secteur secteur = sef.FindById(1);

            // Act
            var qte = sef.GetNombreEtageresParSecteur(secteur);

            // Assert
            qte.Should().Be(3);
        }

        
        [Fact]
        public void Test15TauxRemplissageParSecteur()
        {
            // Arrange
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
            SecteurRepoEF sef = new SecteurRepoEF();

            Secteur secteur = sef.FindById(1);

            // Act
            string qte = sef.GetTauxRemplissageParSecteur(secteur).ToString("##.##");

            // Assert
            qte.Should().Be("32,78");
        }
    }
}
