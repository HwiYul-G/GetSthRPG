using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject go;

    void Start()
    {
        go.SetActive(false);
    }

    // palyer�� ���ͼ� �ӹ��� �ִ� �����̸�
    // go��� ending ũ�������� ���� ���� ���̰���
    // �⺻������ �ִϸ��̼� ȿ���� �ν����͸� ���� �־����Ƿ�
    // active �Ǹ� ũ���� �����
    private void OnTriggerStay2D(Collider2D collision)
    {
      
        go.SetActive(true);
    }
}
