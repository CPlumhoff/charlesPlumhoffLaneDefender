using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D RB2d;
    public PlayerController PlayerC;
    public GameManager GameM;



    private void Start()
    {
        RB2d = GetComponent<Rigidbody2D>();
        RB2d.velocity = new Vector2(10, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "PlayerHurt")
        {
            Destroy(this.gameObject);
            //   GameM.LoseLife();
            //  if (GameM.Lives == 0)
            //  {
            //      gameObject.SetActive(false);
            //  }
            //  else
            //  {
            //       RB2d.velocity = Vector2.zero;
            //      PlayerC.BallHasBeenFired = false;
            // }


        }

    }
}


   

