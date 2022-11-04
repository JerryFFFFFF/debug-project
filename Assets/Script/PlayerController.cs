using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveForce;

    Vector2 moveDir;
    Rigidbody2D rb;
    Transform childObj;

    float ferryScale = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        childObj= transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDir = new Vector2(h,v).normalized;
        //make the length stay as 1. When it move to the direction aside from x and y make sure it moves all the same distance in different directions. 

        if(h>0)
           childObj.localScale = new Vector3(1,1,1);
        else if(h<0)
        //if h=0 it will run the code on line 29 automatically so have to make sure h doesn't equal to 0
            childObj.localScale = new Vector3(-1,1,1); //axis
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * MoveForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Friends>() != null)
        {
            if(ferryScale > collision.gameObject.GetComponent<Friends>().ferryScale)
            {
                Destroy(collision.gameObject);
                Grow(collision.gameObject.GetComponent<Friends>().ferryScale);
            }
            else
            {
                Die();
            }
        }
    }   
 
    void Grow(float value)
    {
        ferryScale += value / 20f;
        transform.localScale = Vector3.one * ferryScale;

        FindObjectOfType<GameManager>().GainScore((int)(value * 100));
        // Gain Score
    }

    void Die()
    {
        Debug.Log("Die");

        //GameOver
        FindObjectOfType<GameManager>().GameOver();

    }
    
}
