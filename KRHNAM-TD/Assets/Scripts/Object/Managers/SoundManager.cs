using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;
    public static SoundManager Instance => instance;


    public AudioSource effectsSource;
    public AudioClip[] soundEffects;

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

    private AudioClip GetClipByName(string clipName, AudioClip[] clips)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipName)
                return clip;
        }
        return null;
    }
}
