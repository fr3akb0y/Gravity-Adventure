using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour {

    public Slider VolumeSlider;
    public Text VolumeText;

    private void Start()
    {
        float volume = GameState.GameVolume;
        VolumeTextChanger(volume);
        VolumeSlider.value = volume;
    }

	public void SoundsVolumeChanger()
    {
        float volume = VolumeSlider.value;
        VolumeTextChanger(volume);
        AudioListener.volume = (volume / 100);
        GameState.GameVolume = volume;
    }

    private void VolumeTextChanger(float volume)
    {
        VolumeText.text = volume + "%";
    }
}
