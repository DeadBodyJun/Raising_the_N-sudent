using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GetKnowledge : MonoBehaviour
{
    public AudioSource audioSource;     // AudioSource ������Ʈ
    public AudioClip touchSound;        // ��ġ ȿ���� AudioClip

    public void Start()
    {

    }

    public void Click()
    {
        GameManager.instance.Knolge += GameManager.instance.TouchKnolge;
    }

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            else
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    GameManager.instance.Knolge += GameManager.instance.TouchKnolge;
                    PlayTouchSound();   // ��ġ ȿ���� ���
                }
            }
        }
    }

    private void PlayTouchSound()
    {
        if (audioSource != null && touchSound != null)
        {
            audioSource.PlayOneShot(touchSound);
        }
    }
}