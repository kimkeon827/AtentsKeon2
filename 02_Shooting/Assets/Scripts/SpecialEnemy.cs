using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy�� ��ӹ��� �Ŀ��� ������ ����� �� �����
/// </summary>
public class SpecialEnemy : Enemy
{
    public GameObject powerUp;  // SpecialEnemy�� �پ��ִ� �Ŀ��� ������

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // �������̵��ؼ� �Ŀ��� �����ۿ� ó�� �߰�
        if (collision.gameObject.CompareTag("Bullet"))
        {
            powerUp.transform.parent = null;
            powerUp.SetActive(true);
        }
        base.OnCollisionEnter2D(collision);
    }
}
