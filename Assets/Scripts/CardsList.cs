using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsList : MonoBehaviour
{
    [SerializeField] DecisionsAssign decisions = null;

    [Header("Pools de decisiones")]
    public List<Cards> animalsPool = null;
    public List<Cards> waterPool = null;
    public List<Cards> foodPool = null;
    public List<Cards> temperaturePool = null;

    List<Cards> currentPool = null;

    private void Start()
    {
        int newPool = Random.Range(0, 3);

        AssignPool(newPool);

        SelectRandomCard();
    }

    public void SelectRandomCard() {
        int random = Random.Range(0, currentPool.Count);
        int randomPool = Random.Range(0, 3);
        List<Cards> newPool = currentPool;

        while (newPool == currentPool) {
            randomPool = Random.Range(0, 3);
            AssignPool(randomPool);
        }
        decisions.cards = currentPool[random];
        decisions.AssignText();
    }

    public void AssignPool(int pool) {
        switch (pool)
        {
            case 0:
                currentPool = animalsPool;
                break;
            case 1:
                currentPool = waterPool;
                break;
            case 2:
                currentPool = foodPool;
                break;
            case 3:
                currentPool = temperaturePool;
                break;
        }
    }
}
