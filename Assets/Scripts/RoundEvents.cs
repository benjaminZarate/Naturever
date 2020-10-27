using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RoundEvents : MonoBehaviour
{
    [SerializeField] int roundsAmount = 5;
    int roundCounter = 0;

    float animals = 0;
    float food = 0;
    float temperature = 0;
    float water = 0;

    [SerializeField] Stats stats = null;
    [SerializeField] NarrativeText narrative = null;
    [SerializeField] BigEvents bigEvents = null;

    [Header("Textos del panel")]
    [SerializeField] TextMeshProUGUI animalsText = null;
    [SerializeField] TextMeshProUGUI foodText = null;
    [SerializeField] TextMeshProUGUI waterText = null;
    [SerializeField] TextMeshProUGUI eventText = null;

    [SerializeField] GameObject closeButton = null;
    [SerializeField] AudioSource page = null;

    Animator _anim;

    private void Start()
    {
        AssignValues();
        _anim = GetComponent<Animator>();
    }

    public void CallEvent() {
        roundCounter++;
        bigEvents.roundCounter++;
        if (roundCounter >= roundsAmount) {
            SelectionEvent();
            roundCounter = 0;
            AssignValues();
            _anim.Play("Narrative_IN");
            page.Play();
            JoystickController.canSelect = false;
        }
    }

    void AssignValues() {
        animals = stats.animals;
        food = stats.food;
        temperature = stats.temperature;
        water = stats.water;
    }

    void SelectionEvent() {

        if (bigEvents.index < bigEvents.eventRound.Length) {
            Debug.Log("Event round" + bigEvents.eventRound[bigEvents.index]);
            Debug.Log("Current Round" + bigEvents.roundCounter);
            if (bigEvents.roundCounter == bigEvents.eventRound[bigEvents.index]) {
                Debug.Log("Events");
                EventAssign();
                return;
            }
        }

        TextAssign(animals, stats.animals, narrative.animalsGood, narrative.animalsBad, animalsText);
        TextAssign(food, stats.food, narrative.foodGood, narrative.foodBad, foodText);
        //TextAssign(temperature, stats.temperature, narrative.temperatureGood, narrative.temperatureBad, temperatureText);
        TextAssign(water, stats.water, narrative.waterGood, narrative.waterBad, waterText);
    }

    void EventAssign() {

        eventText.gameObject.SetActive(true);
        animalsText.gameObject.SetActive(false);
        foodText.gameObject.SetActive(false);
        waterText.gameObject.SetActive(false);
        //temperatureText.gameObject.SetActive(false);

        eventText.text = narrative.eventText[bigEvents.index];

        bigEvents.index++;
    }

    void TextAssign(float initialAmount, float currentAmount, string[] good, string[] bad, TextMeshProUGUI text) {

        /*if (initialAmount == currentAmount) {
            text.gameObject.SetActive(false);
            return;
        }*/
        if(!text.gameObject.activeSelf) text.gameObject.SetActive(true);
        int randomGood = Random.Range(0, good.Length);
        int randomBad = Random.Range(0,bad.Length);


        if (initialAmount <= currentAmount)
        {
            text.text = "-"+good[randomGood];
        }
        else if(initialAmount > currentAmount) {
            text.text = "-"+ bad[randomBad];
        }
    }

    public void CloseNarrative() {
        _anim.Play("Narrative_Out");
        page.Play();
        JoystickController.canSelect = true;
        closeButton.SetActive(false);
        eventText.gameObject.SetActive(false);
    }

    public void ActivateButton() {
        closeButton.SetActive(true);
    }
}
