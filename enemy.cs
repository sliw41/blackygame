using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody foe;
    public Transform blacky;
    public float speed;
    public float searchDist;
    
    // Start is called before the first frame update
    void Start()
    {
        foe = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       transform.LookAt(blacky);
       transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y,0);
        if (Vector3.Distance(transform.position, blacky.position) <= searchDist)
        {
            foe.position = Vector3.MoveTowards(transform.position, blacky.position, speed * Time.deltaTime);

        }
        
        
    }
}
