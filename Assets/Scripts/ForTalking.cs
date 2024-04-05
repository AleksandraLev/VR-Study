using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ForTalking : MonoBehaviour
{
    public GameObject player;
    public GameObject character;
    private Vector3 vector3;
    public AudioSource m_AudioSource;
    public Renderer m_Renderer;
    public AudioClip m_AudioClip;
    private void Start()
    {
        //character = GetComponent<GameObject>();
        //m_Renderer = GetComponent<Renderer>();
        //m_AudioSource = GetComponent<AudioSource>();
        vector3 = character.transform.position;
        //m_AudioSource.Play();

    }
    public void Update()
    {
        //PlayAudio();

        //float dist = Vector3.Distance(player.transform.position, vector3);
        Debug.Log("x: " + Mathf.Abs(player.transform.position.x - vector3.x));
        Debug.Log("y: " + Mathf.Abs(player.transform.position.y - vector3.y));
        if (Mathf.Abs(player.transform.position.x - vector3.x) < 5 && Mathf.Abs(player.transform.position.z - vector3.z) < 5)
        {
            PlayAudio();
        }
        else
        {
            StopAudio();
        }
        if (m_Renderer.isVisible)
        {
            Debug.Log("Рыбка видна");
            PlayAudio();
        }

    }
    public void PlayAudio()
    {
        m_AudioSource.Play();
    }
    public void StopAudio()
    {
        m_AudioSource.Stop();
    }
    //public void OnMouseOver()
    //{
    //    m_AudioSource.Play();
    //}
    //public void OnMouseExit()
    //{
    //    m_AudioSource.Stop();
    //}
    //void OnTriggerEnter(Collider cld)
    //{
    //    if (cld.tag == "Player")
    //    {
    //        GetComponent<AudioSource>().clip = m_AudioClip;
    //        GetComponent<AudioSource>().Play();
    //    }
    //}

}