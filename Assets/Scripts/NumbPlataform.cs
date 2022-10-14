using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementState { INITIALPOS, MOVINGFORWARD, MOVINGBACK, FINALPOS }
public class NumbPlataform : MonoBehaviour
{
    
    public bool moveFront;
    public bool moveUp;
    public bool moveRight;
    public bool moveLeft;
    public bool moveBack;
    public bool moveDown;
    
    public Vector3 initialPosition;
    public Vector3 currentPosition;
    public Vector3 destinationPosition;

    public MovementState state;
    public float speed;

    public int numPlayerOnTop;
    public int numForActivation;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        state = MovementState.INITIALPOS;
       
    }


    void Update()
    {
        currentPosition = gameObject.transform.position;

        StateMachine();

        if(state != MovementState.INITIALPOS && numForActivation != numPlayerOnTop)
        {
            state = MovementState.MOVINGBACK;
        }
        if (state != MovementState.FINALPOS && numForActivation == numPlayerOnTop)
        {
            state = MovementState.MOVINGFORWARD;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop += 1;            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
        collision.collider.transform.SetParent(transform);       
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.SetParent(null);
    }
    void MovePlatform()
    {
        if(moveBack == true)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
            if(currentPosition.z <= destinationPosition.z)
            {
                state = MovementState.FINALPOS;
            }
        }
        if (moveFront == true)
        {
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
            if (currentPosition.z >= destinationPosition.z)
            {
                state = MovementState.FINALPOS;
            }
        }
        if (moveRight == true)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x >= destinationPosition.x)
            {
                state = MovementState.FINALPOS;
            }
        }
        if (moveLeft == true)
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x <= destinationPosition.x)
            {
                state = MovementState.FINALPOS;
            }
        }
        if (moveUp == true)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            if (currentPosition.y >= destinationPosition.y)
            {
                state = MovementState.FINALPOS;
            }
        }
        if (moveDown == true)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            if (currentPosition.y <= destinationPosition.y)
            {
                state = MovementState.FINALPOS;
            }
        }
    }

    void MoveBackToInitialPosition()
    {
            if (moveBack == true)
            {
                transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
                if (currentPosition.z >= initialPosition.z)
                {
                    state = MovementState.INITIALPOS;
                }

            }
            if (moveFront == true)
            {
                transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
                if (currentPosition.z <= initialPosition.z)
                {
                    state = MovementState.INITIALPOS;
                }
            }
            if (moveRight == true)
            {
                transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
                if (currentPosition.x <= initialPosition.x)
                {
                    state = MovementState.INITIALPOS;
                }   
            }
            if (moveLeft == true)
            {
                transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
                if (currentPosition.x >= initialPosition.x)
                {
                    state = MovementState.INITIALPOS;
                }

            }
            if (moveUp == true)
            {
                transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
                if (currentPosition.y <= initialPosition.y)
                {
                    state = MovementState.INITIALPOS;
                }
            }
            if (moveDown == true)
            {
                transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
                if (currentPosition.y >= initialPosition.y)
                {
                    state = MovementState.INITIALPOS;
                }
            }
    }

    void StateMachine()
    {
        switch (state)
        {
            case MovementState.INITIALPOS:
                StopInitial();
                break;

            case MovementState.MOVINGFORWARD:
                MovePlatform();
                break;

            case MovementState.FINALPOS:
                StopFinal();
                break;

            case MovementState.MOVINGBACK:
                MoveBackToInitialPosition();
                break;


        }
    }
    void StopFinal()
    {
        transform.Translate(new Vector3(0, 0, 0) * 0);
        if (numForActivation != numPlayerOnTop)
        {
            state = MovementState.MOVINGBACK;
        }
    }
    void StopInitial()
    {
        transform.Translate(new Vector3(0, 0, 0) * 0);
        if (numForActivation == numPlayerOnTop)
        {
            state = MovementState.MOVINGFORWARD;
        }
    }
}
