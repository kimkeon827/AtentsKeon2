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
        for (int i = 0; i < transform.childCount; i++)   // 정확한 인덱스가 필요할 때 유리
        {
            bgStarsSlots[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        float minusX = transform.position.x - Background_Stars_Width;
        foreach (Transform slot in bgStarsSlots) // 속도가 그냥 for보다 빠름
        {
            slot.Translate(scrollingSpeed * Time.deltaTime * -transform.right);

            if (slot.position.x < minusX)
            {
                //Debug.Log($"{slot.name}은 충분히 왼쪽으로 이동했다.");
                // 오른쪽으로 Background_Width의 3배(bgSlots.Length에 3개가 들어있으니까) 만큼 이동
                slot.Translate(Background_Stars_Width * bgStarsSlots.Length * transform.right);
            }
        }
        int rand = Random.Range(0, 10);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = ((rand & 0b_01) != 0);
        sprite.flipY = ((rand & 0b_10) != 0);
    }
}
