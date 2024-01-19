using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    

    private int melons = 0;

    [SerializeField] private Text melonsText;

    [SerializeField] private AudioSource collectSoundEffect;

    // infoga jumpHeight
    public PlayerMovement playerMovement;
    void Start()
    {
        // Tilldela referensen till PlayerMovement-skriptet
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        float playerJumpHeight = playerMovement.jumpHeight;
    }
    // jumpHeight slut

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Melon"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            melons++;
            melonsText.text = "Melons: " + melons;
        }

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            playerMovement.jumpHeight = playerMovement.jumpHeight * 1.3f;
            GetComponent <SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetKiwi());
        }
    }

    private IEnumerator ResetKiwi()
    {
        yield return new WaitForSeconds(5);
        playerMovement.jumpHeight = 13f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
