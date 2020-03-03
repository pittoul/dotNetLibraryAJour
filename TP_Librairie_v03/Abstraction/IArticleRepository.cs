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
 * Dans ce fichier doivent se trouver les signatures des m�thodes demand�es dans le TP
 * 
 * 
 * 
 * - - - - - - -   On utilise ici le Design Pattern "REPOSITORY"  - - - - - - - - - - - - - - 
 * 
 * 
 * 
 * 
 * C'est dans cette interface nomm�e "IUnTrucRepository" que nous allons �crire toutes
 * les signatures des m�thodes qui seront impl�ment�es dans la classe TrucEF pour Truc Entity Framework,
 * un framework de type ORM/DAO qui permet de communiquer avec une base de donn�es.
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
 * Front Client -> Objets de Classes Concr�tes -> ObjetsEF impl�mentants IRepo -> DbContext -> la BDD
 * 
 *  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * 
 * 
 * 
 * 
 * DbContext : en langage C# y est �crit tout le code servant � g�n�rer l'ensemble de la base de donn�es.
 *             Ce code est ensuite transmis correctement � la base de donn�es, en fonction de son type,
 *             tel que s�lectionn� dans la m�thode "OnConfiguring".
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