using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelection : MonoBehaviour
{
    public Image option1 = null;
    public Image option2 = null;

    [SerializeField] float fillSpeed = 1;

    [SerializeField] DecisionsAssign decisions = null;
    [SerializeField] RoundEvents events = null;
    [SerializeField] BigEvents bigEvents = null;

    bool stop = false;
    [SerializeField] AudioSource click = null;

    public void SelectionOption(Image option, string message) {
        option.fillAmount += fillSpeed * Time.deltaTime;

        if (!click.isPlaying) click.Play();

        if (option.fillAmount >= 1) {
            if (stop) return;
            decisions.SendMessage(message);
            events.CallEvent();
            bigEvents.ChangeStation();
            bigEvents.HunterRound();
            stop = true;
        }
    }

    public void ResetOptions() {
        option1.fillAmount = 0;
        option2.fillAmount = 0;
        stop = false;
        if (click.isPlaying) click.Stop();
    }
}
