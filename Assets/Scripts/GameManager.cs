using System.Collections.Generic;
using AnimalChess.Logic;
using UnityEngine;

namespace AnimalChess
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public List<GameObject> animalPrefabs;

        public AnimalPiece ActiveAnimalPiece;

        public Board board;
        public GameObject tilePrefab;
        public Sprite boardSprite;

        public int boardWidth = 7;
        public int boardHeight = 9;

        public bool isMoving = false;

        List<List<Tile>> tiles = new List<List<Tile>>();

        float tileSize;
        float leftEdge;
        float bottomEdge;

        void Awake()
        {
            instance = this;
        }


        // Use this for initialization
        void Start()
        {
            tileSize = board.boardSprite.bounds.size.x / boardWidth;
            leftEdge = board.transform.position.x - tileSize * 3;
            bottomEdge = board.transform.position.y - tileSize * 4;

            createTiles();
            createPlayers();
        }

        // Update is called once per frame
        void Update()
        {
            if (ActiveAnimalPiece != null && isMoving)
            {
                ActiveAnimalPiece.Move();
            }
        }
        void createTiles()
        {
            for (int rowIndx = 0; rowIndx < boardWidth; rowIndx++)
            {
                List<Tile> row = new List<Tile>();
                for (int colIndx = 0; colIndx < boardHeight; colIndx++)
                {
                    Vector3 pos = new Vector2(leftEdge + colIndx * tileSize, bottomEdge + rowIndx * tileSize);

                    Tile tile = ((GameObject)Instantiate(tilePrefab, pos, Quaternion.identity)).GetComponent<Tile>();
                    tile.boardPos = new Position(rowIndx, colIndx);
                    Rescale(tile.gameObject);

                    row.Add(tile);
                }
                tiles.Add(row);
            }
        }

        private void Rescale(GameObject rescalable)
        {
            float spriteScale = (float)board.boardSprite.texture.width / (float)(rescalable.GetComponent<SpriteRenderer>().sprite.texture.width * boardWidth);

            spriteScale *= rescalable.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit / board.boardSprite.pixelsPerUnit;

            rescalable.transform.localScale = new Vector3(spriteScale, spriteScale, 1);
        }

        private void createPlayers()
        {
            var animals = board.board.GetAnimals();
            foreach (var animal in animals)
            {
                var boardPos = animal.Cell.Position;
                Vector3 animalWorldPos = tiles[boardPos.Row][boardPos.Col].transform.position;
                AnimalPiece animalPiece = ((GameObject)Instantiate(animalPrefabs[(int)animal.AnimalType], animalWorldPos,
                    Quaternion.identity)).GetComponent<AnimalPiece>();

                animalPiece.tile = tiles[boardPos.Row][boardPos.Col];
                Rescale(animalPiece.gameObject);
                tiles[boardPos.Row][boardPos.Col].animalPiece = animalPiece;
                animalPiece.animalLogic = animal;
            }
        }

        public void moveSelectedAnimal(Tile destTile)
        {
            if (ActiveAnimalPiece == null ||
                destTile == ActiveAnimalPiece.tile || 
                !ActiveAnimalPiece.animalLogic.Move(destTile.boardPos)) return;

            if (destTile.animalPiece != null) Destroy(destTile.animalPiece.gameObject, .5f);

            isMoving = true;
            ActiveAnimalPiece.SetupMovement(destTile);
        }

        public void nextTurn()
        {
            isMoving = false;
            ActiveAnimalPiece = null;
        }
    }
}
