using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound (AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

    public void PlaySoundWithRandomVolume(AudioClip sound)
    {
        float r = Random.Range(0.8f, 1.2f);
        aud.PlayOneShot(sound, r);
    }
}
