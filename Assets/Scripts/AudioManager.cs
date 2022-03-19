using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            //there is still no instance in our game
            if (instance == null)
            {
                //Check if there is an existing game object in the scene that has the component
                instance = FindObjectOfType<AudioManager>();
                //did not find any gameobject with the instance in the heirarchy
                if (instance == null)
                {
                    //generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //change the default name
                    go.name = "AudioManager";
                    //add component and set it as the instance
                    instance = go.AddComponent<AudioManager>();
                    //make sure the object persists
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        //set the instance if no copy in the heirarchy
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //if there is copy, destroy
            Destroy(gameObject);
        }
    }

    public void PlaySound(string clipName)
    {
        //Create a gameobject with an AudioController component
        AudioController ac = LoadAudio();
        ac.PlayClip(clipName);
    }

    public void PlaySound(string clipName, float volume)
    {
        AudioController ac = LoadAudio();
        ac.PlayClip(clipName, volume);
    }

    private AudioController LoadAudio()
    {
        GameObject go = new GameObject();
        go.AddComponent<AudioController>();
        return go.GetComponent<AudioController>();
    }

}
