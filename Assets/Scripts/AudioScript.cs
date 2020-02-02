using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioClip winSound;
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
    }

    public void PlayWin()
    {
        AS.PlayOneShot(winSound);
    }

    #region Singleton
    private static AudioScript s_Instance = null;

    public static AudioScript instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(AudioScript)) as AudioScript;
            }

            if (s_Instance == null)
            {
                var obj = new GameObject("AudioScript");
                s_Instance = obj.AddComponent<AudioScript>();
            }

            return s_Instance;
        }
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }
    #endregion

}
