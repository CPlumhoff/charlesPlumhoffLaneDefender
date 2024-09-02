using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public GameObject snail;
    private Rigidbody2D RB2d;
    private float health;
    public GameManager GM;
    public AudioClip Hurt;
    public AudioClip Death;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        RB2d = GetComponent<Rigidbody2D>();
        RB2d.velocity = new Vector2(-1, 0);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        RB2d.velocity = new Vector2(-3, 0);
        if (health <= 0)
        {
            GM.AddScore();
            AudioSource.PlayClipAtPoint(Death, transform.position);
            Destroy(snail);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            AudioSource.PlayClipAtPoint(Hurt, transform.position);
        }

        if (collision.gameObject.tag == "PlayerHurt")
        {
            GM.LoseLife();
            Destroy(snail);
        }

    }
}
