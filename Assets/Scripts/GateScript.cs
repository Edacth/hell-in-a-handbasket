using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Animator animator;
    public void SetOpen(bool isOpen)
    {
        animator.SetBool("Open", isOpen);
        Debug.Log("Am I open? " + isOpen);
    }

    private void Start()
    {
        animator.SetBool("Open", false);
    }

    #region Singleton
    private static GateScript s_Instance = null;

    public static GateScript instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(GateScript)) as GateScript;
            }

            if (s_Instance == null)
            {
                var obj = new GameObject("GateScript");
                s_Instance = obj.AddComponent<GateScript>();
            }

            return s_Instance;
        }
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }
    #endregion
}
