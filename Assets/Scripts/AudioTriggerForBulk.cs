using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioTriggerForBulk : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Sound;
    void OnTriggerEnter(Collider cld)
    {
        if (cld.tag == "Player")
        {
            GetComponent<AudioSource>().clip = Sound;
            GetComponent<AudioSource>().Play();
        }
    }
}
