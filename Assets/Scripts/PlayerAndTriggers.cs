using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAndTriggers : MonoBehaviour
{
    public AudioClip audioClipWood;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wood")
        {
            GetComponent<AudioSource>().clip = audioClipWood;
            GetComponent<AudioSource>().Play();
        }
    }
}
