using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public AnimalPiece animalPiece;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
