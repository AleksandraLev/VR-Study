using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.GraphicsBuffer;

public class AudioTriggerForGid : MonoBehaviour
{
    public AudioClip Sound1;
    public AudioClip Sound2;
    public AudioClip Sound3;
    public AudioClip Sound4;
    public GameObject character;
    bool forStartMoving = false;
    //bool forEndMoving = false;
    bool forTalking = true;
    bool forThirdTalking = false;
    bool forSecondStartMoving = false;
    bool forSecondTalkind = true;

    void Update()
    {
        if (forStartMoving && character.transform.position.z > -11)
        {
            character.transform.position += new Vector3(0, 0, -0.02f);
            //forEndMoving = true;
        }
        if (character.transform.position.z <= -10 && !forSecondStartMoving && !forThirdTalking && character.transform.position.z < -10.5 && forSecondTalkind)
        {
            character.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * 5);
            //GetComponent<AudioSource>().clip = Sound2;
            //GetComponent<AudioSource>().Play();
            Invoke("ForSecondSound", 2);
            //forEndMoving = false; 
        }
        if (forSecondStartMoving && (character.transform.position.z > -63 || character.transform.position.x > -81))
        {
            character.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 45, 0), Time.deltaTime * 3);
            character.transform.position += new Vector3(-0.02f, 0, -0.01f);
            
        }
        if (character.transform.position.z <= -63 && character.transform.position.x <= -81)
        {
            //Debug.Log("Второй поворот");
            forSecondStartMoving = false;
            character.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 225, 0), Time.deltaTime * 5);
            Invoke("ForThirdSound", 2);
        }

    }

    void OnTriggerEnter(Collider cld)
    {
        if (cld.tag == "Player" && forTalking)
        {
            GetComponent<AudioSource>().clip = Sound1;
            GetComponent<AudioSource>().Play();
            Invoke("ForStartMoving_true", 6);
            forTalking = false;   
        }
        else if (cld.tag == "Player" && forThirdTalking)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = Sound3;
            GetComponent<AudioSource>().Play();
            Invoke("ForSecondStartMoving_true", 4);
            forSecondTalkind = false;
            forThirdTalking = false;
        }
    }

    void ForStartMoving_true()
    {
        forStartMoving = true;
    }
    void ForSecondStartMoving_true()
    {
        forSecondStartMoving = true;
    }
    void ForThirdTalking_true()
    {
        forThirdTalking = true;
    }
    void ForSecondSound()
    {
        //Debug.Log("Вторая часть экскурсии");
        if (!GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().clip != Sound2)
        {
            GetComponent<AudioSource>().clip = Sound2;
            GetComponent<AudioSource>().Play();
            Invoke("ForThirdTalking_true", 10);

        }
        else if (GetComponent<AudioSource>().clip == Sound1)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = Sound2;
            GetComponent<AudioSource>().Play();
            forSecondStartMoving = true;
        }     
    }
    void ForThirdSound()
    {
        if (!GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().clip != Sound4)
        {
            GetComponent<AudioSource>().clip = Sound4;
            GetComponent<AudioSource>().Play();

        }
        else if (GetComponent<AudioSource>().clip == Sound3)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = null;
            GetComponent<AudioSource>().clip = Sound4;
            GetComponent<AudioSource>().Play();
        }
    }
}
