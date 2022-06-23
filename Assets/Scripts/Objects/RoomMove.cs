using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; // ī�޶��� ���ϸ� ����
    public Vector3 playerChange; //�÷��̾��� ��ġ ���� ������ ����
    private CameraMovement cam; // ī�޶� �����Ʈ Ŭ������ �̵� ó���� ����

    // ��ȭ�� ����� �̸� � ���� ó��
    // Canvas�� TExt�� �ٿ��� �� �̸��� �߰� ��
    public bool needText;
    public string placeName; 
    public GameObject text;
    public Text placeText;

    void Start()
    {
        // �ʱ�ȭ
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //  �� �� ������ ���� room���� �̷������ �� �� ���� ��迡 ���� ��
        // ������ �� ũ�⿡ �°� ī�޶� �� ó���� ��.
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCoroutine());
            }
        }
    }
    // �� ��ȭ�� �� �̸��� ȭ�鿡 �ߵ��� �ϱ� ���� ó��
    private IEnumerator placeNameCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
    }
}
