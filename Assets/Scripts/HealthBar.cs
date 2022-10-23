using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform heart_prefab;
    public List<Transform> heart_list;

    public void Start()
    {
        heart_list = new List<Transform>();
        for (int i = 0; i < 3; i++)
        {
            Transform go = Instantiate(this.heart_prefab);
            go.transform.parent = this.transform;
            go.transform.position =  new Vector3(this.transform.position.x + 2 * i, this.transform.position.y, 0);
            heart_list.Add(go);
        }
    }

    public void reset()
    {
        clearAllHearts();
        Start();
    }
    public void removeHeart()
    {
        Destroy(heart_list[heart_list.Count - 1].transform.gameObject);
        heart_list.RemoveAt(heart_list.Count - 1);
    }

    private void clearAllHearts()
    {
        foreach (Transform go in heart_list)
        {
            Destroy(go.transform.gameObject);
        }
        heart_list.Clear();
    }

    public int lifeAmount()
    {
        return heart_list.Count;
    }
}
