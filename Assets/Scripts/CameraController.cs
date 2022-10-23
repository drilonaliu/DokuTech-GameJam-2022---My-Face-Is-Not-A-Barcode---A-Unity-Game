using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject HealthBar;
    public Camera camera;
    public Transform centerPoint;
    public int zoom_in_size;
    public int zoom_out_size;
    private bool update = true;


    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
        Debug.Log(camera.gateFit + " gateFit");
        Debug.Log(camera.orthographicSize + " otrhoSize");
    }

    public void zoomOut()
    {
        StartCoroutine(zoomOutRoutine());
    }

    public void zoomIn()
    {
        update = true;
        StartCoroutine(zoomInRoutine());
    }

    // Update is called once per frame
    void Update()
    {


        //moving health bar with camera and player
        //HealthBar.transform.position = new Vector3(player.transform.position.x -3,-6,0); 
        if(update){
        transform.position = player.transform.position + new Vector3(0, 0, -5);
        transform.position = player.transform.position + new Vector3(0, 0, -5);
        transform.position = player.transform.position + new Vector3(0, 0, -15);
        }
    }


    IEnumerator zoomOutRoutine()
    {
        update = false;
            transform.position = centerPoint.transform.position;
            yield return new WaitForSeconds(0.01f);
            if (camera.orthographicSize < zoom_out_size)
            {
                camera.orthographicSize += 0.2f;
                zoomOut();
            }
    }

    IEnumerator zoomInRoutine()
    {
        update = true;
            yield return new WaitForSeconds(0.01f);
            if (camera.orthographicSize > zoom_in_size)
            {
                camera.orthographicSize -= 0.2f;
                zoomIn();
            }
    }
}
