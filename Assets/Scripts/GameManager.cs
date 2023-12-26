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
    public static GameManager Instance { get {return instance;}}
    // Start is called before the first frame update
    void Awake()
    {
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
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //para reiniciar la escena actual
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
