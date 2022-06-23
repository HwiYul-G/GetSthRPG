using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    //SignalListener가 받을 signal
    public Signal signal;
    public UnityEvent signalEvent; //Unity 내장 Event관련 Action을 위한 변수 

    // Invoke 자극하다 실행하게 하는 함수
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    // signal 스크립트에 만든 RegisterListener을 이용해
    // 등록
    private void OnEnable()
    {
        signal.RegisterListener(this);
    }
    //등록 해제
    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
