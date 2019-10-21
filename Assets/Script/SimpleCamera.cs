using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Vector2 movement;
    private Vector2 mousePos = Vector2.zero;
    public float speed = 10.0f;
    public float screenEdgeDistance = 5f;
    public Rigidbody rb;

    private void Update()
    {
        mousePos = Input.mousePosition;


        if (mousePos.x > (Screen.width - screenEdgeDistance))
            movement.x = 1;
        else if (mousePos.x < screenEdgeDistance)
            movement.x = -1;
        else
            movement.x = 0;



        if (mousePos.y > (Screen.height - screenEdgeDistance))
            movement.y = 1;
        else if (mousePos.y < screenEdgeDistance)
            movement.y = -1;
        else
            movement.y = 0;


        rb.velocity = new Vector3(movement.x * speed, 0, movement.y * speed);
    }
}
