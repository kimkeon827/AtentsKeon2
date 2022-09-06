using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Stars : Background
{
    public Transform[] bgStarsSlots;
    const float Background_Stars_Width = 13.6f;

    private void Awake()
    {
        bgStarsSlots = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)   // ��Ȯ�� �ε����� �ʿ��� �� ����
        {
            bgStarsSlots[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        float minusX = transform.position.x - Background_Stars_Width;
        foreach (Transform slot in bgStarsSlots) // �ӵ��� �׳� for���� ����
        {
            slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);

            if (slot.position.x < minusX)
            {
                //Debug.Log($"{slot.name}�� ����� �������� �̵��ߴ�.");
                // ���������� Background_Width�� 3��(bgSlots.Length�� 3���� ��������ϱ�) ��ŭ �̵�
                slot.Translate(Background_Stars_Width * bgStarsSlots.Length * transform.right);
            }
        }
        int rand = Random.Range(0, 10);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = ((rand & 0b_01) != 0);
        sprite.flipY = ((rand & 0b_10) != 0);
    }
}
