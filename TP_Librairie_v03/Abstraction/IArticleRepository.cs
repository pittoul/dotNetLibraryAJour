using System.Collections.Generic;

/**
 * 
 * 
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
 * 
 * 
 * 
 *              FRAMEWORK C# : .NET
 *              
 *              
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
 * 
 * 
 * 
 * Dans ce fichier doivent se trouver les signatures des méthodes demandées dans le TP
 * 
 * 
 * 
 * - - - - - - -   On utilise ici le Design Pattern "REPOSITORY"  - - - - - - - - - - - - - - 
 * 
 * 
 * 
 * 
 * C'est dans cette interface nommée "IUnTrucRepository" que nous allons écrire toutes
 * les signatures des méthodes qui seront implémentées dans la classe TrucEF pour Truc Entity Framework,
 * un framework de type ORM/DAO qui permet de communiquer avec une base de données.
 * 
 * 
 * 
 * 
 *                 ENTITY FRAMEWORK => OUTIL DE PERSISTANCE DES DONNEES
 * 
 * 
 * 
 * 
 *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  
 * Front Client -> Objets de Classes Concrètes -> ObjetsEF implémentants IRepo -> DbContext -> la BDD
 * 
 *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * 
 * 
 * 
 * 
 * DbContext : en langage C# y est écrit tout le code servant à générer l'ensemble de la base de données.
 *             Ce code est ensuite transmis correctement à la base de données, en fonction de son type,
 *             tel que sélectionné dans la méthode "OnConfiguring".
 * 
 * 
 * 
    */
namespace TPLibrairiev03.Abstraction
{
    public interface IArticleRepository
    {
        void Insert(Article Article);
        void Update(Article Article);
        void Remove(Article Article);
        Article FindById(int id);
        List<Article> GetAllArticles();
        List<Article> GetAllArticlesByEtagere(Etagere Etagere);
        List<Article> GetAllArticlesBySecteur(Secteur Secteur);
        decimal GetNombreOcurrenceArticle(Article article);
        bool VerifPoidsEtagere(Etagere etagere);
        decimal GetPrixMoyenParSecteur(Secteur Secteur);
        decimal GetPoidsArticlesSurEtagere(Etagere etagere);
        ICollection<PositionMagasin> GetPositionMagasins(Article Article);
    }
}