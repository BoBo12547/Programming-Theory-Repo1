using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        jump = 4f;
        animalRb = GetComponent<Rigidbody>();
    }



    // POLYMORPHISM
    protected override void Talk()
    {
        Debug.Log("Im a dog");
    }
}
