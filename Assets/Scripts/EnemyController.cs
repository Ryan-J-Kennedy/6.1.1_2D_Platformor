using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    private float speed = 2f;
    private float direction = 1f;
    CharacterController CC;
    //GameObject AttackArea;

    // Start is called before the first frame update
    void Start()
    {
        CC = Player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y < this.transform.position.y + 1f && Player.transform.position.y > this.transform.position.y - 1f)
        {
            if(Player.transform.position.x < this.transform.position.x)
            {
                direction = -1f;
            }
            else
            {
                direction = 1f;
            }

            transform.position = new Vector3((Time.deltaTime * speed * direction) + transform.position.x, transform.position.y, Player.transform.position.z);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "character")
        {
            if (CC.HP > 0)
            {
                CC.TakeDamage();
            }
            else
            {
                Destroy(coll.gameObject);
            }
        }
    }
}
