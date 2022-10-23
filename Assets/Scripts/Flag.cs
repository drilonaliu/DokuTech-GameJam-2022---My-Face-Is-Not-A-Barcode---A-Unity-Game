using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    public FlagDelegate flagDelegate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            flagDelegate.playerTouchedFlag();
        }
    }
};


