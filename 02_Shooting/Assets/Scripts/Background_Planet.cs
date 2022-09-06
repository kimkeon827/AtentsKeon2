using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Planet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float minRightEnd = 40.0f;
    public float maxRightEnd = 60.0f;

    const float movePositionX = -10.0f;

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * -transform.right);

        for (int i = 0; i < movePositionX; i++)
        {
            bgSlots[i].Translate(moveSpeed * Time.deltaTime * -transform.right);
            if (bgSlots[i].position.x < movePositionX)
            {
                MoveRightEnd(i);
            }
        }
    }
}
