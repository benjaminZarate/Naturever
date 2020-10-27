using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEvents : MonoBehaviour
{
    [SerializeField] int winterRound = 10;
    [SerializeField] int hunterRound = 20;
    public float roundCounter = 0;

    bool isWinter = false;

    [SerializeField] CardsList cards = null;
    [SerializeField] Stats stats = null;

    [SerializeField] SpriteRenderer background = null;
    [SerializeField] Sprite winterBackground = null;
    [SerializeField] GameObject temperatureGO = null;

    [SerializeField] ParticleSystem spring = null;
    [SerializeField] ParticleSystem winter = null;

    [Header("Ronda en la que ocurre un evento grande")]
    public int[] eventRound;
    public int index;

    [Header("Pools de decisiones Invierno")]
    [SerializeField] List<Cards> winterAnimalsPool = null;
    [SerializeField] List<Cards> winterWaterPool = null;
    [SerializeField] List<Cards> winterFoodPool = null;
    [SerializeField] List<Cards> winterTemperaturePool = null;


    void WinterPool() {
        cards.animalsPool = winterAnimalsPool;
        cards.waterPool = winterWaterPool;
        cards.foodPool = winterFoodPool;
        cards.temperaturePool = winterTemperaturePool;
    }

    public void ChangeStation()
    {
        if (isWinter) return;
        if (roundCounter == winterRound) {
            isWinter = true;
            WinterPool();
            background.sprite = winterBackground;
            background.transform.localScale = new Vector2(1.1f,1.5f);
            temperatureGO.SetActive(true);
            MusicManager.changeMusic = true;
            spring.Stop();
            winter.Play();
        }
    }

    public void HunterRound() {
        if (roundCounter == hunterRound) {
            stats.ChangeAnimals(-5);
        }
    }
}
