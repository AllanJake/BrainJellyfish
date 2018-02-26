using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public GameObject menu;
    public GameObject controls;

    bool isControls = false;

    private void startButton()
    {
        // Start the game
        SceneManager.LoadScene("Prototype");
    }

    private void controlsButton()
    {
        isControls = !isControls;
        if (isControls)
        {
            // Show Controls
            // First hide the buttons and text
            menu.SetActive(false);
            // Show the controls screen text
            controls.SetActive(true);
        }
        else
        {
            menu.SetActive(true);
            controls.SetActive(false);
        }
    }
}
