using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [Header("���q�d��")]
    public float _maxVolume = 0f;
    public float _minVolume = -30f;
    [Header("���q���")]
    public float _Main_presentage = 50f;
    public float _BGM_presentage = 50f;
    public float _SFX_presentage = 50f;
    [Header("��X���q")]
    public float _Main_volume;
    public float _BGM_volume;
    public float _SFX_volume;
    [Header("�V���˸m")]
    public AudioMixer _audioMixer;

    public void SetMainVolume(float value)
    {
        if (value > 0)
        {
            _Main_presentage = value;
            _Main_volume = _Main_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("���qMaster", _Main_volume);
        }
        else { _audioMixer.SetFloat("���qBGM", -80f); }
    }

    public void SetBGMVolume(float value)
    {
        if (value > 0)
        {
            _BGM_presentage = value;
            _BGM_volume = _BGM_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("���qBGM", _BGM_volume);
        }
        else { _audioMixer.SetFloat("���qBGM", -80f); }
    }

    public void SetSFXVolume(float value)
    {
        if (value > 0)
        {
            _SFX_presentage = value;
            _SFX_volume = _SFX_presentage / 100f * (_maxVolume - _minVolume) + _minVolume;
            _audioMixer.SetFloat("���qSFX", _SFX_volume);
        }
        else { _audioMixer.SetFloat("���qSFX", -80f); }
    }
}
