using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayerDied()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
        gameOverText.text = "Game Over\nPress R to Restart";
    }

    public void PlayerWon()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
        gameOverText.text = "You Win!\nPress R to Restart";
    }
}