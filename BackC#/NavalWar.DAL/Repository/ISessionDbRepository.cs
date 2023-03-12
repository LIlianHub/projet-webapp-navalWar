using NavalWar.DAL.Models;
using NavalWar.DTO.Jeu;

namespace NavalWar.DAL.Repository
{
    public interface ISessionDbRepository
    {
        int AddSession(Jeu jeu);
        SessionDb? GetSession(int id);
        void RemoveSession(int id);
        void ChangeEtatSession(int id, int newEtat);
        void ChangeJoueurCourant(int idSession, int idPlayer);
        bool SetReady(int Player1Or2, int idSession);
        int GetIdPlayer1or2(int Player1Or2, int idSession);


    }
}