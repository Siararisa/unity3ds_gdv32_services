using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    public float moveSpeed = 2.0f;
    [SerializeField]
    private float jumpForce = 250f;
    
    [Header("Ground")]
    [SerializeField]
    //Where is the feet of our player?
    private Transform groundPoint;
    [SerializeField]
    //How big is the radius of our ground checker?
    private float groundRadius = 0.2f;
    [SerializeField]
    //What objects are considered as ground?
    private LayerMask groundLayers;

    private Rigidbody2D playerRigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //private AudioSource source;

    private float horizontalInput;
    private bool facingRight = true;
    private bool isJump = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //source = GetComponent<AudioSource>();

        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //Get the movement input from the user
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalInput));
        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //source.volume = 0.25f;
            //source.Play();
            AudioManager.Instance.PlaySound("Jump", 0.25f);
            isJump = true;
        }
           
    }

    private void FixedUpdate()
    {
        //move the player based on the physics update
        float horizontalMovement = horizontalInput * moveSpeed;
        playerRigidBody.velocity = new Vector2(horizontalMovement, playerRigidBody.velocity.y);

        Debug.Log(IsGrounded());

        if (isJump && IsGrounded())
        {
            playerRigidBody.AddForce(new Vector2(0, jumpForce));
            isJump = false;
        }
    }

    
  
    private void Flip(float movement)
    {
        //if we have positive input and not facing right (facing left)
        // OR
        //if we have negative input and we are facing right
        if(movement > 0 && !facingRight || movement < 0 && facingRight)
        {
            //toggle the boolean
            facingRight = !facingRight;
            spriteRenderer.flipX = !facingRight;
        }
    }

    /// <summary>
    /// This function will return true if our feet is touching the ground and false if not
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPoint.position, groundRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)//make sure that the gameobject we are colliding is not our own
                return true;
        }
        return false;
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(SpeedIncrease());
    }

    IEnumerator SpeedIncrease()
    {
        moveSpeed = 5.0f;
        yield return new WaitForSeconds(5.0f);
        moveSpeed = 2.5f;
    }
}
