using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotationUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.eulerAngles =  new Vector3(0, 0, 0);

    }
}
