using UnityEngine;
using GameManagement;
using BetterDebug;
using System;

public class PlayerController : MonoBehaviour
{
    #region serialized_fields

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

    #endregion serialized_fields

    private void Awake()
    {
        rb.velocity = Vector3.zero * 0;
    }

    private void Update()
    {
        //Do stuff here...
    }

    #region public_C#_Events

    public void MovementAxis(Vector2 inputVector)
    {
        float horizontal = inputVector.x;
        float verticalInput = inputVector.y;

        #region temp
        /*
        if(IsOnGround())
        {
            playerAnim.SetFloat("speed", Math.Abs(movementVector.x));
        }

        UpdateCharacterDirection();
        */
        #endregion temp
    }

    public void JumpButton()
    {
        if(IsOnGround())
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    #endregion public_C#_Events

    #region helper_Methods

    private bool IsOnGround() { return Physics2D.OverlapCircle(groundDetectionPoint.position, .2f, groundLayer); }

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

    #endregion helper_Methods
}