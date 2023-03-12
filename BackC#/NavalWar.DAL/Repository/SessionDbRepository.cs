using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DAL.Models;
using NavalWar.DTO.User;
using NavalWar.DAL.Outils;
using NavalWar.DTO.Jeu;

namespace NavalWar.DAL.Repository
{
    public class SessionDbRepository : ISessionDbRepository
    {

        private readonly NavalContext _context;

        public SessionDbRepository(NavalContext context)
        {
            _context = context;
        }

        public int AddSession(Jeu jeu)
        {
            _context.SessionDbs.Add(SessionOutils.ToDb(jeu));
            _context.SaveChanges();
            // la derniere id entrée est celle de notre partie
            return _context.SessionDbs.Max(s => s.ID);
        }

        /*public List<Jeu> getAllSession()
        {
            return _context.SessionDbs.Select(s => SessionOutils.ToDTO(s)).ToList();
        }*/

        public SessionDb? GetSession(int id)
        {
            var session = _context.SessionDbs.FirstOrDefault(p => p.ID == id);
            if (session != null)
            {
                return session;
            }
            return null;
        }
        
        public void RemoveSession(int id)
        {
            var session = _context.SessionDbs.Find(id);
            if (session != null)
            {
                _context.SessionDbs.Remove(session);
                _context.SaveChanges();
            }
        }
        
        public void ChangeEtatSession(int id, int newEtat)
        {
            var session = _context.SessionDbs.First((s => s.ID == id));
            if (session != null)
            {
                session.Etat = newEtat;
                _context.SaveChanges();
            }
        }

        public void ChangeJoueurCourant(int idSession,int idPlayer)
        {
            var session = _context.SessionDbs.First((s => s.ID == idSession));
            if (session != null)
            {
                session.AuTourDe = idPlayer;
                _context.SaveChanges();
            }
        }

        // On retourne la valeur de l'autre pour savoir si lesdeux sont prets !
        public bool SetReady(int Player1Or2,int idSession)
        {
            var session = _context.SessionDbs.First(p => p.ID == idSession);
            if (session != null)
            {
                if (Player1Or2 == 1)
                {
                    session.Player1Ready = true;
                    _context.SaveChanges();
                    return session.Player2Ready;
                }
                else
                {
                    session.Player2Ready = true;
                    _context.SaveChanges();
                    return session.Player1Ready;
                }
            }
            return false;
        }
        
        public int GetIdPlayer1or2(int Player1Or2, int idSession)
        {
            var session = _context.SessionDbs.First(p => p.ID == idSession);
            if (session != null)
            {
                if (Player1Or2 == 1)
                {
                    return session.Player1Id;
                }
                else
                {
                    return session.Player2Id;
                }
            }
            return -1;
        }

   
    }
}
