using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //The player's score
    public static int score;

    public Text text;

    private void Awake()
    {
        text = GetComponent<Text>();

        //Reset the score
        score = 0;
        Debug.Log("Start Game");
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }
}
