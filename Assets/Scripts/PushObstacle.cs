using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObstacle : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    public bool pushed;

    //private TutorialText tutorial;

    // Start is called before the first frame update
    void Start()
    {
        //tutorial.GetComponent<TutorialText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnControllerColliderHit(ControllerColliderHit hit)
   {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {

            Vector3 forceDirecion = hit.gameObject.transform.position - transform.position;
            forceDirecion.y = 0;
            forceDirecion.Normalize();

            rigidbody.AddForceAtPosition(forceDirecion * forceMagnitude, transform.position, ForceMode.Impulse);

        }

        //tutorial.fastTutorial.SetActive(false);

    }
}
