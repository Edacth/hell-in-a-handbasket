using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip[] audioClips;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void PlaySlurp()
    {
        int soundIndex;
        soundIndex = Random.Range(0, audioClips.Length);

        AS.PlayOneShot(audioClips[soundIndex]);
        Debug.Log("Slurp");
    }

}
