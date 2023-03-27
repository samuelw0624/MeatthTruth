using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    //public Button restartButtom;
    public GameObject titleScreen;

    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public GameObject rewardText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    int score;
    public int life;
    public bool isGameAvtive;
    float spawnRate = 1.5f;

    public void StartGame()
    {
        //game initialization
        isGameAvtive = true;
        score = 0;
        //life = 3;
        lifeText.text = "Lives Remaining: " + life;
        StartCoroutine(SpawnTarget());
        //deactivates the title screen when the game starts
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameAvtive)
        {
            yield return new WaitForSeconds(spawnRate/((score/100)+1));
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void ScoreCount(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void DeductLife()
    {
        life -= 1;
        lifeText.text = "Lives Remaining: " + life;
    }

    public void GameOver()
    {
        isGameAvtive = false;
        if (score > 250)
        {
            scoreText.gameObject.SetActive(false);
            rewardText.gameObject.SetActive(true);
        }else
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Book Game");
    }
}
