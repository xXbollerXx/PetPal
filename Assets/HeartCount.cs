using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartCount : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = scoreManager.score.ToString();
    }
}
