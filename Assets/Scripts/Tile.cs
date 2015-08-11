using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Animal animal;

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
            if (GameManager.instance.activeAnimal != null)
            {
                GameManager.instance.moveSelectedAnimal(this);
            }
            else if(animal != null)
            {
                GameManager.instance.activeAnimal = animal;
            }
        }
    }
}
