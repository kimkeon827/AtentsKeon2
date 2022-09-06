using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Planet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float minRightEnd = 40.0f;
    public float maxRightEnd = 60.0f;
    public float minHeight = -8.0f;
    public float maxHeight = -5.0f;

    const float movePositionX = -10.0f;

    private void Update()
    {
        // �� ������Ʈ�� �������� �� �� moveSpeed��ŭ �̵��Ѵ�.
        transform.Translate(moveSpeed * Time.deltaTime * -transform.right);
        // �� ������Ʈ�� movePositionX���� �������� �̵��ϸ� ������ ������ �̵��Ѵ�.
        if( transform.position.x < movePositionX)
        {
            // ������ ���� ��ġ�� minRightEnd ~ maxRightEnd ���̸� �������� �����Ѵ�.
            //transform.Translate(transform.right * Random.Range(minRightEnd, maxRightEnd));

            // ���̵� minHeight ~ maxHeight�� �����Ѵ�.
            //Vector3 newPos = transform.position;
            //newPos.y = Random.Range(minHeight, maxHeight);
            //transform.position = newPos;

            // ���� ���� �ڵ�
            Vector3 newPos2 = new Vector3(
                transform.position.x + Random.Range(minRightEnd, maxRightEnd),  // x ��ġ ����
                Random.Range(minHeight, maxHeight), 0.0f);  // y ��ġ ����
            transform.position = newPos2;

        }
    }
}
