using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    // 인스펙터 창에 보이게하고
    // 이것으로 플레이어의 좌표 등을 설정
    public float initialValue;

    // runTime에서 돌아가는 값은 숨김
    [HideInInspector]
    public float RuntimeValue;

    // ISerializationCallbackReciver를 상속받았기에
    // 사용하지 않는 OnBeforeSerialize()도 일단 함수로 있어야함
    public void OnAfterDeserialize() {
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize() { }

}
