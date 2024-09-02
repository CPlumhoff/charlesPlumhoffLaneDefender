using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slime : MonoBehaviour
{
    public GameObject slime;
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
        RB2d.velocity = new Vector2(-2, 0);
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        RB2d.velocity = new Vector2(-3, 0);
        if (health <= 0)
        {
            GM.AddScore();
            AudioSource.PlayClipAtPoint(Death, transform.position);
            Destroy(slime);
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
            Destroy(slime);
        }

    }
}
