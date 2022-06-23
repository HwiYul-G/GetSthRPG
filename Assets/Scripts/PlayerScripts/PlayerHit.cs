using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    // Enemy�� �ƴ� �Ϲ� object�� �� �νñ� ���� ��.
    // ���� ���ӿ��� pot ������Ʈ�� breakable Tag�� �޾� �ν� �� ����
    // pot �ֵܾ� tag�� �̿��� �ٸ� ������Ʈ�� �߰��� �� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<pot>().Smash();
        }
    }
}
