using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private static CollectableManager s_Instance = null;

    public static CollectableManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(CollectableManager)) as CollectableManager;
            }

            if (s_Instance == null)
            {
                var obj = new GameObject("CollectableManager");
                s_Instance = obj.AddComponent<CollectableManager>();
            }

            return s_Instance;
        }
    }

    public int collRequirement;
    public int collected = 0;
    public bool triggered = false;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (collected >= collRequirement && !triggered)
        {
            Debug.Log("TRIGGERED");
            GateScript.instance.SetOpen(true);
            triggered = true;
        }
    }

    public void IncreaseCount(int amount)
    {
        collected += amount;
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }
}
