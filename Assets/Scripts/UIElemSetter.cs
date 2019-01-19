using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIElemSetter : MonoBehaviour {

    public Image imageUI;
    public Text numberUI;

    public Sprite leftArrow;
    public Sprite rightArrow;
    public Sprite forwardArrow;
    public int number;

    private void SetArrow(Sprite spriteArrow)
    {
        imageUI.sprite = spriteArrow;
    }

    public void SetLeftArrow()
    {
        SetArrow(leftArrow);
    }
    public void SetRightArrow()
    {
        SetArrow(rightArrow);
    }
    public void SetForwardArrow()
    {
        SetArrow(forwardArrow);
    }

    public void SetNumber(int number)
    {
        if (number != 0)
            numberUI.text = number.ToString();
        else
            numberUI.text = "";
    }
}
