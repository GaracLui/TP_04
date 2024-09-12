using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Trigger : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Section_Trigger"))
        {
            Instantiate(roadSection, new Vector3(0,0, 75), Quaternion.identity);
        }
    }
}
