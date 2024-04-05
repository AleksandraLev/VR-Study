using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gid : MonoBehaviour
{
    private static AudioSource m_AudioSource;
    //private static AudioClip m_AudioClip;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public static void PlayAudio()
    {
        m_AudioSource.Play();
    }
    public static void StopAudio()
    {
        m_AudioSource.Stop();
    }
}
