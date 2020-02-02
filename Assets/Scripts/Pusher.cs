using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float speed;
    int tpIndex;
    public TravelPoint[] travelPoints;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, travelPoints[tpIndex].pos, speed);

        if (Vector3.Distance(transform.position, travelPoints[tpIndex].pos) < 0.1f)
        {
            tpIndex++;
            if (tpIndex == travelPoints.Length)
            {
                tpIndex = 0;
            }
        }
    }

    [System.Serializable]
    public struct TravelPoint
    {
        public Vector3 pos;
        public float stayTime;
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < travelPoints.Length; i++)
        {
            Gizmos.DrawSphere(travelPoints[i].pos, 0.1f);
        }
    }
}