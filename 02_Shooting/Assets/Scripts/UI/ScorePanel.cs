using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int targetScore = 0;            // ��ǥ��
    float currentScore = 0.0f;      // ���簪

    private void Awake()
    {
        Transform panel = transform.GetChild(0);
        Transform point = panel.GetChild(1);
        scoreText = point.GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        player.onScoreChange += SetTargetScore;

        targetScore = 0;
        currentScore = 0.0f;
    }

    private void Update()
    {
        // 1 ������ : ȭ�鿡 �׸� �׸� ����.
        if( currentScore < targetScore) // currentScore�� targetScore���� ������ �۰ų� ������ ����
        {
            currentScore += Time.deltaTime; // currentScore ������Ű��

            currentScore = Mathf.Min(currentScore, targetScore);      // currentScore�� targetScore���� ������ �۰ų� ������ ����.

            scoreText.text = $"{currentScore:f0}";  // UI�� ���
        }
    }
    private void SetTargetScore(int newScore)
    {
        targetScore = newScore;
    }


    // RefreshScroe���� ���� �Ķ���� ���� �ٷ� ������� �ʰ� ��ǥġ�� �̿��Ѵ�.
    // ��ǥġ�� �� ������ scoreText�� ��� �����Ų��.
}
