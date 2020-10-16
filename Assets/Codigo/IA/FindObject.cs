using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
    public float Diet;
    string ParentName;
    GameObject Parent;

    void Start()
    {

        ParentName = transform.parent.name;
        Parent = transform.parent.gameObject;
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        Diet = ScriptDNA.Diet;
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.StartLeftRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));

        if (ScriptDNA.Diet < 0.6f)
        {
            if (other.gameObject.tag == "Plant")
            {
                TargetFound();
            }
        }
        else if (ScriptDNA.Diet > 0.4f)
        {
            if (other.gameObject.tag == "Animal" && ScriptDNA.species != other.gameObject.GetComponent<DNA>().species)
            {
                TargetFound();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));

        if (ScriptDNA.Diet < 0.6f)
        {
            if (other.gameObject.tag == "Plant")
            {
                TargetLost();
            }
        }
        else if (ScriptDNA.Diet > 0.4f)
        {
            if (other.gameObject.tag == "Animal" && ScriptDNA.species != other.gameObject.GetComponent<DNA>().species)
            {
                TargetLost();
            }
        }
    }
       

    void TargetLost()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.EndMove();
        ScriptMove.StartLeftRotation();
    }
    
    void TargetFound()
    {
        Move ScriptMove = (Move)Parent.GetComponent(typeof(Move));
        ScriptMove.EndRotation();
        ScriptMove.StartMove();
    }
}
