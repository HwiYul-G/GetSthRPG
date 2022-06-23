using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    // Enemy가 아닌 일반 object들 을 부시기 위한 것.
    // 현재 게임에는 pot 오브젝트만 breakable Tag를 달아 부실 수 잇음
    // pot 외애도 tag를 이용해 다른 오브젝트를 추가할 수 있음
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("breakable"))
        {
            other.GetComponent<pot>().Smash();
        }
    }
}
