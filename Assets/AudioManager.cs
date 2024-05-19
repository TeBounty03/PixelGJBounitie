using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------Audio Clip------")]
    public AudioClip bump;
    public AudioClip jump;
    public AudioClip die;
    public AudioClip elec;
    public AudioClip musicPlayed;
    public AudioClip[] plocs;

    private void Start()
    {
        musicSource.clip = musicPlayed;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayRandomSFX()
    {
        if (plocs.Length == 0)
        {
            Debug.LogWarning("No sound effects available to play.");
            return;
        }

        int randomIndex = Random.Range(0, plocs.Length);
        AudioClip randomClip = plocs[randomIndex];
        SFXSource.PlayOneShot(randomClip);
    }


}
