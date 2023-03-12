using NavalWar.DAL.Repository;
using NavalWar.DTO.Plateau;
using NavalWar.DTO.Bateau;
using NavalWar.DTO.ObjectElementPlateau;
using NavalWar.Business.ObjectRequest;

namespace NavalWar.Business.BateauServ
{
    public class BateauService : IBateauService
    {

        private readonly IPlayerDbRepository _repositoryPlayer;

        public BateauService(IPlayerDbRepository repositoryPlayer)
        {
            _repositoryPlayer = repositoryPlayer;
        }

        public PlateauBoat? GetPlateauBoatbyPlayerId(int idPlayer)
        {
            PlateauBoat? test = _repositoryPlayer.getPlateauBoat(idPlayer);
            /*if(test.plateau[0] is CaseBateau)
            {
                Console.WriteLine("Pere: " + ((CaseBateau)test.plateau[0]).Pere.ToString());
            }*/
            
            return _repositoryPlayer.getPlateauBoat(idPlayer);
        }


        public EditBoatAnswer AddBoat(AddBoatRequest addBoatRequest)
        {
            PlateauBoat plateauboat = _repositoryPlayer.getPlateauBoat(addBoatRequest.IdPlayer);

            // On vérifie que le bateau peut être posé et si oui on le place
            if (plateauboat.AddBoatOnPlateau(
                new Boat(addBoatRequest.Boat.X,
                addBoatRequest.Boat.Y,
                addBoatRequest.Boat.Orientation,
                addBoatRequest.Boat.Length,
                addBoatRequest.Boat.Id,
                addBoatRequest.Boat.Type)))
            {

                //plateauboat.AffichePlateau();

                // Mise à jour de la liste de bateau à poser
                ListBoatForStart temp = _repositoryPlayer.GetListBoatForStart(addBoatRequest.IdPlayer);
                temp.RemoveBoat(addBoatRequest.Boat.Id);
                _repositoryPlayer.UpdateListBoatForStart(addBoatRequest.IdPlayer, temp);

                //Update du plateau
                _repositoryPlayer.UpdatePlayerPlateauBoat(addBoatRequest.IdPlayer, plateauboat);
                return new EditBoatAnswer("Bateau ajouté", plateauboat, true, temp);
            }

            else
            {
                return new EditBoatAnswer("Bateau non ajouté", null, null, null);
            }

        }

        public EditBoatAnswer RemoveBoat(RemoveBoatRequest removeBoatRequest)
        {
            // recuperation plateau
            PlateauBoat plateauboat = _repositoryPlayer.getPlateauBoat(removeBoatRequest.IdPlayer);

            // sauvegarde des infos du bateau
            Boat? saveBoat = plateauboat.GetBoat(removeBoatRequest.IdBoat);

            // suppression du bateau
            bool retour = plateauboat.RemoveBoat(removeBoatRequest.IdBoat);

            // si le bateau a été supprimé
            if (retour && saveBoat != null)
            {
                // Update Plateau
                _repositoryPlayer.UpdatePlayerPlateauBoat(removeBoatRequest.IdPlayer, plateauboat);

                //Update ListBoatForStart: on a un bateau a placer qui est revenu !
                ListBoatForStart temp = _repositoryPlayer.GetListBoatForStart(removeBoatRequest.IdPlayer);
                temp.AddBoat(new BoatForStart(saveBoat.Length, saveBoat.ID, saveBoat.Type));
                _repositoryPlayer.UpdateListBoatForStart(removeBoatRequest.IdPlayer, temp);

                return new EditBoatAnswer("Bateau supprimé", plateauboat, true, temp);
            }
            
            return new EditBoatAnswer("Bateau introuvable ou non posé", null, null, null);
        }

        public EditBoatAnswer MoveBoat(MoveBoatRequest moveBoatRequest)
        {
            PlateauBoat? plateauboat = _repositoryPlayer.getPlateauBoat(moveBoatRequest.IdPlayer);
            if (plateauboat != null)
            {
                Boat? oldBoat = plateauboat.GetBoat(moveBoatRequest.IdBoat);
                if (oldBoat != null)
                {
                    plateauboat.RemoveBoat(oldBoat.ID);
                    // on peut le placer au nouvel endroit
                    if(plateauboat.AddBoatOnPlateau(new Boat(moveBoatRequest.X, moveBoatRequest.Y, moveBoatRequest.Orientation, oldBoat.Length, oldBoat.ID, oldBoat.Type)))
                    {
                        _repositoryPlayer.UpdatePlayerPlateauBoat(moveBoatRequest.IdPlayer, plateauboat);
                        return new EditBoatAnswer("Bateau déplacé", plateauboat, true, null);
                    }

                    //si pas un bon deplacement on ne change rien et on save pas dans la database

                    return new EditBoatAnswer("Bateau non déplacé", null, null, null);
                }                
            }
            return new EditBoatAnswer("Bateau introuvable ou non posé", null, null, null);
        }

    }
}
