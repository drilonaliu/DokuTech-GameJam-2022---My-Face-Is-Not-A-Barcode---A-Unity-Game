using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinRadius : MonoBehaviour
{

    public Transform winPoint;
    public float winRange = 1f;
    public LayerMask playerLayer;
    public WinRadiusDelegate winDelegate;
    public bool win = false;

    // Update is called once per frame
    void Update()
    {
        Win();
    }

    void Win()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(winPoint.position, winRange, playerLayer);

        if (hitPlayer.Length > 0 && !win)
        {
            winDelegate.playerWon();
            win = true;
        }
        //foreach (Collider2D player in hitPlayer)
        //{
        //    winDelegate.playerWon();
        //}
    }


    void OnDrawGizmosSelected()
    {
        if (winPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(winPoint.position, winRange);
    }
}