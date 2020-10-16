using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    float BodySizeforVector3;
    public float BodySize;
    public float energy;
    public GameObject PlantPrefab;
    public GameObject AnimalPrefab;
    GameObject son;


    void Start()
    {
        energy = GetComponent<DNA>().StartingEnergy;
        BodySize = energy/5000;
        BodySizeforVector3 = BodySize / 3;
        gameObject.transform.localScale = new Vector3(BodySizeforVector3, BodySizeforVector3, BodySizeforVector3);
    }

    public void Update()
    {
        if (energy <= 0) { Object.Destroy(gameObject); }

        //Plant
        if (energy > GetComponent<DNA>().StartingEnergy * 1.5f && GetComponent<DNA>().Kingdom)
        {
            Vector3 v3 = transform.position + new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), 0);
            son = Instantiate(PlantPrefab, v3, Quaternion.identity);
            son.GetComponent<DNA>().Son(gameObject, gameObject);
            energy -= GetComponent<DNA>().StartingEnergy;
        }

        //Animal
        else if (!GetComponent<DNA>().Kingdom && energy > GetComponent<DNA>().StartingEnergy * 3)
        {
            GetComponent<Move>().StartLeftRotation();

            Vector3 v3 = transform.position + new Vector3(Random.Range(-2, 3), Random.Range(-2, 3), 0);
            son = Instantiate(AnimalPrefab, v3, Quaternion.identity);
            son.GetComponent<DNA>().Son(gameObject, gameObject);
            energy -= GetComponent<DNA>().StartingEnergy;
            GetComponent<Move>().StartLeftRotation();
        }
    }
}
