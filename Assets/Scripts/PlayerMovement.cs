using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float walkingSpeed = 7f;
    [SerializeField] public float jumpHeight = 13f;

    private enum MoveState { idle, walking, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // imports horizontal move controls
        rb.velocity = new Vector2(dirX * walkingSpeed, rb.velocity.y); // allows Player to walk in both directions

        if (Input.GetButtonDown("Jump") && OnGround()) // checks if space is pressed and OnGround is "true"
        {
            jumpSoundEffect.Play(); // play sound effect
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);  // jump
        }

        UpdateAnimationState(); // gör koden mer organiserad
    }

    private void UpdateAnimationState()
    {
        MoveState state;

        if (dirX > 0f) // checks if Player is idle or moving to execute different animations
        {
            state = MoveState.walking;
            sprite.flipX = true;
        }
        else if (dirX < 0f)
        {
            state = MoveState.walking;
            sprite.flipX = false;
        }
        else
        {
            state = MoveState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MoveState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MoveState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head")) // game logic for Rhino, if Player jumps on Rhino head then jump again, play sound effect and destroy Rhino object
        {
            Destroy(collision.transform.parent.gameObject);
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private bool OnGround() // function to check if Player is on the ground
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // creates a box with the same size as Player and checks if Player touches ground
    }
}
