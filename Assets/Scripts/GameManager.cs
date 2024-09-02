



//For the record, far from my best work. Its been a rough week and I procrastinated. I do not expect a softer grade
//I simply wanted to explain that I will lock in for the future assignments, this ones a stand out. I am a better coder
//than this, hell first semester I was a better coder of CyberCrime. 
//Anyway have a good day :D


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float lives;
    public float score;
    public GameObject DeathUi;
    public TMP_Text Score;
    public TMP_Text Lives;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            DeathUi.SetActive(true);
        }

        Score.text = "Score " + score.ToString();
        Lives.text = "Lives: " + lives.ToString();
    }

    public void AddScore()
    {
        score += 200;
    }

    public void LoseLife()
    {
        lives -= 1;
    }

}
