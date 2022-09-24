using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObstacle : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    private CharacterController characterController;
    public bool pushed;
    
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

   }
}
