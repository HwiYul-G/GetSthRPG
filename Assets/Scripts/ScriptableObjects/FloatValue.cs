using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    // �ν����� â�� ���̰��ϰ�
    // �̰����� �÷��̾��� ��ǥ ���� ����
    public float initialValue;

    // runTime���� ���ư��� ���� ����
    [HideInInspector]
    public float RuntimeValue;

    // ISerializationCallbackReciver�� ��ӹ޾ұ⿡
    // ������� �ʴ� OnBeforeSerialize()�� �ϴ� �Լ��� �־����
    public void OnAfterDeserialize() {
        RuntimeValue = initialValue;
    }
    public void OnBeforeSerialize() { }

}
