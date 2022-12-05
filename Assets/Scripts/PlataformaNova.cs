using UnityEngine;

public enum NewStates { INITIALPOS, MOVINGFORWARD, MOVINGBACK, FINALPOS }
public class PlataformaNova : MonoBehaviour
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

    public NewStates state;
    public float speed;

    public int numPlayerOnTop;
    public int numForActivation;

    void Start()
    {
        initialPosition = gameObject.transform.position;
        state = NewStates.INITIALPOS;

    }


    void Update()
    {
        currentPosition = gameObject.transform.position;

        StateMachine();

        if (state != NewStates.INITIALPOS && numForActivation <= numPlayerOnTop)
        {
            //state = MovementState.MOVINGBACK;
        }
        if (state != NewStates.FINALPOS && numForActivation <= numPlayerOnTop)
        {
            state = NewStates.MOVINGFORWARD;
        }
        if(currentPosition.z <= initialPosition.z && numForActivation >= numPlayerOnTop)
        {
            state = NewStates.INITIALPOS;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop += 1;
            //other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop -= 1;
            //other.transform.parent = null;
        }
    }


    void MovePlatform()
    {
        if (moveBack == true)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
            if (currentPosition.z <= destinationPosition.z)
            {
                state = NewStates.FINALPOS;
            }
        }
        if (moveFront == true)
        {
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
            if (currentPosition.z >= destinationPosition.z)
            {
                state = NewStates.FINALPOS;
            }
        }
        if (moveRight == true)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x >= destinationPosition.x)
            {
                state = NewStates.FINALPOS;
            }
        }
        if (moveLeft == true)
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x <= destinationPosition.x)
            {
                state = NewStates.FINALPOS;
            }
        }
        if (moveUp == true)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            if (currentPosition.y >= destinationPosition.y)
            {
                state = NewStates.FINALPOS;
            }
        }
        if (moveDown == true)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            if (currentPosition.y <= destinationPosition.y)
            {
                state = NewStates.FINALPOS;
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
                state = NewStates.INITIALPOS;
            }

        }
        if (moveFront == true)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
            if (currentPosition.z <= initialPosition.z)
            {
                state = NewStates.INITIALPOS;
            }
        }
        if (moveRight == true)
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x <= initialPosition.x)
            {
                state = NewStates.INITIALPOS;
            }
        }
        if (moveLeft == true)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            if (currentPosition.x >= initialPosition.x)
            {
                state = NewStates.INITIALPOS;
            }

        }
        if (moveUp == true)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            if (currentPosition.y <= initialPosition.y)
            {
                state = NewStates.INITIALPOS;
            }
        }
        if (moveDown == true)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            if (currentPosition.y >= initialPosition.y)
            {
                state = NewStates.INITIALPOS;
            }
        }
    }

    void StateMachine()
    {
        switch (state)
        {
            case NewStates.INITIALPOS:
                StopInitial();
                break;

            case NewStates.MOVINGFORWARD:
                MovePlatform();
                break;

            case NewStates.FINALPOS:
                StopFinal();
                break;

            case NewStates.MOVINGBACK:
                MoveBackToInitialPosition();
                break;


        }
    }
    void StopFinal()
    {
        transform.Translate(new Vector3(0, 0, 0) * 0);
        if (numForActivation >= numPlayerOnTop)
        {
            state = NewStates.MOVINGBACK;
        }
    }
    void StopInitial()
    {
        transform.Translate(new Vector3(0, 0, 0) * 0);
        if (numForActivation == numPlayerOnTop)
        {
            state = NewStates.MOVINGFORWARD;
        }
    }
}
