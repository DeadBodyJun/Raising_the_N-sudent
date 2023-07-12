using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //sound�� �Ѱ����� ������ �� �ֵ��� �ϴ� singleton ����
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
        
        //scene�� ��ȯ�Ǿ object�� �������� �ʵ�����.
        DontDestroyOnLoad(gameObject);
    }

    //Scene�� �ε������� �ش� Scene �̸��� ���� �̸� Bgm ���
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

    //Bgm �÷��� �Լ�
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }
}
