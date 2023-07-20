using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    //sound�� �Ѱ����� ������ �� �ֵ��� �ϴ� singleton ����
    private static BGMManager _instance;

    public AudioSource bgSound;
    public AudioClip[] bglist;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return; // Ensure that the duplicated object is destroyed immediately
        }

        //scene�� ��ȯ�Ǿ object�� �������� �ʵ�����.
        DontDestroyOnLoad(gameObject);
    }

    //Scene�� �ε������� �ش� Scene �̸��� ���� �̸� Bgm ���
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
            {
                if (bgSound.clip != bglist[i])
                {
                    BgSoundPlay(bglist[i]);
                }
                return; // Once the correct BGM is found and played, exit the loop
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