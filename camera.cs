using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    

    public Transform target;
    public float PosLerpSpeed = 5f;
    public float heightOffset = 3f;
    public float distanceOffset = 8f;
    private Vector3 dis;
    private Vector3 lastOffset = new Vector3(0f, 0f, -1f);
    void Start()
    {
        dis = transform.position;
    }
    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            transform.position = target.transform.position + dis;
        }
        else
        {
            
            Vector3 offset = new Vector3(0f, heightOffset, -distanceOffset);
            Vector3 wantedCameraPosition = target.rotation * offset;

           
            Vector3 smoothedPos = Vector3.Lerp(lastOffset, wantedCameraPosition, Time.deltaTime * PosLerpSpeed);
            transform.position = smoothedPos + target.position;
           
            transform.LookAt(target, target.up);
            lastOffset = smoothedPos;

        }  
        
    }
}
