using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool forwardMove = false;
    private bool backwardMove =  false;
    private bool rightMove =  false;
    private bool leftMove =  false;
    private float counter;
    private GameObject[] fbrlGameObjects;

    public GameManager gameManager;


    public delegate void CounterAdd(int count);
    public CounterAdd counterAdd;



    // Start is called before the first frame update
    void Start()
    {

        fbrlGameObjects = new GameObject[4];
        
    }



    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameState)
            PlayerMovement();
    }

    
    void InvokingCounterAdd()
    {
        counterAdd?.Invoke(1);
    }
    void PlayerMovement()
    {
        if(forwardMove && Input.GetKeyDown(KeyCode.W))
        {
            transform.position = fbrlGameObjects[0].transform.position + new Vector3(0,1.41f,0);
            if (fbrlGameObjects[0].GetComponent<UnityCell>().getCell().GetStatus() != Cell.Status.redColor)
            {
                InvokingCounterAdd();
            }
            fbrlGameObjects[0].GetComponent<UnityCell>().OnMouseDown();

          
        }

        else if (backwardMove && Input.GetKeyDown(KeyCode.S))
        {
            transform.position = fbrlGameObjects[1].transform.position + new Vector3(0, 1.41f, 0);
            if (fbrlGameObjects[1].GetComponent<UnityCell>().getCell().GetStatus() != Cell.Status.redColor)
            {
                InvokingCounterAdd();
            }
            fbrlGameObjects[1].GetComponent<UnityCell>().OnMouseDown();
           
           
        }

        else if (rightMove && Input.GetKeyDown(KeyCode.D))
        {
            transform.position = fbrlGameObjects[2].transform.position + new Vector3(0, 1.41f, 0);
            if (fbrlGameObjects[2].GetComponent<UnityCell>().getCell().GetStatus() != Cell.Status.redColor)
            {
                InvokingCounterAdd();
            }
            fbrlGameObjects[2].GetComponent<UnityCell>().OnMouseDown();
            
        }

        else if (leftMove && Input.GetKeyDown(KeyCode.A))
        {
            transform.position = fbrlGameObjects[3].transform.position + new Vector3(0, 1.41f, 0);
            if (fbrlGameObjects[3].GetComponent<UnityCell>().getCell().GetStatus() != Cell.Status.redColor)
            {
                InvokingCounterAdd();
            }
            fbrlGameObjects[3].GetComponent<UnityCell>().OnMouseDown();
           
        }
    }

    private void FixedUpdate()
    {
        PlayerRayCaster();
       
    }

    //PlayerRayCaster throwing and detector
    void PlayerRayCaster()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.black);
            if(hit.collider.gameObject != null)
            {
                fbrlGameObjects[0] = hit.collider.gameObject;
                
            }
                

            forwardMove = true;
            //Debug.Log("HIT");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3.0f, Color.white);

            forwardMove = false;
           // Debug.Log("Not Hit");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 5.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.black);
            if (hit.collider.gameObject != null)
            {
                fbrlGameObjects[1] = hit.collider.gameObject;
              
            }

            backwardMove = true;
           // Debug.Log("HIT");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 3.0f, Color.white);
            backwardMove = false;
            //Debug.Log("Not Hit");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 5.0f))
        {
            rightMove = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.black);
            if (hit.collider.gameObject != null)
            {
                fbrlGameObjects[2] = hit.collider.gameObject;
             
            }

            // Debug.Log("HIT");
        }
        else
        {
            rightMove = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 3.0f, Color.white);
            //Debug.Log("Not Hit");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 5.0f))
        {
            leftMove = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.black);
            if (hit.collider.gameObject != null)
            {
                fbrlGameObjects[3] = hit.collider.gameObject;
            }
            //Debug.Log("HIT");
        }
        else
        {
            leftMove = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 3.0f, Color.white);
            //Debug.Log("Not Hit");
        }
    }

}
