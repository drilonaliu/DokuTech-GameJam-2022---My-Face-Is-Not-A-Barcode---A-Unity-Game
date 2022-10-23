using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages : MonoBehaviour
{
    public TextMeshProUGUI  winText;

    public void hide()
    {
        this.gameObject.SetActive(false);
    }

    public void show(bool win)
    {
        this.gameObject.SetActive(true);
        if (win)
        {
            winText.text = "win!";
        }
        else
        {
            winText.text = "lost!";
        }
    }
}
