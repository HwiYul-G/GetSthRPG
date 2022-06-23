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

    // palyer가 들어와서 머물고 있는 상태이면
    // go라는 ending 크레딧으로 받은 것을 보이게함
    // 기본적으로 애니매이션 효과를 인스펙터를 통해 넣었으므로
    // active 되면 크레딧 실행됨
    private void OnTriggerStay2D(Collider2D collision)
    {
      
        go.SetActive(true);
    }
}
