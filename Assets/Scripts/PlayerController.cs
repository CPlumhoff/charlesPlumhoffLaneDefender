using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInputInstance;
    public bool Moving;
    public float MoveDirection;
    public InputAction MoveAction;
    public InputAction RestartAction;
    public InputAction Shoot;
    public InputAction Exit;
    public Rigidbody2D Rb2D;
    public float Speed;
    public GameObject BulletSpawnPoint;
    public bool BulletHasBeenFired;
    public GameObject Projectile;
    public AudioClip PlayerShoot;
    private bool Shooting;
    public AudioClip LoseLife;
    public GameManager GM;
    



    void Start()
    {
        PlayerInputInstance = GetComponent<PlayerInput>();
        Rb2D = GetComponent<Rigidbody2D>();
        PlayerInputInstance.currentActionMap.Enable();

        Shoot = PlayerInputInstance.currentActionMap.FindAction("Shoot");
        MoveAction = PlayerInputInstance.currentActionMap.FindAction("Move");
        RestartAction = PlayerInputInstance.currentActionMap.FindAction("Restart");
        Exit = PlayerInputInstance.currentActionMap.FindAction("Exit");

        Shoot.started += Shoot_started;
        MoveAction.started += MoveAction_started;
        MoveAction.canceled += MoveAction_canceled;
        RestartAction.started += RestartAction_started;
        Exit.started += Exit_started;

        GM = FindObjectOfType<GameManager>();
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        Instantiate(this.Projectile, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
        AudioSource.PlayClipAtPoint(PlayerShoot, transform.position);
        //bullet.Project(ShootPoint.transform.up);
    }

    private void Exit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }



    private void RestartAction_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }




    private void MoveAction_canceled(InputAction.CallbackContext obj)
    {
        Moving = false;
    }



    private void MoveAction_started(InputAction.CallbackContext obj)
    {
        Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == true)
        {
            MoveDirection = MoveAction.ReadValue<float>();
            Rb2D.velocity = new Vector2(0, MoveDirection * Speed);
        }
        else
        {
            Rb2D.velocity = new Vector2(0, 0);
        }

        if (Shooting == true)
        {
            Instantiate(this.Projectile, BulletSpawnPoint.transform.position, BulletSpawnPoint.transform.rotation);
            AudioSource.PlayClipAtPoint(PlayerShoot, transform.position);
        }
        //if (BallHasBeenFired == false)
       // {
       //     Ball.gameObject.transform.position = BallSpawnPoint.position;
       // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GM.LoseLife();


        }

    }


}
