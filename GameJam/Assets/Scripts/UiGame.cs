using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    public GameObject uiSetting;
    public Image bgmBtn, bgmOn, bgmOff, sfxBtn, sfxOn, sfxOff;

    private void Update()
    {
        if (SoundManager.Instance.BGMisMute) bgmBtn.sprite = bgmOff.sprite;
        if (!SoundManager.Instance.BGMisMute) bgmBtn.sprite = bgmOn.sprite;

        if (SoundManager.Instance.SFXisMute) sfxBtn.sprite = sfxOff.sprite;
        if (!SoundManager.Instance.SFXisMute) sfxBtn.sprite = sfxOn.sprite;
    }

    public void UISetting()
    {
        Time.timeScale = 0;
        uiSetting.SetActive(true);

    }

    public void CloseUISetting()
    {
        uiSetting.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    

}
