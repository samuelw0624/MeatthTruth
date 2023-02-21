using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerStart : MonoBehaviour
{
    Button button;
    ClickerManager cManagerScript;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        cManagerScript = GameObject.Find("Clicker Manager").GetComponent<ClickerManager>();

        //button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        //cManagerScript.StartGame(difficulty);
    }
}
