using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, FOVDelegate, WinRadiusDelegate // , LightDelegate
{
    public Player player;
    public List<Enemy> enemies = new List<Enemy>(4);
    public FieldOfView fov;
    public CameraController camera;
    public Messages messages;
    public WinRadius winRadius;
    public GameObject playAgainButton;
    private int countdown = 10;
    private bool update = true;

    void Start()
    {

        //setting delegates 
        winRadius.winDelegate = this;
        messages.hide();
        foreach (Enemy enemy in enemies)
        {
            enemy.getFieldOfView().fovDelegate = this;
        }
        playAgainButton.SetActive(false);
    }

    void Update()
    {
        if (isGameOver() && update)
        {
            endGame(false);
        }
    }

    void endGame(bool win)
    {
        player.reset();
        messages.show(win);
        camera.zoomOut();
        playAgainButton.SetActive(true);
        //  enemy.StopMoving();
        update = false;
            player.hideHearts();
    
    }

    public void resetGame()
    {
        player.showHearts();
        messages.hide();
        camera.zoomIn();
        playAgainButton.SetActive(false);
        //  enemy.enableMovement();
        player.reset();
        update = true;
        winRadius.win = false;
    }

    bool isGameOver()
    {
        if (!player.isDead())
        {
            return false;
        }
        else
        {
            return true;
        }

    }


    //Interface methods 

    void FOVDelegate.CanSeePlayer()
    {
        player.removeHeart();
    }

    void WinRadiusDelegate.playerWon(){
        endGame(true);
    }
}

