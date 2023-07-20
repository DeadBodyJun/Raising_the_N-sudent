using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SFXManager : MonoBehaviour
{
    // ���� ������ ���� �̱��� ������ ����մϴ�.
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

    // ��ư ��ġ ȿ������ ������ ����� Ŭ�� �迭�Դϴ�.
    public AudioClip[] buttonTouchSounds;

    // �Ϲ� ȭ�� ��ġ ȿ������ ������ ����� Ŭ���Դϴ�.
    public AudioClip screenTouchSound;

    // ȿ������ ����� AudioSource�� ������ �����Դϴ�.
    private AudioSource audioSource;

    private void Awake()
    {
        // �� ��ũ��Ʈ�� ��� ��ȯ�ÿ��� �����ǵ��� �����մϴ�.
        DontDestroyOnLoad(gameObject);

        // AudioSource ������Ʈ�� �߰��ϰ� �����մϴ�.
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // ��ư ��ġ ȿ������ ����ϴ� �޼����Դϴ�.
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

    // �Ϲ� ȭ�� ��ġ ȿ������ ����ϴ� �޼����Դϴ�.
    public void PlayScreenTouchSound()
    {
        if (screenTouchSound != null)
        {
            audioSource.PlayOneShot(screenTouchSound);
        }
    }
}
