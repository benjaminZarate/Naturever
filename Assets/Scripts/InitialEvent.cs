using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitialEvent : MonoBehaviour
{
    [SerializeField] [TextArea] List<string> events = null;
    [SerializeField] TextMeshProUGUI eventText = null;
    int index = 0;

    [SerializeField] GameObject previousPage = null;
    [SerializeField] GameObject nextPage = null;
    [SerializeField] GameObject closeButton = null;

    [SerializeField] AudioSource page = null;

    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        JoystickController.canSelect = false;
        _anim.Play("Narrative_IN");
        page.Play();
        eventText.text = events[0];
    }

    public void NextPage() {
        index++;
        if (!previousPage.activeSelf) previousPage.SetActive(true);
        if (index >= events.Count - 1) {
            nextPage.SetActive(false);
            closeButton.SetActive(true);
        }

        eventText.text = events[index];
    }

    public void PreviousPage() {
        index--;
        closeButton.SetActive(false);
        if (!nextPage.activeSelf) nextPage.SetActive(true);
        if (index <= 0) {
            index = 0;
            previousPage.SetActive(false);
        }
        eventText.text = events[index];
    }

    public void ClosePanel() {
        closeButton.SetActive(false);
        page.Play();
        _anim.Play("Narrative_Out");
        JoystickController.canSelect = true;
    }

}
