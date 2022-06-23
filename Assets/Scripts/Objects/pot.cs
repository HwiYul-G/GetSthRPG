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

    //smash �� ������ �ִϸ��̼� ȿ��
    public void Smash()
    {
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
    }
    // �����鼭 ���̻� ������ �ʰ� ó��
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
}
