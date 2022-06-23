using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; // ������ �̸�.

    public AudioClip clip; // ���� ���� (������ ī��Ʈ ������)
    private AudioSource source; // ���� �÷��̾� (�����)

    public float Volumn; // ���� �Ҹ�
    public bool loop; // loop ��ų�� ���� 

    // ���� ������ ���� �ʱ�ȭ �Լ���
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.volume = Volumn;
    }
    // ���� �������� ���� �������� �ٲ�
    public void SetVolumn()
    {
        source.volume = Volumn;
    }
    // ����� �÷���
    public void Play()
    {
        source.Play();
    }
    // ���߱�
    public void Stop()
    {
        source.Stop();
    }
    // �ݺ� ó���ϱ�
    public void SetLoop()
    {
        source.loop = true;
    }
    // �ݺ� ���
    public void SetLoopCancel()
    {
        source.loop = false;
    }
}

// ���� �޴��� 
public class AudioManager : MonoBehaviour
{
    // �Ŵ��� Ŭ�����̹Ƿ� �̱��� ó���� ���� ����
    // �̱����̶� �� �ش� Ŭ������ ��ü ���ӿ��� 1���� �հ� �ϱ� ����
    static public AudioManager instance;

    [SerializeField]
    public Sound[] sounds; //Ŭ�� ������

    private void Awake() // �̱��� ó��
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // �ʱ�ȭ
    void Start()
    {
        // ���������� �̸��� ������ ���� ���� ���� ������Ʈó�� �ִ� �Ϳ��� �̸� �־����
        // �װŸ� �ݺ��ؼ� �����鼭 ���� audioSource�� ����
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("���� ���� �̸� : " + i + " = " + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }
    // ������ �ݺ��� ���� �̸��� üũ�ؼ� list�� �����鼭 play
    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
    // ���ߴ� ��
    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }
    // loop ���� ����
    public void SetLoop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoop();
                return;
            }
        }
    }
    // loop ���
    public void SetLoopCancel(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoopCancel();
                return;
            }
        }
    }
    // ���� ����
    public void SetVolumn(string _name, float _Volumn)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Volumn = _Volumn;
                sounds[i].SetVolumn();
                return;
            }
        }
    }
}
