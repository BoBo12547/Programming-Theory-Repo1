using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    private void Start()
    {
        speed = 6f;
        jump = 6f;

        animalRb = GetComponent<Rigidbody>();
    }

    

    
    protected override void Talk()
    {
        Debug.Log("Im a cat");
    }


}
