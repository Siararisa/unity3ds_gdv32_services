using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "SCORE: " + ScoreManager.Instance.GetScore().ToString();
    }
}
