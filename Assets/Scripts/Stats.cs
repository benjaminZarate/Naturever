using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float animals = 50;
    public float water = 50;
    public float food = 50;
    public float temperature = 50;

    [Header("Relleno de las estadisticas")]
    [SerializeField] Image animalSprite = null;
    [SerializeField] Image waterSprite = null;
    [SerializeField] Image foodSprite = null;
    [SerializeField] Image temperatureSprite = null;

    [Header("LineArt estado bajo")]
    [SerializeField] Image animalLineArt = null;
    [SerializeField] Image waterLineArt = null;
    [SerializeField] Image foodLineArt = null;
    [SerializeField] Image temperatureLineArt = null;

    [Header("Sprites LineArt Low")]
    [SerializeField] Sprite animalLow = null;
    [SerializeField] Sprite waterLow = null;
    [SerializeField] Sprite foodLow = null;
    [SerializeField] Sprite temperatureLow = null;

    [Header("Sprites LineArt normal")]
    [SerializeField] Sprite animalNormal = null;
    [SerializeField] Sprite waterNormal = null;
    [SerializeField] Sprite foodNormal = null;
    [SerializeField] Sprite temperatureNormal = null;

    [SerializeField] GameObject statsPopup = null;
    [SerializeField] GameOver gameover = null;

    public void ChangeAnimals(float amount) {
        if (animals < 100) {
            animals += amount;
            animalSprite.fillAmount = animals / 100;
            GameObject popup = Instantiate(statsPopup, animalSprite.transform.position, Quaternion.identity);
            popup.GetComponent<StatsPopUp>().Setup(amount);
        }

        if (animals <= 10)
        {
            animalLineArt.sprite = animalLow;
        }
        else {
            animalLineArt.sprite = animalNormal;
        }
        if (animals <= 0) {
            gameover.gameObject.SetActive(true);
            gameover.Fade();
        }
    }

    public void ChangeWater(float amount) {
        if (water < 100) {
            water += amount;
            waterSprite.fillAmount = water / 100;
            GameObject popup = Instantiate(statsPopup, waterSprite.transform.position, Quaternion.identity);
            popup.GetComponent<StatsPopUp>().Setup(amount);
        }

        if (water <= 10)
        {
            waterLineArt.sprite = waterLow;
        }
        else {
            waterLineArt.sprite = waterNormal;
        }
        if (water <= 0)
        {
            gameover.gameObject.SetActive(true);
            gameover.Fade();
        }
    }

    public void ChangeFood(float amount) {
        if (food < 100) { 
            food += amount;
            foodSprite.fillAmount = food / 100;
            GameObject popup = Instantiate(statsPopup, foodSprite.transform.position, Quaternion.identity);
            popup.GetComponent<StatsPopUp>().Setup(amount);
        }

        if (food <= 10)
        {
            foodLineArt.sprite = foodLow;
        }
        else {
            foodLineArt.sprite = foodNormal;
        }
        if (food <= 0)
        {
            gameover.gameObject.SetActive(true);
            gameover.Fade();
        }
    }

    public void ChangeTemperature(float amount) {
        if (temperature < 100) { 
            temperature += amount;
            temperatureSprite.fillAmount = temperature / 100;
            GameObject popup = Instantiate(statsPopup, temperatureSprite.transform.position, Quaternion.identity);
            popup.GetComponent<StatsPopUp>().Setup(amount);
        }

        if (temperature <= 10)
        {
            temperatureLineArt.sprite = temperatureLow;
        }
        else {
            temperatureLineArt.sprite = temperatureNormal;
        }
        if (temperature <= 0)
        {
            gameover.gameObject.SetActive(true);
            gameover.Fade();
        }
    }
}
