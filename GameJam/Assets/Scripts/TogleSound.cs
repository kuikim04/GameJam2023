using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogleSound : MonoBehaviour
{
    public bool _bgmTogle, _sfxTogle;

    public void Togle()
    {
        if (_bgmTogle) {
            SoundManager.Instance.TogleMusic();
            SoundManager.Instance.BGMisMute = !SoundManager.Instance.BGMisMute;
        }
        if (_sfxTogle) {
            SoundManager.Instance.TogleSFX();
            SoundManager.Instance.SFXisMute = !SoundManager.Instance.SFXisMute;
        }

    }
}
