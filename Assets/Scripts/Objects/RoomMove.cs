using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange; // 카메라의 변하를 위함
    public Vector3 playerChange; //플레이어의 위치 값을 가지고 있음
    private CameraMovement cam; // 카메라 무브먼트 클래스로 이동 처리를 위함

    // 변화된 장소의 이름 등에 대한 처리
    // Canvas에 TExt를 붙여서 그 이름이 뜨게 함
    public bool needText;
    public string placeName; 
    public GameObject text;
    public Text placeText;

    void Start()
    {
        // 초기화
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //  한 씬 내에서 여러 room으로 이루어졌을 때 그 룸의 경계에 있을 때
        // 각각의 방 크기에 맞게 카메라 값 처리를 함.
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
    // 룸 변화시 그 이름이 화면에 뜨도록 하기 위한 처리
    private IEnumerator placeNameCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
    }
}
