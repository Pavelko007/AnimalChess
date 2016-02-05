using UnityEngine;

namespace AnimalChess
{
    public class Tile : MonoBehaviour
    {
        public AnimalPiece animalPiece;

        void OnMouseDown()
        {
            if (!GameManager.instance.isMoving)
            {
                if (GameManager.instance.ActiveAnimalPiece != null)
                {
                    GameManager.instance.moveSelectedAnimal(this);
                }
                else if(animalPiece != null)
                {
                    GameManager.instance.ActiveAnimalPiece = animalPiece;
                }
            }
        }
    }
}
