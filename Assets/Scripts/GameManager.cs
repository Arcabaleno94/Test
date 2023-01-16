using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isDead = false;
    public GameObject Generator;

    public byte score = 0;
    public byte highScore = 0;

    public bool gameHasStarted = false;

    [SerializeField] TextMeshProUGUI scoreText, gameOverScoreText, gameOverHiscoreText;

    [SerializeField] GameObject gameOverScreen;


    void Start()
    {
        StartCoroutine(AddScore());
    }

    void Update()
    {
        if (isDead)
        {
            Debug.Log($"Game over");
            GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
            GameObject pipesGenerator = GameObject.FindGameObjectWithTag("PipeGenerator");

            Generator.SetActive(false);

            for (int i = 0; i < pipes.Length; i++)
            {
                pipes[i].GetComponent<Pipe>().canMove = false;
            }

            gameOverScreen.SetActive(true);

            gameOverScoreText.text = score.ToString();

            enabled = false;
        }

    }

    IEnumerator AddScore()
    {
        yield return new WaitForSecondsRealtime(1);

        if (!isDead)
        {
            if (gameHasStarted)
            {
                score++;

                if (score < 10)
                    scoreText.text = "00" + score.ToString();
                else if (score < 100)
                    scoreText.text = "0" + score.ToString();
                else
                    scoreText.text = score.ToString();
            }
            StartCoroutine(AddScore());
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}   
