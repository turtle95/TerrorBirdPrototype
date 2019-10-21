using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string playerTag = "Bird";
    public int health = 1;
    public GameObject explosion;

    public Transform target;
    public string treeTag = "Tree";

    public Rigidbody rb;
    public Vector3 speed = new Vector3(0,0,10);

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            col.gameObject.GetComponent<Entity>()?.TakeDamage();
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        transform.LookAt(target);
        rb.velocity = transform.TransformDirection(speed);
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(treeTag))
        {
            Instantiate(explosion, target.position, transform.rotation);
            Destroy(col.gameObject);
        }
    }
}
