using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    

    private int melons = 0;

    [SerializeField] private Text melonsText;

    [SerializeField] private AudioSource collectSoundEffect;

   
    public PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        float playerJumpHeight = playerMovement.jumpHeight;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Melon")) // when Player touches Melon, execute the following
        {
            collectSoundEffect.Play(); // play sound effect
            Destroy(collision.gameObject); // destroy Melon object
            melons++; // add 1 to melon counter
            melonsText.text = "Melons: " + melons; // text UI displaying amount of melons collected
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
