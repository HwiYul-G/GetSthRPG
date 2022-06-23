using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 스크립트, 폴더 등 생성 시 마우스 우클릭으로 생성하는 것처럼
// Asset Menu에 마치 유니티에 기본적으로 있는 것처럼 create하는 것
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    // Signal에 대한 정보를 listen할 SignalListener List 생성
    public List<SignalListener> listeners = new List<SignalListener>();

    //받아놓은 Signal들을 발생(Raise) 시키도록 하는 함수
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    // List에 Signal을 받을 SignalListener 추가
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }
    // 삭제
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
