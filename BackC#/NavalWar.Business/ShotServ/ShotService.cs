using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalWar.DTO.Jeu;
using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.Business.ObjectRequest;
using NavalWar.DAL.Models;
using NavalWar.DAL;
using NavalWar.DAL.Outils;
using NavalWar.DAL.Repository;
using NavalWar.DTO.Plateau;
using NavalWar.DTO.Bateau;

namespace NavalWar.Business.ShotServ
{
    public class ShotService : IShotService
    {

        private readonly IPlayerDbRepository _repositoryPlayer;
        private readonly ISessionDbRepository _repositorySession;

        public ShotService(IPlayerDbRepository repositoryPlayer, ISessionDbRepository repositorySession)
        {
            _repositoryPlayer = repositoryPlayer;
            _repositorySession = repositorySession;
        }

        public DTO.Plateau.PlateauShot? GetPlateauShotbyPlayerId(int idPlayer)
        {
            return _repositoryPlayer.getPlateauShot(idPlayer);
        }

        public ShotAnswer Shot(ShotRequest shotRequest)
        {
            PlateauBoat? target = _repositoryPlayer.getPlateauBoat(shotRequest.IdEnnemy);
            DTO.Plateau.PlateauShot? shotPlateau = _repositoryPlayer.getPlateauShot(shotRequest.IdPlayer);
            if (target != null && shotPlateau != null)
            {
                // pas deja tiré ici
                Console.WriteLine("Type touché: " + shotPlateau.GetElementPlateau(shotRequest.X, shotRequest.Y).GetType());
                if (shotPlateau.GetElementPlateau(shotRequest.X, shotRequest.Y) is CaseEau)
                {
                    // le retour qui va varier
                    ShotAnswer retour;

                    //touché !
                    if (target.GetElementPlateau(shotRequest.X, shotRequest.Y) is CaseBateau)
                        {
                        /* Gestion plateau adversaire */
                        // id Bateau touché
                        int boatId = ((CaseBateau)(target.GetElementPlateau(shotRequest.X, shotRequest.Y))).Pere.ID;

                        // On enleve la partie touchée du bateau dans liste bateau
                        bool isBoatKill = target.HitBoat(boatId, shotRequest.X, shotRequest.Y);
                        // On enleve la partie touchée du bateau sur le plateau
                        target.SetElementPlateau(new Shot(shotRequest.X, shotRequest.Y, "ShotSuccess"));

                        // Sur le plateau shot
                        shotPlateau.SetElementPlateau(new Shot(shotRequest.X, shotRequest.Y, "ShotSuccess"));

                        bool isWinner = target.CheckLoose();

                        if (isWinner)
                        {
                            _repositorySession.ChangeEtatSession(shotRequest.IdSession, 2);
                            _repositoryPlayer.SetIsWinner(shotRequest.IdPlayer, true);
                        }
                        
                        retour = new ShotAnswer(true, isWinner, shotPlateau, "Touché", isBoatKill);
                    }
                    //raté !
                    else
                    {
                        target.SetElementPlateau(new Shot(shotRequest.X, shotRequest.Y, "ShotMiss"));
                        shotPlateau.SetElementPlateau(new Shot(shotRequest.X, shotRequest.Y, "ShotMiss"));
                        retour = new ShotAnswer(false, false, shotPlateau, "Raté", false);
                    }
                    _repositoryPlayer.UpdatePlayerPlateauBoat(shotRequest.IdEnnemy, target);
                    _repositoryPlayer.UpdatePlayerPlateauShot(shotRequest.IdPlayer, shotPlateau);
                    _repositorySession.ChangeJoueurCourant(shotRequest.IdSession, shotRequest.IdEnnemy);
                    return retour;
                }

                return new ShotAnswer(null, null, null, "Vous avez déjà tiré ici", null);
            }

            return new ShotAnswer(null, null, null, "Erreur recuperation plateaux", null);
                
          
        }




    }
}
