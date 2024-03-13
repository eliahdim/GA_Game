using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishSoundEffect;

    private bool levelCompleted = false;
    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted) // when player collides with finish flag, play sound and load next level
        {
            finishSoundEffect.Play();
            levelCompleted = true; 
            Invoke("CompleteLevel", 3f);
        }
    }

    private void CompleteLevel() // loads next level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
