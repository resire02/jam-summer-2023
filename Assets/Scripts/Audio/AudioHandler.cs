using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler Player;
    [SerializeField] AudioSource _music, _sfx;
    AudioClip _musicActive, _sfxActive;

    //  runs when script becomes active
    private void Awake()
    {
        if(Player == null)
        {
            Player = this;                  //  reinitalize global player if not initialized
            DontDestroyOnLoad(gameObject);  //  keep object persistent between scene loads
        }
        else
        {
            Destroy(gameObject);    //  destroy object since player already exists
        }
    }

    public void PlaySFX(string name)
    {
        _sfxActive = LoadClipFromResources(name);
        if(_sfxActive == null) return;
        _sfx.clip = _sfxActive;
        _sfx.Play();
    }

    public void PlayMusic(string name)
    {
        _musicActive = LoadClipFromResources(name);
        if(_musicActive == null) return;
        _music.clip = _musicActive;
        _music.loop = true;
        _music.Play();
    }

    private AudioClip LoadClipFromResources(string clip)
    {
        return Instantiate(Resources.Load<AudioClip>($"Audio/{clip}"));
    }

}
