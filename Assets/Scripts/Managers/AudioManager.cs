using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; // 사운드의 이름.

    public AudioClip clip; // 사운드 파일 (파일은 카세트 테이프)
    private AudioSource source; // 사운드 플레이어 (오디오)

    public float Volumn; // 볼륨 소리
    public bool loop; // loop 시킬지 말지 

    // 위의 변수에 대한 초기화 함수들
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.volume = Volumn;
    }
    // 실제 볼륨값을 변수 볼륨으로 바꿈
    public void SetVolumn()
    {
        source.volume = Volumn;
    }
    // 오디오 플레이
    public void Play()
    {
        source.Play();
    }
    // 멈추기
    public void Stop()
    {
        source.Stop();
    }
    // 반복 처리하기
    public void SetLoop()
    {
        source.loop = true;
    }
    // 반복 취소
    public void SetLoopCancel()
    {
        source.loop = false;
    }
}

// 실제 메니저 
public class AudioManager : MonoBehaviour
{
    // 매니저 클래스이므로 싱글톤 처리를 위한 변수
    // 싱글톤이란 이 해당 클래스가 전체 게임에서 1개만 잇게 하기 위함
    static public AudioManager instance;

    [SerializeField]
    public Sound[] sounds; //클립 여러개

    private void Awake() // 싱글톤 처리
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

    // 초기화
    void Start()
    {
        // 사운드파일의 이름을 위에서 만든 사운드 관련 컴포넌트처럼 있는 것에서 미리 넣어놓음
        // 그거를 반복해서 돌리면서 실제 audioSource로 넣음
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }
    // 위에서 반복한 것을 이름을 체크해서 list로 돌리면서 play
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
    // 멈추는 것
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
    // loop 시작 설정
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
    // loop 취소
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
    // 볼륨 설정
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
