using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{

    public LightDelegate lightDelegate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lightDelegate.playerInLight(this);
        }
    }


}

