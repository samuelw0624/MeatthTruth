using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject rewardText;
    public Button restartButton;

    //public Button restartButtom;
    public GameObject titleScreen;

    int score;
    public bool isGameAvtive;
    float spawnRate = 1.0f;

    public void StartGame()
    {
        isGameAvtive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        //deactivates the title screen when the game starts
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameAvtive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void ScoreCount(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameAvtive = false;
        if (score > 150)
        {
            scoreText.gameObject.SetActive(false);
            rewardText.gameObject.SetActive(true);
        }else
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            //restartButtom.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Phone Game");
    }
}
