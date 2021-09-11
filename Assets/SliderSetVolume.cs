using UnityEngine;
using UnityEngine.Audio;

public class SliderSetVolume : MonoBehaviour
{

    public AudioMixer mixer;

    public void SetLevel(float sliderVol)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderVol) + 20);
    }
}
