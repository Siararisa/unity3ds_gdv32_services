using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlayClip(string audioName, float volume = 1.0f)
    {
        source.clip = Resources.Load<AudioClip>("Audio/" + audioName);
        source.volume = volume;
        gameObject.name = "audioclip_" + audioName;
        source.Play();
    }
}
