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
        rb = GetComponent<Rigidbody2D>(); // gör så att GetComponent inte behöver köras varje frame
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); // variabel dirX som tar in ifall Horizontal trycks (a, d, pil höger, pil vänster)
        rb.velocity = new Vector2(dirX * walkingSpeed, rb.velocity.y); // multiplicera dirX med 7f så att vi kan röra oss åt båda håll

        if (Input.GetButtonDown("Jump") && OnGround()) // Om jump knappen (space) trycks och OnGround är "true", kör koden nedan
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);  // rb.velocity.y och rb.velocity.x gör så att det går att hoppa och gå samtidigt
        }

        UpdateAnimationState(); // gör koden mer organiserad
    }

    private void UpdateAnimationState()
    {
        MoveState state;

        if (dirX > 0f) // kollar ifall Player står stilla eller rör på sig för att göra animationer
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

    private bool OnGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); // skapar en box som är lika stor som hitboxen runt spelaren, och kontrollerar ifall Player rör marken
    }
}
