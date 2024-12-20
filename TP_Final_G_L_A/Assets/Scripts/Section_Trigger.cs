using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section_Trigger : MonoBehaviour
{
    // All Credits for https://www.youtube.com/@RigorMortisTortoise
    [SerializeField] private GameObject roadSection;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Section_Trigger"))
        {
            Instantiate(roadSection, new Vector3(0,0, ((roadSection.transform.localScale.z * 4 ) * 4)), Quaternion.identity);
        }
    }
}
