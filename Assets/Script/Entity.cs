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

    public int level = 0;
    public int attack = 1;

    public int exp = 0;
    public int expTillLvlUp = 1;

    public string enemyTag = "Enemy";
    public GameObject explosion;

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

        if(exp > expTillLvlUp)
        {
            LevelUp();
            expTillLvlUp = exp + level;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag(moveTag))
        {
            moving = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(enemyTag))
        {
            col.gameObject.GetComponent<Enemy>().health--;
            if (col.gameObject.GetComponent<Enemy>().health <= 0)
                exp++;
        }
    }

    public void TakeDamage(int damage = 2)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }        
    }

    private void LevelUp()
    {
        level+= 2;
        health += level;
        attack += level;
        this.transform.localScale += Vector3.one;
        moveSpeed = new Vector3(0, 0, moveSpeed.z + level);
    }
}
