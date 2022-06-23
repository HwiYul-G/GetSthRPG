using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    //SignalListener�� ���� signal
    public Signal signal;
    public UnityEvent signalEvent; //Unity ���� Event���� Action�� ���� ���� 

    // Invoke �ڱ��ϴ� �����ϰ� �ϴ� �Լ�
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    // signal ��ũ��Ʈ�� ���� RegisterListener�� �̿���
    // ���
    private void OnEnable()
    {
        signal.RegisterListener(this);
    }
    //��� ����
    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
