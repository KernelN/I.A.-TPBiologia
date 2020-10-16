using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    float BodySize;
    float BodySizeforVector3;
    float BodyEnergy;
    float BodyNewEnergy;

    void Start()
    {
        BodyEnergy = gameObject.GetComponent<Energy>().energy;
        BodyNewEnergy = BodyEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (BodySize <= BodyNewEnergy / BodyEnergy)
        {
            BodySize = BodyNewEnergy / BodyEnergy;
            BodySizeforVector3 = BodySize / 3;
            gameObject.transform.localScale = new Vector3(BodySizeforVector3, BodySizeforVector3, BodySizeforVector3);
        }

        BodyNewEnergy = gameObject.GetComponent<Energy>().energy;
        BodyNewEnergy += BodySize / 2;
        gameObject.GetComponent<Energy>().energy = BodyNewEnergy;
    }
}
