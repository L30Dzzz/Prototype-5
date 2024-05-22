using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public float currentVolume;
    public AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = 1;
        volumeSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
        Debug.Log(volumeSlider.value);
    }

    //check volume lvl/val
    void ValueChangeCheck()
    {
        gameAudio.volume = volumeSlider.value;
        Debug.Log(volumeSlider.value);
    }
}
