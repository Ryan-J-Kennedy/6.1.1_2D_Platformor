using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rBody;
    private bool airborne = false;
    public float thrust;
    public float maxVelocity;
    private int direction = 0;
    public int HP = 10;
    public Text win;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage()
    {
        HP--;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {

            rBody = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rBody.velocity.x) < maxVelocity)
            {
                rBody.AddForce(transform.right * thrust);
            }

            if (direction == 1)
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = false;
            }
            direction = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rBody = GetComponent<Rigidbody2D>();
            if (Mathf.Abs(rBody.velocity.x) < maxVelocity)
            {
                rBody.AddForce(transform.right * -thrust);
            }

            if (direction == 0)
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                sr.flipX = true;
            }
            direction = 1;

        }
        if (Input.GetKey(KeyCode.W))
        {
            rBody = GetComponent<Rigidbody2D>();
            if (!airborne && Mathf.Abs(rBody.velocity.y) < maxVelocity)
            {
                rBody.AddForce(transform.up * thrust * 30f);
                airborne = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform")
        {
            airborne = false;
        }
        else if(coll.gameObject.tag == "win")
        {
            win.text = "YOU WIN!";
        }
    }
}
