using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public animalTap animalTap;
    public int score;

    public void UpdateScore() { //Not used as Update() so we only check when the evolution progress is increased.
        score = Convert.ToInt32(animalTap.evolutionProgress);
        //scoreText.text = ("Score: " + score);
        scoreText.text = score.ToString();
    }

    //    void Update()
}
