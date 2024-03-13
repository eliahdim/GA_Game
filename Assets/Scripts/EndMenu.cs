using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit(); // calls function Quit when Escape is pressed 
        }
    }
    public void Quit()
    {
        Application.Quit(); // quits game
    }
}
