using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{

    public Joystick joystick;
    public OptionSelection option;

    public static bool canSelect = true;

    private void Update()
    {

        Selection();
    }

    void Selection() {
        if (joystick.Horizontal >= 0.8f)
        {
            if(canSelect) option.SelectionOption(option.option2, "Option2");
        }
        else if (joystick.Horizontal <= -0.8f)
        {
            if(canSelect) option.SelectionOption(option.option1, "Option1");
        }
        else
        {
            option.ResetOptions();
        }
    }
}
