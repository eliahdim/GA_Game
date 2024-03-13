using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) // if Player collides with trap, execute Die()
        {
            rb = GetComponent<Rigidbody2D>();
            Die(); 
        }
    }

    private void Die() // plays a sound effect, makes bodytype static and plays death animation
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel() // restarts level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
