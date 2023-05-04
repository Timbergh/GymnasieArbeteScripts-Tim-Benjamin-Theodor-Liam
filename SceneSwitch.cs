using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public Object sceneToLoad;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(sceneToLoad.name);
        }
    }
}
