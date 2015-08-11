using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour
{
    public Vector3 moveDestination;
    public float moveSpeed = 10.0f;

    public Tile tile;

    void Awake()
    {
        moveDestination = transform.position;
    }

    public void TurnUpdate()
    {
        if (Vector3.Distance(moveDestination, transform.position) > 0.1f)
        {
            transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime; //TODO may cause overrun

            if (Vector3.Distance(moveDestination, transform.position) <= 0.1f)
            {
                transform.position = moveDestination;
                GameManager.instance.nextTurn();
            }
        }
    }
}
