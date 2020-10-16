using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public int populationSize = 100;

    public GameObject PlantPrefab;
    public GameObject AnimalPrefab;
    GameObject Agent01;
    GameObject Agent02;





    void Awake()
    {
        for (int i = 0; i < populationSize; i++)
        {
            Vector3 v3 = new Vector3(Random.Range(-9.5f, 9.5f), Random.Range(-4f, 6f), 0);
            if (i < populationSize - 3)
            {

                if (Random.value < 0.9)
                {
                    Agent01 = Instantiate(PlantPrefab, v3, Quaternion.identity);
                    Agent01.GetComponent<DNA>().Kingdom = true;
                    Agent01.GetComponent<DNA>().FirstGen();
                    Agent01.GetComponent<DNA>().species = i;
                }

                else
                {
                    Agent01 = Instantiate(AnimalPrefab, v3, Quaternion.identity);
                    Agent01.GetComponent<DNA>().Kingdom = false;
                    Agent01.GetComponent<DNA>().FirstGen();
                    Agent01.GetComponent<DNA>().species = i;
                }
            }

            if (i == 97 || i == 98)
            {
                Agent01 = Instantiate(AnimalPrefab, v3, Quaternion.identity);
                Agent01.GetComponent<DNA>().Kingdom = false;
                Agent01.GetComponent<DNA>().Diet = Random.Range(0, 0.4f);
                Agent01.GetComponent<DNA>().StartingEnergy = Random.Range(2500, 10000);
                Agent01.GetComponent<DNA>().species = i;
            }

            else if (i == 99)
            {
                Agent01 = Instantiate(AnimalPrefab, v3, Quaternion.identity);
                Agent01.GetComponent<DNA>().Kingdom = false;
                Agent01.GetComponent<DNA>().Diet = Random.Range(0.6f, 1f);
                Agent01.GetComponent<DNA>().StartingEnergy = Random.Range(2500, 10000);
                Agent01.GetComponent<DNA>().species = i;
            }
         
        }
    }
}

