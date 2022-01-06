using UnityEngine;
using GameManagement;
using BetterDebug;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator ballAnim;
    [SerializeField] private Animator playerAnim;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundDetectionPoint;

    [Header("Instantiation Positions")]
    [SerializeField] private Transform bombPoint;
    [SerializeField] private Transform shotPoint;

    [Header("Physics")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Prefabs")]
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject bomb;
    [SerializeField] private BulletController bullet;
    [SerializeField] private GameObject standing;

    [Header("Rendering")]
    [SerializeField] private SpriteRenderer afterImage;
    [SerializeField] private Color afterImageColor;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Settings")]
    [SerializeField] private float afterImageLifetime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBetweenAfterImages;
    [SerializeField] private float waitAfterDashing;
    [SerializeField] private float waitToBall;

    public void PlayerMove(Vector2 inputVector)
    {
        Vector3 movementVector = new Vector3(inputVector.x, 0f, 0f) * moveSpeed;
        rb.velocity = movementVector;
        playerAnim.SetFloat("speed", Math.Abs(movementVector.x));
        UpdateCharacterDirection();
    }

    public void PlayerJump(Vector2 movementVector)
    {
        if(IsOnGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, movementVector.y, 0F);
        }
    }

    private bool IsOnGround()
    {
        return Physics2D.OverlapCircle(groundDetectionPoint.position, .2f, groundLayer);
    }

    private void UpdateCharacterDirection()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    /*void Update()
    {
        if (canMove && Time.timeScale != 0)
        {
            if (dashRechargeCounter > 0)
            {
                dashRechargeCounter -= Time.deltaTime;
            }
            else
            {

                if (/*INPUT && standing.activeSelf && PlayerAbilityTracker.CanDash())
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

                //move sideways
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
                }
            }

            //checking if on the ground

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
    }*/
}
