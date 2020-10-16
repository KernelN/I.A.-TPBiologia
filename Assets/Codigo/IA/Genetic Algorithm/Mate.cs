using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour
{
    public bool Reproduce;
    public GameObject Partner;

    private void OnTriggerStay(Collider other)
    {
        if (transform.parent.name == other.transform.name) 
        {
            if (GetComponentInParent<DNA>().species == other.gameObject.GetComponent<DNA>().species)
            {
                Reproduce = true;
                Partner = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.parent.name == other.transform.name)
        {
            if (GetComponentInParent<DNA>().species == other.gameObject.GetComponent<DNA>().species) 
            {
                Reproduce = true;
                Partner = other.gameObject;
            }
        }
    }
}
