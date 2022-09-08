using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifePanel : MonoBehaviour
{
    TextMeshProUGUI lifeText;

    private void Awake()
    {
        lifeText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        //GameObject.Find();  // �̸����� ã��
        //GameObject.FindGameObjectsWithTag();    // �±׷� ã��
        //GameObject.FindObjectOfType();          // Ÿ������ ã��
        Player player = FindObjectOfType<Player>(); // Ÿ������ Player ã��
        player.onLifeChange += Refresh;             // ��������Ʈ�� �Լ� ���
    }
    private void Refresh(int life)
    {
        lifeText.text = life.ToString();    // �Է¹��� Life������ ȭ�� ����
    }
}
