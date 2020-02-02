using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string sceneName;

    void Update()    {
        
    }

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
