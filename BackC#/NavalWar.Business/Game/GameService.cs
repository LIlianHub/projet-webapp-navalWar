using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.User;
using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.DAL.Repository;
using NavalWar.DAL.Outils;
using NavalWar.DAL.Models;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using NavalWar.Business.ObjectRequest;
using NavalWar.DTO.Bateau;

namespace NavalWar.Business.Game
{
    public class GameService : IGameService
    {


        private readonly IPlayerDbRepository _repositoryPlayer;
        private readonly ISessionDbRepository _repositorySession;

        public GameService(IPlayerDbRepository repositoryPlayer, ISessionDbRepository repositorySession)
        {
            _repositoryPlayer = repositoryPlayer;
            _repositorySession = repositorySession;
        }



        public AllElementPlayerAnswer CreateGame(string nameP1)
        {
            Player p1 = new Player(nameP1);
            Player p2 = new Player("En Attente");
            Jeu newGame = new Jeu(p1, p2);
            int id = _repositorySession.AddSession(newGame);
            var recup = _repositorySession.GetSession(id);
            return new AllElementPlayerAnswer(recup.Player1Id, recup.Player2Id, recup.ID, p1, "Partie créée", recup.Etat, recup.AuTourDe, false);

        }

        public AllElementPlayerAnswer JoinGame(int id, string nameP2)
        {
            var recup = _repositorySession.GetSession(id);
            if (recup != null)
            {
                if (recup.Etat == -1)
                {
                    // Ajout nom player 2
                    Player p2 = _repositoryPlayer.GetPlayer(recup.Player2Id);
                    p2.Name = nameP2;
                    _repositoryPlayer.UpdatePlayerName(recup.Player2Id, p2);

                    // Changement Etat Partie
                    _repositorySession.ChangeEtatSession(id, 0);
                    // Joueur commence 1 commence
                    _repositorySession.ChangeJoueurCourant(id, recup.Player1Id);

                    return new AllElementPlayerAnswer(recup.Player2Id, recup.Player1Id, recup.ID, p2, "game rejoint", recup.Etat, recup.AuTourDe, false);
                }
                return new AllElementPlayerAnswer(-1, -1, -1, null, "Partie injoignable", -1, -1, null);
            }
            
            return new AllElementPlayerAnswer(-1, -1, -1, null, "Partie inconnue", -1, -1, null);
        }


        /*private bool VerifMdpGame(SessionDb session, string mdp)
        {
            return session.Password == Chiffrement(mdp);

        }

        private string Chiffrement(string passwordClear)
        {
            byte[] bytePassword = Encoding.UTF8.GetBytes(passwordClear);
            byte[] key = Encoding.UTF8.GetBytes("mdpchiffrement");

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // Configuration des paramètres du chiffrement
                aes.Key = SHA256Managed.Create().ComputeHash(key);
                aes.IV = MD5.Create().ComputeHash(key);

                // Création du transformateur de chiffrement pour le chiffrement
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);


                // Chiffrement des données
                byte[] encryptedBytes = encryptor.TransformFinalBlock(bytePassword, 0, bytePassword.Length);

                // Conversion des données chiffrées en chaîne de caractères en base64 pour faciliter le stockage et l'échange
                return Convert.ToBase64String(encryptedBytes);
            }
        }*/

        public int? GetEtatGame(int id)
        {
            var recup = _repositorySession.GetSession(id);
            if (recup != null)
            {
                return recup.Etat;
            }
            return null;
        }

        public int[]? GetIdPlayerInGame(int id)
        {
            var recup = _repositorySession.GetSession(id);
            if (recup != null)
            {
                return new int[] { recup.Player1Id, recup.Player2Id };
            }
            return null;
        }

        public int GetPlayerTour(int id)
        {
            var recup = _repositorySession.GetSession(id);
            if (recup != null)
            {
                return recup.AuTourDe;
            }
            return -1;
        }

        public AllElementPlayerAnswer GetAllPlayerInfo(int idSession, int Player1or2)
        {
            var recup = _repositorySession.GetSession(idSession);
            if (recup != null)
            {
                if (Player1or2 == 1)
                {
                    return new AllElementPlayerAnswer(recup.Player1Id, recup.Player2Id, recup.ID, _repositoryPlayer.GetPlayer(recup.Player1Id), "ok: Player1", recup.Etat, recup.AuTourDe, recup.Player1Ready);
                }
                else if (Player1or2 == 2)
                {
                    return new AllElementPlayerAnswer(recup.Player2Id, recup.Player1Id, recup.ID, _repositoryPlayer.GetPlayer(recup.Player2Id), "ok: Player2", recup.Etat, recup.AuTourDe, recup.Player2Ready);
                }
            }
            return new AllElementPlayerAnswer(-1, -1, -1, null, "Erreur lors de la récupération de la session", -1, -1, null);
        }

        public EditValidateAnswer ValideReady(EditValidateRequest editValidateRequest)
        {
            var listeBoat = _repositoryPlayer.GetListBoatForStart(_repositorySession.GetIdPlayer1or2(editValidateRequest.Player1or2, editValidateRequest.IdSession));
            Console.WriteLine(editValidateRequest.Player1or2);
            Console.WriteLine(editValidateRequest.IdSession);
            Console.WriteLine(_repositorySession.GetIdPlayer1or2(editValidateRequest.Player1or2, editValidateRequest.IdSession));
            // Si tous les bateaux sont posées
            if (listeBoat != null && listeBoat.ListBoat.Count == 0)
            {
                bool retour = _repositorySession.SetReady(editValidateRequest.Player1or2, editValidateRequest.IdSession);
                if (retour)
                {
                    _repositorySession.ChangeEtatSession(editValidateRequest.IdSession, 1);
                    return new EditValidateAnswer(true, "Composition validée ! La partie va commencer !");
                }
                else
                {
                    return new EditValidateAnswer(true, "Composition validée ! En attente d'un adversaire !");
                }
            }
            return new EditValidateAnswer(false, "Posez tous les bateaux");

        }

        public bool? IsPlayerReady(int idSession, int Player1or2)
        {
            var recup = _repositorySession.GetSession(idSession);
            if (recup != null)
            {
                if (Player1or2 == 1)
                {
                    return recup.Player1Ready;
                }
                else if (Player1or2 == 2)
                {
                    return recup.Player2Ready;
                }
            }
            return null;
        }


    }
}

