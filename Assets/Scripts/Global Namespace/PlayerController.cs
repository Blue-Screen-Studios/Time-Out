using UnityEngine;
using GameManagement;
using BetterDebug;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool isOnGround;
    public LayerMask whatIsGround;

    public Animator anim;

    public BulletController shotToFire;
    public Transform shotPoint;

    private bool canDoubleJump;

    public float dashSpeed, dashTime;
    private float dashCounter;

    public SpriteRenderer theSR, afterImage;
    public float afterImageLifetime, timeBetweenAfterImages;
    private float afterImageCounter;
    public Color afterImageColor;

    public float waitAfterDashing;
    private float dashRechargeCounter;

    public GameObject standing, ball;
    public float waitToBall;
    private float ballCounter;
    public Animator ballAnim;

    public Transform bombPoint;
    public GameObject bomb;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Time.timeScale != 0)
        {
            if (dashRechargeCounter > 0)
            {
                dashRechargeCounter -= Time.deltaTime;
            }
            else
            {

                if (/*INPUT && */ standing.activeSelf && PlayerAbilityTracker.CanDash())
                {
                    dashCounter = dashTime;

                    ShowAfterImage();

                    AudioManager.instance.PlaySFXAdjusted(7);
                }
            }

            if (dashCounter > 0)
            {
                dashCounter = dashCounter - Time.deltaTime;

                //rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);

                afterImageCounter -= Time.deltaTime;
                if (afterImageCounter <= 0)
                {
                    ShowAfterImage();
                }

                dashRechargeCounter = waitAfterDashing;
            }
            else
            {

                /*//move sideways
                if(activeInputTrigger == InputTrigger.Left)
                {
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                }
                
                if(activeInputTrigger == InputTrigger.Right)
                {
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                }

                //handle direction change
                if (rb.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (rb.velocity.x > 0)
                {
                    transform.localScale = Vector3.one;
                }*/
            }

            //checking if on the ground
            isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);

            //jumping
            if (Input.GetButtonDown("Jump") && (isOnGround || (canDoubleJump && PlayerAbilityTracker.CanDoubleJump())))
            {
                if (isOnGround)
                {
                    canDoubleJump = true;

                    AudioManager.instance.PlaySFXAdjusted(12);
                }
                else
                {
                    canDoubleJump = false;

                    anim.SetTrigger("doubleJump");

                    AudioManager.instance.PlaySFXAdjusted(9);
                }

                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            //shooting
            if (Input.GetButtonDown("Fire1"))
            {
                if (standing.activeSelf)
                {
                    Instantiate(shotToFire, shotPoint.position, shotPoint.rotation).moveDir = new Vector2(transform.localScale.x, 0f);

                    anim.SetTrigger("shotFired");

                    AudioManager.instance.PlaySFXAdjusted(14);
                }
                else if (ball.activeSelf && PlayerAbilityTracker.CanDropBomb())
                {
                    Instantiate(bomb, bombPoint.position, bombPoint.rotation);

                    AudioManager.instance.PlaySFXAdjusted(13);

                }
            }

            //ball mode
            if (!ball.activeSelf)
            {
                if (Input.GetAxisRaw("Vertical") < -.9f && PlayerAbilityTracker.CanBecomeDrone())
                {
                    ballCounter -= Time.deltaTime;
                    if (ballCounter <= 0)
                    {
                        ball.SetActive(true);
                        standing.SetActive(false);

                        AudioManager.instance.PlaySFX(6);
                    }

                }
                else
                {
                    ballCounter = waitToBall;
                }
            }
            else
            {
                if (Input.GetAxisRaw("Vertical") > .9f)
                {
                    ballCounter -= Time.deltaTime;
                    if (ballCounter <= 0)
                    {
                        ball.SetActive(false);
                        standing.SetActive(true);

                        AudioManager.instance.PlaySFX(10);
                    }

                }
                else
                {
                    ballCounter = waitToBall;
                }
            }
        } else
        {
            rb.velocity = Vector2.zero;
        }


        if (standing.activeSelf)
        {
            anim.SetBool("isOnGround", isOnGround);
            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }

        if(ball.activeSelf)
        {
            ballAnim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }
    }

    public void ShowAfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
        image.sprite = theSR.sprite;
        image.transform.localScale = transform.localScale;
        image.color = afterImageColor;

        Destroy(image.gameObject, afterImageLifetime);

        afterImageCounter = timeBetweenAfterImages;
    }
}
