using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DNA : MonoBehaviour
{
    public float species;
    public bool Kingdom; //true equals plant, false animal
    public float Diet; //0 - 0.4 equals herbivore, 0.4 - 0.6 equals omnivore, 0.6 - 1 equals carnivore
    public float StartingEnergy;


    public void FirstGen()
    {
        StartingEnergy = Random.Range(2500, 10000);
        if (!Kingdom)
        {
            Diet = Random.value;
        }        
    }
            
    public void Son (GameObject parent, GameObject partner, float mutationRate = 0.3f)
    {

        float mutationChance = Random.value;

        if (mutationChance <= mutationRate)
        {
            if (!Kingdom)
            {
                if (Random.value > 0.5f)
                {
                    Diet = (parent.GetComponent<DNA>().Diet + partner.GetComponent<DNA>().Diet) / 2 + Random.Range(-0.05f, 0.05f);
                    StartingEnergy = (parent.GetComponent<DNA>().StartingEnergy + partner.GetComponent<DNA>().StartingEnergy) / 2;
                }
                else
                {
                    Diet = (parent.GetComponent<DNA>().Diet + partner.GetComponent<DNA>().Diet) / 2;
                    StartingEnergy = (parent.GetComponent<DNA>().StartingEnergy + partner.GetComponent<DNA>().StartingEnergy) / 2 + Random.Range(-0.05f, 0.05f);
                }

                GetComponent<Move>().StartLeftRotation();
            } //if is an animal
            else
            {
                StartingEnergy = (parent.GetComponent<DNA>().StartingEnergy + partner.GetComponent<DNA>().StartingEnergy) / 2 + Random.Range(-0.05f, 0.05f);
            } // if is a plant

        }
        else
        {
            if (!Kingdom)
            {
                Diet = (parent.GetComponent<DNA>().Diet + partner.GetComponent<DNA>().Diet) / 2;
                StartingEnergy = (parent.GetComponent<DNA>().StartingEnergy + partner.GetComponent<DNA>().StartingEnergy) / 2;

                GetComponent<Move>().StartLeftRotation();
            } //if is an animal
            else
            {
                StartingEnergy = (parent.GetComponent<DNA>().StartingEnergy + partner.GetComponent<DNA>().StartingEnergy) / 2;
            } // if is a plant
        }
    }
}





