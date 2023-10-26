using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include the UnityEngine.UI namespace

public class LevelManager : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public int startingLives = 20;
    public int currentLives;
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    [SerializeField] private Button restartButton;

    public GameObject GameOverOverlay;

    void Start()
    {
        currentLives = startingLives;
        restartButton.onClick.AddListener(Restart);
        GameOverOverlay.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if (LevelManager.main.currentLives <= 0)
        {
            GameOver();
            return;
        }
    }

    private void GameOver()
    {
        GameOverOverlay.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    private void Restart()
    {
        // Get the current scene's name
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // Include UnityEngine in SceneManager
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // Include UnityEngine in SceneManager
    }
}
