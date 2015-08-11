using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour
{
    public Sprite boardSprite;

    // Use this for initialization
    void Start()
    {
        boardSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
