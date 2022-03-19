using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    [SerializeField]
    private int score;
    
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
