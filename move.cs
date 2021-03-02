using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class move : MonoBehaviour
{


    public float rotateSpeed;
    public float runSpeed;
    public Rigidbody blacky;
    public float jHeight;
    private bool isGrounded;
    private int doubleJump=0;
    private Vector3 jumpForce;
    
    


    void Start()
    {


        blacky = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0.0f, 2.0f, 0.0f);


    }
    public  void inputdetection(){
        if (Input.GetAxis("Horizontal") != 0)
        {

            transform.Translate(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            

        }
        
        
    }

    void Update()
    {
        transform.Rotate(rotateSpeed * Input.GetAxis("Horizontal") * Time.deltaTime + rotateSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0.0f, 0.0f);
        blacky.AddForce(runSpeed * Input.GetAxis("Horizontal"), 0f, runSpeed * Input.GetAxis("Vertical"));
       

        

        
        


        
        if (Input.GetKey(KeyCode.Space) && doubleJump<3)
        {
            blacky.AddForce(jHeight * jumpForce, ForceMode.Impulse);
            doubleJump += 1;
            if (doubleJump == 2)
            {
                isGrounded = false;
                doubleJump = 0;
            }




        }
        



    }

    void FixedUpdate()
    {
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("gameover2");
        }






    }
    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
        if (col.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("win");
        }
    }

    

}