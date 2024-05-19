using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musiqueSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
            SetMusiqueVolume();
        }
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetMusiqueVolume()
    {
        float volume = musiqueSlider.value;
        myMixer.SetFloat("Musique", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musiqueVolume", volume);
    }

    private void LoadVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        musiqueSlider.value = PlayerPrefs.GetFloat("musiqueVolume");
        SetSFXVolume();
        SetMusiqueVolume();
    }

}
