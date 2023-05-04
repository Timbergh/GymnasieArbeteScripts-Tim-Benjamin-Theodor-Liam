using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    Light2D light;
    public float minSpeed = 0.1f;
    public float maxSpeed = 0.5f;
    public float minIntensity = 0.01f;
    public float maxIntensity = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for (; ; ) //this is while(true)
        {
            float randomIntensity = Random.Range(minIntensity, maxIntensity);
            light.intensity = randomIntensity;


            float randomTime = Random.Range(minSpeed, maxSpeed);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
