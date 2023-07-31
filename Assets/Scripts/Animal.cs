using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    protected Rigidbody animalRb;
    int randomWalk;
    int randomJump;
    bool isPassed;
    bool isJumped;
    float bounds = 14f;
    float m_jump = 5f;
    float m_speed = 4f;

    // ENCAPSULATION
    protected float jump
    {
        get { return m_jump; }

        set
        {
            if (value < 25f)
            {
                m_jump = value;
            }
            else
            {
                Debug.LogError("Value Too Big");
            }
        }

    }

    // ENCAPSULATION
    protected float speed { get { return m_speed; }

         set
        {
            if (value < 25f)
            {
                m_speed = value;            }
            else
            {
                Debug.LogError("Value Too Big");
            }
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        randomWalk = Random.Range(0, 4);
        randomJump = Random.Range(0, 2);
        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ABSTRACTION
        TalkIfClicked();
        RandomWalk();
        RandomJump();
    }


    bool IsOutOfBounds()
    {
        return transform.position.x > bounds || transform.position.x < -bounds || transform.position.z > bounds || transform.position.z < -bounds;
    }

    IEnumerator IsTimePassed()
    {
        
        yield return new WaitForSeconds(2f);
        randomWalk = Random.Range(0, 4);
        randomJump = Random.Range(0, 2);
        isPassed = false ;
        isJumped = false;
    }

    void Passed2Sec()
    {
        if (!isPassed)
        {
            isPassed = true;
            StartCoroutine(IsTimePassed());

        }
    }

    protected void RandomWalk()
    {
        // ABSTRACTION
        Passed2Sec();
            
            if (IsOutOfBounds())
            {
            speed *= -1;
            }
            if (randomWalk == 0)
            {
                transform.Translate(speed * Vector3.forward * Time.deltaTime);
            }
            else if (randomWalk == 1)
            {
                transform.Translate(speed * Vector3.right * Time.deltaTime);
            }
            else if (randomWalk == 2)
            {
                transform.Translate(speed * Vector3.right * Time.deltaTime);
                transform.Translate(speed * Vector3.forward * Time.deltaTime);
            }
    }

    protected void RandomJump()
    {
        // ABSTRACTION
        Jump();
        Passed2Sec();
        
        
    }

    protected void Jump()
    {
        if (!isJumped)
        {
            animalRb.AddForce(randomJump * jump * Vector3.up, ForceMode.Impulse);
            isJumped = true;
        }


    }


    protected virtual void Talk()
    {
        Debug.Log("im an animal");
    }
    protected void TalkIfClicked()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)&&Input.GetMouseButtonDown(0))
        {
            if (hit.collider.GetComponentInParent<Animal>() != null&&hit.collider.gameObject==gameObject)
                Talk();
                
        }
    }

    

}
