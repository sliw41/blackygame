using UnityEngine;

public class collision : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    public Rigidbody blacky;
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

            //If the GameObject's name matches the one you suggest, output this message in the console
            blacky.velocity = Vector3.zero;
            blacky.angularVelocity = Vector3.zero;
        

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        
    }
}