using UnityEngine;

namespace AnimalChess
{
    public class AnimalPiece : MonoBehaviour
    {
        public float moveSpeed = 1.0f;
        public float startTime;
        public float journeyLength;

        public Vector3 startPos;
        public Vector3 endPos;

        public Tile tile;

        public void Move()
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney);

            if (endPos == transform.position)
            {            
                GameManager.instance.nextTurn();
            }
        }

        public void SetupMovement(Tile destTile)
        {
            startPos = transform.position;
            endPos = destTile.transform.position;
            journeyLength = Vector3.Distance(startPos, endPos);
            startTime = Time.time;
            destTile.animalPiece = this;
            tile = destTile;
        }
    }
}
