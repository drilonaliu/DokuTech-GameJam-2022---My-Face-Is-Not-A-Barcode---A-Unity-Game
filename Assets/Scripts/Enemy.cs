using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public FieldOfView fov;
    private int count = 0;
    private int start_z;
    private int clockwiseCount = 0;


    void Start()
    {
        start_z = (int)this.transform.rotation.eulerAngles.z;
    }

    private bool case_1 = true;
    private bool case_2 = false;
    private bool case_3 = false;
    private bool case_4 = false;
    private bool stop = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(0.1f);
        Rotator();
    }


    void Rotator()
    {
        if (!stop)
        {
            count += 1;
            //if (count == 10)
            //{
                count = 0;
                if (case_1)
                {
                    int rotoate_z = (int)this.transform.rotation.eulerAngles.z;
                    this.transform.Rotate(new Vector3(0, 0, 1f));
                    clockwiseCount++;
                    if (clockwiseCount > 45) // 
                    {
                        case_1 = false;
                        case_2 = true;
                    }

                }

                if (case_2)
                {
                    int rotoate_z = (int)this.transform.rotation.eulerAngles.z;
                    this.transform.Rotate(new Vector3(0, 0, -1f));
                    clockwiseCount--;
                    if (clockwiseCount == 0)
                    {
                        case_2 = false;
                        case_3 = true;
                    }
                }

                if (case_3)
                {
                    int rotoate_z = (int)this.transform.rotation.eulerAngles.z;
                    this.transform.Rotate(new Vector3(0, 0, -1f));
                    clockwiseCount--;
                    if (clockwiseCount < -45)
                    {
                        case_3 = false;
                        case_4 = true;
                    }
                }

                if (case_4)
                {
                    int rotoate_z = (int)this.transform.rotation.eulerAngles.z;
                    this.transform.Rotate(new Vector3(0, 0, 1f));
                    clockwiseCount++;
                    if (clockwiseCount == 0)
                    {
                        case_4 = false;
                        case_1 = true;
                    }
                }
            //}
        }
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    public void enableMovement()
    {
        stop = false;
    }

    public void StopMoving()
    {
        stop = true;
    }

    public FieldOfView getFieldOfView(){
        return fov;
    }
}
