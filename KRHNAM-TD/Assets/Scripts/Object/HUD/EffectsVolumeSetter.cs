using UnityEngine;
using UnityEngine.UI;

public class EffectsVolumeSetter : MonoBehaviour
{
    private Slider slidersss;

    public void Awake()
    {
        slidersss = GetComponent<Slider>();
    }

    public void Start()
    {
        slidersss.value = SoundManager.Instance.GetEffectsVolume();
    }

    //Selon la valeur du slider, on change le volume de la musique
    public void SetVolume()
    {
        float volume = slidersss.value;
        SoundManager.Instance.SetEffectsVolumeTo(volume);
    }
}
