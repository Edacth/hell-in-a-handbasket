using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    public GameObject subject;
    public float YLevel;
    public Vector3 startPoint;
    GameObject[] collectables;
    void Start()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");
    }

    void FixedUpdate()
    {
        if (subject.transform.position.y < YLevel)
        {
            subject.transform.position = startPoint;
            
            for (int i = 0; i < collectables.Length; i++)
            {
                collectables[i].SetActive(true);            }
        }
    }
}
