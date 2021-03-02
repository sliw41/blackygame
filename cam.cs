using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform blacky;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position-blacky.transform.position;
        print(offset);
        
    }

    
    void LateUpdate()
    {
        transform.position =blacky.transform.position+offset;
       print(transform.position =blacky.transform.position+offset);
       
        
    }
}
