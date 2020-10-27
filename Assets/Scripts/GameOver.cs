using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Stats stats = null;
    [SerializeField] MusicManager manager = null;
    [SerializeField] TextMeshProUGUI gameOverText = null;
    [SerializeField] [TextArea] string gameover = "";


    [SerializeField] AudioSource music = null;

    Animator _anim;
    private bool over = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        over = false;
    }

    private void Update()
    {
        if (over) {
            manager.LowerVolume(manager.spring);
            manager.LowerVolume(manager.winter);
            manager.RaiseVolume(music);
        }
    }

    public void AssignText() {
        gameOverText.text = gameover;

    }

    public void Fade() {
        gameOverText.gameObject.SetActive(true);
        _anim.Play("Fade_Out_Gameover");
        over = true;
        music.Play();
    }

    public void ActivateButton() {
        this.GetComponent<Button>().enabled = true;
    }

    public void GoMenu() {
        SceneManager.LoadScene("Menu");
    }

}
