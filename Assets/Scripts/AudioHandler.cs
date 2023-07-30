using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AudioRequest : UnityEvent<string, bool>
{

}

public class AudioHandler : MonoBehaviour
{
    public float globalVolume;
    private Dictionary<string, AudioSource> audioIndex;

    private void Start()
    {   
        audioIndex = new Dictionary<string, AudioSource>();
    }

    public void PlaySound(string sound, bool looped = false)
    {
        CreateNewSource(sound);
        PlayAudioClip(sound, looped);
    }

    public void StopSound(string sound)
    {
        if(audioIndex.ContainsKey(sound) && audioIndex[sound].isPlaying)
        {
            audioIndex[sound].Stop();
        }
    }

    private bool CreateNewSource(string soundID)
    {
        if(audioIndex.ContainsKey(soundID)) return false;

        AudioSource source = transform.gameObject.AddComponent<AudioSource>() as AudioSource;

        source.transform.SetParent(transform);

        source.volume = globalVolume;

        // Debug.Log("Created New Audio Source");

        audioIndex.Add(soundID, source);

        return true;
    }

    private void PlayAudioClip(string clip, bool looped)
    {
        if(audioIndex[clip].isPlaying)
            audioIndex[clip].Stop();
        
        if(audioIndex[clip].clip == null)
            audioIndex[clip].clip = (AudioClip) Resources.Load($"Audio/{clip}");
        
        audioIndex[clip].loop = looped;
        audioIndex[clip].Play();
    }

}
