using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float energylevel;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LoseEnergy", 3.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (energylevel<1)
            Destroy(gameObject);
    }

    void LoseEnergy()
    {
        energylevel -= 1;
    }

    public float GetEnergyLevel()
    {
        return(energylevel);
    }

    
}
