using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionsAssign : MonoBehaviour
{
    public Cards cards = null;

    [Header("Textos de las decisiones")]
    [SerializeField] TextMeshProUGUI decision = null;
    [SerializeField] TextMeshProUGUI option1 = null;
    [SerializeField] TextMeshProUGUI option2 = null;

    [Space]
    [SerializeField] Stats stats = null;
    [SerializeField] CardsList pools = null;

    private void Start()
    {
        AssignText();
    }

    public void AssignText() {
        decision.text = cards.decision;
        option1.text = cards.textOption1;
        option2.text = cards.textOption2;
    }

    public void Option1() {
        stats.SendMessage(cards.message1, cards.amount1);
        stats.SendMessage(cards.message2, cards.amount2);
        pools.SelectRandomCard();
    }

    public void Option2() {
        stats.SendMessage(cards.message3, cards.amount3);
        stats.SendMessage(cards.message4, cards.amount4);
        pools.SelectRandomCard();
    }
}
