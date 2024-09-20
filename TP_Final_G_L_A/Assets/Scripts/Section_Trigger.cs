using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Trigger : MonoBehaviour
{
    // All Credits for https://www.youtube.com/@RigorMortisTortoise
    public GameObject roadSection;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Section_Trigger"))
        {
            Instantiate(roadSection, new Vector3(0,0, ((roadSection.transform.localScale.z * 5 ) * 2)), Quaternion.identity);
        }
    }
}
