using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Bird birdPlayer;
    public Text scoreText;
    public GameObject playButton;
    public GameObject instructionButton;
    public GameObject instructionsPanel;
    public GameObject gameOver;
    public GameObject restartText;
    private int score;
    private bool isGameOver = false;


    private void Awake()
    {
        playButton.SetActive(true);
        instructionButton.SetActive(true);
        gameOver.SetActive(false);
        restartText.SetActive(false);
        instructionsPanel.SetActive(false);
        Pause();
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Play();
            isGameOver = false;
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        instructionButton.SetActive(false);
        gameOver.SetActive(false);
        restartText.SetActive(false);
        instructionButton.SetActive(false);

        Time.timeScale = 1f;
        birdPlayer.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (Pipes pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        birdPlayer.enabled = false;
    }




    public void GameOver()
    {
        gameOver.SetActive(true);
        restartText.SetActive(true);
        playButton.SetActive(true);
        isGameOver = true;

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score % 10 == 0) // every 10 points
        {
        birdPlayer.RainbowEffect(2f); // rainbow for 2 seconds
        }
    }

    // Open the instructions panel
    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    // Close the instructions panel
    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
