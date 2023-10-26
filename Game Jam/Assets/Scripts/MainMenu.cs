using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startButton; // Reference to your "Start" button
    public Button howToPlayButton;

    private void Start()
    {
        // Attach the button click event to your custom method (e.g., StartGame)
        startButton.onClick.AddListener(StartGame);
        howToPlayButton.onClick.AddListener(HowToPlay);
    }

    // Custom method to switch to the "Map" scene
    private void StartGame()
    {
        SceneManager.LoadScene("Map"); // "Map" should be the name of your scene
    }

    private void HowToPlay()
    {
        SceneManager.LoadScene("How To Play"); // "How To Play" should be the name of your scene
    }
}
