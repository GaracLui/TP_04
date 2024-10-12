using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveChanger : MonoBehaviour
{
    // All credits for https://www.youtube.com/@RigorMortisTortoise
    public Material[] myMaterials;

    private float currentValueX;
    private float targetValueX;

    private float currentValueY;
    private float targetValueY;

    public float lerpTime;
    private bool isComplete = true;


    private float timeBetweenDoingSomething = 5f;  //Wait 5 seconds after we do something to do something again
    private float timeWhenWeNextDoSomething;  //The next time we do something



    private void Start()
    {
        foreach(Material material in myMaterials)
        {
            currentValueX = material.GetFloat("_Sideway_Strength");
            currentValueY = material.GetFloat("_Backward_Strength");
        }

        timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
    }

    void Update()
    {
        if (timeWhenWeNextDoSomething <= Time.time)
        {
            //Do something here

            timeWhenWeNextDoSomething = Time.time + timeBetweenDoingSomething;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (isComplete)
            {
                StartCoroutine(changeCurveStrength());
            }
    }

    public IEnumerator changeCurveStrength()
    {
        float elapsedTime = 0;
        targetValueX = Random.Range(-.005f,.005f);
        targetValueY = Random.Range(-.001f, .001f);

        while (elapsedTime < lerpTime)
        {
            isComplete = false;

            currentValueX = Mathf.Lerp(currentValueX, targetValueX, elapsedTime / lerpTime);
            currentValueY = Mathf.Lerp(currentValueY, targetValueY, elapsedTime / lerpTime);
            elapsedTime += Time.deltaTime;

            foreach (Material material in myMaterials)
            {
                material.SetFloat("_Sideway_Strength", currentValueX);
                material.SetFloat("_Backward_Strength", currentValueY);
            }

            yield return null;
        }

        isComplete = true;
        currentValueX = targetValueX;
        currentValueY = targetValueY;
    }
}
