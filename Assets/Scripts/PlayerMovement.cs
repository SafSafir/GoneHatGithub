using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   // variables
    #region 
    Rigidbody2D phy;
    Animator anim;
    SpriteRenderer rd;

    public GameObject healthBar;
    public Texture2D[] healthBarImage;

    public GameObject jumpBar;
    public Texture2D[] jumpBarImage;

    public GameObject RebornButton;
    public GameObject RestartButton;
    public GameObject hat;


    public int healthCounter = 3;

    private bool isOnTheRightWall;
    private bool isOnTheLeftWall;
    private bool isGrounded;

    private bool hasAnUmb = true;
    private int extraJumps = 5;
    private int usableJump = 2;
    private bool isInStart = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float y = -20;

    [SerializeField] float _jumpSpeedX = 5;
    [SerializeField] float _jumpSpeedY = 5;

    #endregion
    




    private void Awake()
    {
        anim = GetComponent<Animator>();
        phy = GetComponent<Rigidbody2D>();
        rd = GetComponent<SpriteRenderer>();

        phy.gravityScale = 1.5f;
    }

    void Start()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        StartCoroutine(ExampleCoroutine());
    }

    void Update()
    {
        if (!isInStart) 
        { 
        Jump();
        FindHighestY();
        AnimationControl();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //player io on the right wall
        if (collision.gameObject.tag == "rightWall")
        {
            anim.SetBool("isonTheWall", true);
            anim.SetBool("isJumping", false);
            rd.flipX = true;
            phy.gravityScale = 0.5f;
            isOnTheRightWall = true;
            isOnTheLeftWall = false;
            if (hasAnUmb)
            {
                usableJump = 2;
            }
            else if (hasAnUmb == false)
            {
                usableJump = 1;
            }
        }

        //player is on the left wall
        if (collision.gameObject.tag == "leftWall")
        {
            anim.SetBool("isonTheWall", true);
            anim.SetBool("isJumping", false);
            
            rd.flipX = false;
            phy.gravityScale = 0.5f;
            isOnTheRightWall = false;
            isOnTheLeftWall = true;
            if (hasAnUmb)
            {
                usableJump = 2;
            }
            else if (hasAnUmb == false)
            {
                usableJump = 1;
            }
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rightWall"|| collision.gameObject.tag == "leftWall")
        {
            phy.gravityScale = 1.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player is taking umbrella
        if (collision.gameObject.tag == "umbrella")
        {
            hasAnUmb = true;
            extraJumps = 5;
            jumpBar.GetComponent<RawImage>().texture = jumpBarImage[extraJumps];
            Destroy(collision.gameObject);
            
        }
        //player is hitting bird
        if (collision.gameObject.tag == "bird")
        {
         
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            healthBar.GetComponent<RawImage>().texture = healthBarImage[--healthCounter];
            
            //death control
            if (healthBar.GetComponent<RawImage>().texture == healthBarImage[0])
            {
                Time.timeScale = 0;
                RebornButton.SetActive(true);
                RestartButton.SetActive(true);
            }
            
            
            
        }
        //player is hitting balloon
        if (collision.gameObject.tag == "balloon")
        {

            Destroy(collision.gameObject);
            healthBar.GetComponent<RawImage>().texture = healthBarImage[--healthCounter];
            //death control
            if (healthBar.GetComponent<RawImage>().texture == healthBarImage[0])
            {
                Time.timeScale = 0;
                RebornButton.SetActive(true);
                RestartButton.SetActive(true);

            }

        }
        //player is hitting antenna
        if(collision.gameObject.tag == "antenna")
        {
          
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            healthBar.GetComponent<RawImage>().texture = healthBarImage[--healthCounter];
            //death control
            if (healthBar.GetComponent<RawImage>().texture == healthBarImage[0])
            {
                Time.timeScale = 0;
                RebornButton.SetActive(true);
                RestartButton.SetActive(true);

            }
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            
        }
    }

   
   
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
           
            


            anim.SetBool("isJumping", true);
            phy.velocity = new Vector2(_jumpSpeedX, _jumpSpeedY);
            isGrounded = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnTheRightWall && usableJump > 0)
            {
                anim.SetBool("isJumping", true);
                phy.velocity = new Vector2(-_jumpSpeedX, _jumpSpeedY);
                usableJump--;
                if (hasAnUmb && usableJump == 0)
                {

                    extraJumps--;
                    jumpBar.GetComponent<RawImage>().texture = jumpBarImage[extraJumps];
                    if (extraJumps == 0)
                    {
                        hasAnUmb = false;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && isOnTheLeftWall && usableJump > 0)
            {
                anim.SetBool("isJumping", true);
                phy.velocity = new Vector2(_jumpSpeedX, _jumpSpeedY);
                usableJump--;
                
                if (hasAnUmb && usableJump == 0)
                {
                    extraJumps--;
                    jumpBar.GetComponent<RawImage>().texture = jumpBarImage[extraJumps];
                    if (extraJumps == 0)
                    {
                        hasAnUmb = false;
                    }
                }
            }

        }

    }
    void FindHighestY()
    {
        //control for highest y position
        if (transform.position.y > y)
        {
            y = transform.position.y;
        }
    }

    void AnimationControl()
    {
        //controls for runing jump animation with or without an umbrella
        if (hasAnUmb)
            anim.SetBool("hasUmbrella", true);
        if (!hasAnUmb)
            anim.SetBool("hasUmbrella", false);
    }

    IEnumerator ExampleCoroutine()
    {
        isInStart = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        isInStart = false;
        Destroy(hat);

    }

}
