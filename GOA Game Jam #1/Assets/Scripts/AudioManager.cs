using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip victoryClip, startClip, wrongClip;

    private void Start()
    {
        instance = this;
    }

    public void PlayVictory()
    {
        GameObject source = Instantiate(gameObject);
        source.GetComponent<AudioManager>().enabled = false;
        AudioSource aSource = source.AddComponent<AudioSource>();
        aSource.clip = victoryClip;
        aSource.Play();
        Destroy(source, victoryClip.length + 1);
    }

    public void PlayStart()
    {
        GameObject source = Instantiate(gameObject);
        source.GetComponent<AudioManager>().enabled = false;
        AudioSource aSource = source.AddComponent<AudioSource>();
        aSource.clip = startClip;
        aSource.Play();
        Destroy(source, startClip.length + 1);
    }

    public void PlayWrong()
    {
        GameObject source = Instantiate(gameObject);
        source.GetComponent<AudioManager>().enabled = false;
        AudioSource aSource = source.AddComponent<AudioSource>();
        aSource.clip = wrongClip;
        aSource.Play();
        Destroy(source, wrongClip.length + 1);
    }
}
