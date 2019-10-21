using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool selected = false;
    public int health = 10;

    public bool moving = false;
    public Rigidbody rb;
    public Vector3 moveSpeed = new Vector3(0,0,10);
    private Vector3 target;

    public string moveTag = "MoveCol";



    public void MoveTo(Vector3 targetPos)
    {
        target = targetPos;
        moving = true;
    }




    private void Update()
    {
        if (moving)
        {
            
            rb.velocity = transform.TransformDirection(moveSpeed);
            transform.LookAt(target);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }




    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(moveTag))
        {
            moving = false;
        }
    }
}
