using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance => instance;


    public AudioSource effectsSource;
    public AudioClip[] soundEffects;
    public AudioSource musicSource;
    public AudioClip[] musicClips;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }


    public void Start()
    {
        PlayMusic("MC1");
    }

    public void PlayEffect(string clipName)
    {
        AudioClip clip = GetClipByName(clipName, soundEffects);
        if (clip != null)
        {
            effectsSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError($"L'effet audio '{clipName}' n'a pas été trouvé!");
        }
    }

    public void PlayMusic(string clipName)
    {
        AudioClip clip = GetClipByName(clipName, musicClips);
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
        else
        {
            Debug.LogError($"La musique '{clipName}' n'a pas été trouvée!");
        }
    }

    private AudioClip GetClipByName(string clipName, AudioClip[] clips)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipName)
                return clip;
        }
        return null;
    }

    public void SetMusicVolumeTo(float volume)
    {
        musicSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public void SetEffectsVolumeTo(float volume)
    {
        effectsSource.volume = volume;
    }

    public float GetEffectsVolume()
    {
        return effectsSource.volume;
    }

}
