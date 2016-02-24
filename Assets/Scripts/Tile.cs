using AnimalChess.Logic;
using UnityEngine;

namespace AnimalChess
{
    public class Tile : MonoBehaviour
    {
        public AnimalPiece Animal;
        public IPosition boardPos;

        void OnMouseDown()
        {
            if (GameManager.instance.isMoving) return;

            if (GameManager.instance.IsAnimalSelected())
            {
                GameManager.instance.MoveSelectedAnimal(this);
            }
            else if(!IsEmpty())
            {
                GameManager.instance.SelectedAnimal = Animal;
            }
        }

        private bool IsEmpty()
        {
            return Animal == null;
        }
    }
}
