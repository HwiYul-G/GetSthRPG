using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ��ũ��Ʈ, ���� �� ���� �� ���콺 ��Ŭ������ �����ϴ� ��ó��
// Asset Menu�� ��ġ ����Ƽ�� �⺻������ �ִ� ��ó�� create�ϴ� ��
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    // Signal�� ���� ������ listen�� SignalListener List ����
    public List<SignalListener> listeners = new List<SignalListener>();

    //�޾Ƴ��� Signal���� �߻�(Raise) ��Ű���� �ϴ� �Լ�
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    // List�� Signal�� ���� SignalListener �߰�
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }
    // ����
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
