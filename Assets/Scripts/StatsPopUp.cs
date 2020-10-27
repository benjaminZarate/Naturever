using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPopUp : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] float moveYSpeed = 20;
    [SerializeField] Transform parent;

    float disappearTimer = 1;
    Color textColor;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        parent = GameObject.FindGameObjectWithTag("Canvas").transform;
        textMesh.transform.SetParent(parent);
    }

    public void Setup(float amount) {
        if (amount > 0)
        {
            textMesh.text = "+" + amount.ToString();
            textColor = Color.green;
        }
        else {
            textMesh.text = amount.ToString();
            textColor = Color.red;
        }
        textMesh.color = textColor;
    }

    private void Update()
    {
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0) {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
