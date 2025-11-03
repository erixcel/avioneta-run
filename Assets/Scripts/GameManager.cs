using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text scoreText;
    private int score;
    private bool isGameOver;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (isGameOver && Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void StopGame()
    { 
        isGameOver = true;
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();

        foreach (Scroll scroll in scrollingObjects)
        {
            scroll.StopScroll();
        }

        Spawner spawner = FindObjectOfType<Spawner>();
        spawner.StopSpawn();

        gameOverPanel.SetActive(true);
    }
}