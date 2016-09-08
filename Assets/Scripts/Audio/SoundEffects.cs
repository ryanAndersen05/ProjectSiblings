using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class SoundEffects : MonoBehaviour {
    public float maxVolume = 1;
    public float minVolume = .9f;
    public float maxPitch = 1.05f;
    public float minPitch = .95f;
    public AudioClip[] aClips = new AudioClip[1];
    public float[] randChanceClips = new float[1];

    public bool allowPan = false;

    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        if (aClips.Length <= 0 || aClips[0] == null)
        {
            print("Error! No audio clips added to " + DebugTools.GetPathToObject(transform));
        }
        
    }

    /// <summary>
    /// Plays a sound effect with a random Audioclip from the list aClips with 
    /// a random pitch and volume within the set ranges.
    /// </summary>
    public void playSoundRandom()
    {
        setRandom();
        playSound();
    }

    public void setRandom()
    {
        aSource.pitch = Random.Range(minPitch, maxPitch);
        aSource.volume = Random.Range(minVolume, maxVolume);
        aSource.clip = aClips[Random.Range(0, aClips.Length)];
    }

    public void playSound()
    {
        aSource.Stop();
        aSource.Play();
    }

    public void stopSound()
    {
        aSource.Stop();
    }

    public void setVolume(float volume)
    {
        aSource.volume = volume;
    }

    public void setPitch(float pitch)
    {
        aSource.pitch = pitch;
    }

    public void setClip(int index)
    {
        if (index < 0 || index >= aClips.Length)
        {
            return;
        }
        aSource.clip = aClips[index];
    }
}
