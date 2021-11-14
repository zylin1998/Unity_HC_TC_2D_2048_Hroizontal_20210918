using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public Text _main_Rate;
    public Text _BGM_Rate;
    public Text _SFX_Rate;

    public void StartButton(float delay) 
    {
        Invoke("DelayStartGame", delay);
    }

    public void DelayStartGame() 
    {
        SceneManager.LoadScene("¹CÀ¸³õ´º");
    }

    public void SettingButton()
    { 
        //Not using.
    }

    public void QuitButton(float delay) 
    {
        Invoke("DelayQuitButton", delay);
    }

    public void DelayQuitButton() 
    {
        Application.Quit();
    }

    public void MainBar(float value)
    {
        _main_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetMainVolume(value);
    }

    public void BGMBar(float value) 
    {
        _BGM_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetBGMVolume(value);
    }

    public void SFXBar(float value) 
    {
        _SFX_Rate.text = value.ToString() + '%';
        FindObjectOfType<AudioMixerController>().SetSFXVolume(value);
    }
}
