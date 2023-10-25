using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score;
    public bool isGrounded = true;
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    public ParticleSystem jumpEffect;
    Monster monster;
    public GameObject monsterScale;
    Spawner spawner;

    
    private Animator animator;

    



    private float horizontalInput;
    private bool isFacingRight = true;

    Rigidbody2D rb;
    void Start()
    {
        score = 0;
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        monster = GameObject.Find("Monster Parent").GetComponent<Monster>();
        

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        PlayerMove();
        FlipFace();
        Jump();
        
        if (transform.position.y <= monsterScale.transform.position.y - 15f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            UpdateScore();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            
            
        }
    }
    void FlipFace()
    {
        if (isFacingRight && horizontalInput <0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpEffect.Play();
            isGrounded = false;
            animator.SetTrigger("Jump");
        }
    }
    void PlayerMove()
    {
        transform.Translate(new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0));
        if (horizontalInput != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score.ToString();
        if (score==5)
        {
            spawner.x = 1;
            spawner.spawnX = 5f;
            
        }
        if (score == 15)
        {
            spawner.x = 2;
            spawner.spawnX = 4f;
        }
        if (score > 20)
        {
            monster.moveSpeed += .1f;
        }
    }
    

}
