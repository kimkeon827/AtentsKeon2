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
        // �� ������Ʈ�� �������� �� �� moveSpeed��ŭ �̵��Ѵ�.
        // �� ������Ʈ�� movePositionX���� �������� �̵��ϸ� ������ ������ �̵��Ѵ�.
        // ������ ���� ��ġ�� minRightEnd ~ maxRightEnd ���̸� �������� �����Ѵ�.
    }
}
