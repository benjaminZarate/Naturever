using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioSource spring = null;
    public AudioSource winter = null;

    [SerializeField] float volumeSpeed = 1;

    public static bool changeMusic = false;

    public void LowerVolume(AudioSource mixer) {
        if (mixer.volume <= 0) return;
        mixer.volume -= volumeSpeed * Time.deltaTime;
    }

    public void RaiseVolume(AudioSource mixer) {
        if (mixer.volume >= 1) {
            changeMusic = false;
        }
        mixer.volume += volumeSpeed * Time.deltaTime;
    }

    private void Update()
    {
        if (changeMusic) {
            LowerVolume(spring);
            RaiseVolume(winter);
        }
    }
}
