using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject gameOverPanel;
    public bool isGameOver;
    public int score;
    public TextMeshProUGUI scoreText;
    public AudioClip gameOverSound;
    public AudioClip winSound;
    private AudioSource audioSource;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject scorePanel;
    public static GameManager Instance { get {return instance;}}
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        // Actualizar UI
        scorePanel.SetActive(true);
        currentScoreText.text = "Current Score: " + score.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore = score;
        }
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        audioSource.PlayOneShot(gameOverSound);
        gameOverPanel.SetActive(true);
        isGameOver = true;
        FindObjectOfType<AudioManager>().StopBackgroundMusic();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //para reiniciar la escena actual
    }

    public void IncreaseScore()
    {
        audioSource.PlayOneShot(winSound);
        score++;
        scoreText.text = score.ToString();
    }
}
