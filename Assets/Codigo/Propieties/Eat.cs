using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    Rigidbody rb;
    GameObject Parent;
    float BodyOriginalEnergy;
    float BodyNewEnergy;
    string BodyName;

    private void Start()
    {
        Parent = transform.parent.gameObject;
        DNA ScriptDNA = (DNA)Parent.GetComponent(typeof(DNA));
        Energy ScriptEnergy = (Energy)Parent.GetComponent(typeof(Energy));

        BodyOriginalEnergy = ScriptEnergy.energy;
        BodyName = transform.parent.name;
    }


    private void OnTriggerStay(Collider other)
    {
        Move ScriptMove = (Move)transform.parent.gameObject.GetComponent(typeof(Move));
        DNA ScriptDNA = (DNA)transform.parent.gameObject.GetComponent(typeof(DNA));
        Energy ScriptEnergy = (Energy)Parent.GetComponent(typeof(Energy));


        if (other.gameObject.tag == "Plant" && ScriptDNA.Diet < 0.6f)
        {
            ScriptMove.EndMove();

            ScriptEnergy.energy += BodyOriginalEnergy / 250;
            other.GetComponent<Energy>().energy -= BodyOriginalEnergy / 200;

            if (other.GetComponent<Energy>().energy <= 1000)
            {
                ScriptMove.StartLeftRotation();
            }
        }

        else if (other.gameObject.tag == "Animal" && ScriptDNA.Diet < 0.4f && ScriptDNA.species != other.gameObject.GetComponent<DNA>().species)
        {
            ScriptMove.EndMove();

            ScriptEnergy.energy += other.GetComponent<Energy>().energy;
            other.GetComponent<Energy>().energy -= BodyOriginalEnergy;

            if (other.GetComponent<Energy>().energy <= 1000)
            {
                ScriptMove.StartLeftRotation();
            }
        }
    }
}
