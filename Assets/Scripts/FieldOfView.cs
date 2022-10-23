using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public FOVDelegate fovDelegate;
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject light;
    public List<Color> colors = new List<Color>();
    

    private float attackSpeed = 1f;
    private float currentTime;

    public GameObject playerRef;

    public bool CanSeePlayer { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        ChangeColor();
        FOV();
    }



    void ChangeColor()
    {
        if (CanSeePlayer)
        {
            light.GetComponent<SpriteRenderer>().color = colors[1];
        }
        else
            light.GetComponent<SpriteRenderer>().color = colors[0];
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    CanSeePlayer = true;
                    if(Time.time > currentTime + 1/attackSpeed)
                    {
                            fovDelegate.CanSeePlayer(); 
                            currentTime = Time.time;
                    }
                
                }
                else
                    CanSeePlayer = false;
            }
            else
                CanSeePlayer = false;
        }
        else if (CanSeePlayer)
            CanSeePlayer = false;
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.white;
    //    UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);
    //    Vector3 angle1 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
    //    Vector3 angle2 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);
    //    Gizmos.DrawLine(transform.position, transform.position + angle1 * radius);
    //    Gizmos.DrawLine(transform.position, transform.position + angle2 * radius);

    //    if (CanSeePlayer)
    //    {
    //        Gizmos.DrawLine(transform.position, playerRef.transform.position);
    //        }

    //}

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
