using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //sound를 한곳에서 관리할 수 있도록 하는 singleton 패턴
    private static SoundManager _instance;

    public AudioSource bgSound;
    public AudioClip[] bglist;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        
        //scene이 전환되어도 object가 없어지지 않도록함.
        DontDestroyOnLoad(gameObject);
    }

    //Scene이 로딩됐을때 해당 Scene 이름과 같은 이름 Bgm 재생
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i=0; i<bglist.Length; i++)
        {
            if(arg0.name == bglist[i].name)
            {
                BgSoundPlay(bglist[i]);
            }
        }
    }

    //Bgm 플레이 함수
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }
}
