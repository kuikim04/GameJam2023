using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Image bgmBtn, bgmOn, bgmOff, sfxBtn, sfxOn, sfxOff;
    public GameObject uiSetting;
    private void Update()
    {
        Debug.Log(SoundManager.Instance.BGMisMute);

        if (SoundManager.Instance.BGMisMute) bgmBtn.sprite = bgmOff.sprite;
        if (!SoundManager.Instance.BGMisMute) bgmBtn.sprite = bgmOn.sprite;

        if (SoundManager.Instance.SFXisMute) sfxBtn.sprite = sfxOff.sprite;
        if (!SoundManager.Instance.SFXisMute) sfxBtn.sprite = sfxOn.sprite;
    }

    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(_sfxSlider.value);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Setting()
    {
        uiSetting.SetActive(true);
    }

    public void CloseSetting()
    {
        uiSetting.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();

    }
}
