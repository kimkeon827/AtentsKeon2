using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        Transform panel = transform.GetChild(0);
        Transform point = panel.GetChild(1);
        scoreText = point.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        player.onScoreChange += RefreshScore;        
    }

    private void RefreshScore(int newScore)
    {
        //scoreText.text = newScore.ToString();
        scoreText.text = $"{newScore,4}";
    }


    // RefreshScroe에서 받은 파라메터 값을 바로 사용하지 않고 목표치로 이용한다.
    // 목표치가 될 때까지 scoreText를 계속 변경시킨다.
}
