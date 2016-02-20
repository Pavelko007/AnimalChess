using UnityEngine;

namespace AnimalChess
{
    public class Board : MonoBehaviour
    {
        [HideInInspector] public Logic.Board board;

        [HideInInspector] public Sprite boardSprite;

        // Use this for initialization
        void Awake()
        {
            board = new Logic.Board();
            board.CreateAnimals();

            boardSprite = GetComponent<SpriteRenderer>().sprite;
        }
    }
}