using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int score;
    public int displayScore;
    public Text scoreUI;

    void Start()
    {
        //Both scores start at 0
        score = 0;
        displayScore = 0;
        scoreUI = GetComponent<Text>();
        StartCoroutine(ScoreUpdater());

    }

    private IEnumerator ScoreUpdater()
    {
        while (true)
        {
            if (displayScore < score)
            {
                displayScore++; //Increment the display score by 1
                scoreUI.text = displayScore.ToString(); //Write it to the UI
            }
            yield return new WaitForSeconds(0.1f); // I used .2 secs but you can update it as fast as you want
        }
    }

    public void AddPoints(int points)
    {
        this.score += points;
    }
}
