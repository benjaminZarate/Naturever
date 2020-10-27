using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fades : MonoBehaviour
{
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        ActivateThis();
    }

    public void ChangeScene() {
        SceneManager.LoadScene("SampleScene");
    }

    public void DeactivateThis() {
        this.gameObject.SetActive(false);
    }

    public void ActivateThis() {
        _anim.Play("Fade_In");
    }

    public void FadeScene() {
        this.gameObject.SetActive(true);
        _anim.Play("Fade_Out");
    }
}
