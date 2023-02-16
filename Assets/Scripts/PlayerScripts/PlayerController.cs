using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float move_Speed = 5f;
    public float moveSpeed = 5f; 
    private int scoreNumber = 1;
    private bool moveLeft, moveRight;


    private Rigidbody2D rb;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextt;


    public AudioSource LandAudio;
    public AudioClip AudiForDeath;
    public AudioClip AudiForBreak;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
        Score();
        moveLeft = false;
        moveRight = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (moveRight == true)
        {
            rb.velocity = new Vector2(move_Speed , rb.velocity.y);
        }

        if (moveLeft == true)
        {

        rb.velocity = new Vector2(-move_Speed, rb.velocity.y);
        }
    }
    private void Move()
    {
        if(CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector2(move_Speed , rb.velocity.y);
        }
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector2(-move_Speed, rb.velocity.y);
        }

    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void StopMoving()
    {
        moveRight = false;
        moveLeft = false;
        rb.velocity = Vector2.zero;
    }

    private void Score()
    {
        scoreNumber = 0;
        scoreText.text = "Score: " + scoreNumber;
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Spike") || target.transform.CompareTag("EnemySpike"))
        {
            AudioSource.PlayClipAtPoint(AudiForDeath, Camera.main.transform.position);
            StartCoroutine(WaitForReload());
        }
    }



   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("BreakablePlatform"))
        {
            StartCoroutine(BreakPlatform(collision.gameObject));
        }

        if (collision.transform.CompareTag("DeathZone"))
        {
            AudioSource.PlayClipAtPoint(AudiForDeath, Camera.main.transform.position);
            StartCoroutine(WaitForReload());
        }

        // For Score To add

        if (collision.transform.CompareTag("BreakablePlatform") 
            || collision.transform.CompareTag("Platform")
            || collision.transform.CompareTag("MovingPlatformLeft")
            || collision.transform.CompareTag("MovingPlatformRight"))
        {
            scoreNumber++;
            scoreText.text = "Score: " + scoreNumber; 
            scoreTextt.text = "Score: " + scoreNumber;
            PlayerPrefs.SetString("currentScore", scoreText.text);
            LandAudio.Play();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("MovingPlatformLeft"))
        {
            rb.velocity = new Vector2(-1f, rb.velocity.y);
        }

        else if (collision.transform.CompareTag("MovingPlatformRight"))
        {
            rb.velocity = new Vector2(1f, rb.velocity.y);
        }
    }




    // IEnumerator
    IEnumerator BreakPlatform(GameObject platform)
    {
        yield return new WaitForSeconds(1f);
        AudioSource.PlayClipAtPoint(AudiForBreak, Camera.main.transform.position);
        Destroy(platform);
    }

    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.RestartGame();
    }


}
