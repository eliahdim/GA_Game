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


        // Kiwi item below not yet accesible in base game, might add later, only code for now

        if (collision.gameObject.CompareTag("Kiwi")) // when Player touches Kiwi, execute the following
        {
            collectSoundEffect.Play(); // play sound effect
            Destroy(collision.gameObject); // destroy Melon object
            playerMovement.jumpHeight = playerMovement.jumpHeight * 1.3f; // make Player jump higher
            GetComponent <SpriteRenderer>().color = Color.green; // make Player green
            StartCoroutine(ResetKiwi()); // start function ResetKiwi, a countdown
        }
    }

    private IEnumerator ResetKiwi()
    {
        yield return new WaitForSeconds(5); // wait 5 seconds
        playerMovement.jumpHeight = 13f; // reset jumpHeight to normal
        GetComponent<SpriteRenderer>().color = Color.white; // reset Player color
    }
}
