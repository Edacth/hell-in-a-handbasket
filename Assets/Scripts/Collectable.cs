using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            other.GetComponent<AudioScript>().PlaySlurp();
            CollectableManager.instance.IncreaseCount(1);
            gameObject.SetActive(false);
        }
    }
}
