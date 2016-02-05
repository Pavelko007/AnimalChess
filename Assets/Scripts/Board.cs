using UnityEngine;

namespace AnimalChess
{
    public class Board : MonoBehaviour
    {
        public Sprite boardSprite;

        // Use this for initialization
        void Start()
        {
            boardSprite = GetComponent<SpriteRenderer>().sprite;
        }
    }
}
