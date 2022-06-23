using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();    
    }

    //smash 시 깨지는 애니매이션 효과
    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
    }
    // 깨지면서 더이상 보이지 않게 처리
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
