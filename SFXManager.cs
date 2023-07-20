using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SFXManager : MonoBehaviour
{
    // 사운드 관리를 위한 싱글톤 패턴을 사용합니다.
    private static SFXManager instance;
    public static SFXManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SFXManager>();
                if (instance == null)
                {
                    GameObject sfxManagerObject = new GameObject("SFXManager");
                    instance = sfxManagerObject.AddComponent<SFXManager>();
                }
            }
            return instance;
        }
    }

    // 버튼 터치 효과음을 저장할 오디오 클립 배열입니다.
    public AudioClip[] buttonTouchSounds;

    // 일반 화면 터치 효과음을 저장할 오디오 클립입니다.
    public AudioClip screenTouchSound;

    // 효과음을 재생할 AudioSource를 저장할 변수입니다.
    private AudioSource audioSource;

    private void Awake()
    {
        // 이 스크립트가 장면 전환시에도 유지되도록 설정합니다.
        DontDestroyOnLoad(gameObject);

        // AudioSource 컴포넌트를 추가하고 저장합니다.
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // 버튼 터치 효과음을 재생하는 메서드입니다.
    public void PlayButtonTouchSound(int soundIndex)
    {
        if (soundIndex < 0 || soundIndex >= buttonTouchSounds.Length)
        {
            Debug.LogWarning("Invalid sound index for button touch sound!");
            return;
        }

        if (buttonTouchSounds[soundIndex] != null)
        {
            audioSource.PlayOneShot(buttonTouchSounds[soundIndex]);
        }
    }

    // 일반 화면 터치 효과음을 재생하는 메서드입니다.
    public void PlayScreenTouchSound()
    {
        if (screenTouchSound != null)
        {
            audioSource.PlayOneShot(screenTouchSound);
        }
    }
}
