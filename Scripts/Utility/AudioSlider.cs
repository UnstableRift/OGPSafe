using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    //https://www.youtube.com/watch?v=xNHSGMKtlv4
    public AudioMixer _musicMixer;
    [SerializeField] private string _exposedpram;
    // Start is called before the first frame update
    public void SetLevel(float sliderV)
    {
        _musicMixer.SetFloat(_exposedpram, Mathf.Log10(sliderV) * 20);
    }
}
