using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        jump = 8f;
        animalRb = GetComponent<Rigidbody>();
    }
    



    protected override void Talk()
    {
        Debug.Log("Im a rabbit");
    }

}
