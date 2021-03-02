using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blackymovement : MonoBehaviour
{

    private int enemy = 12;
    public float walkSpeed;
    public float runSpeed;
    public Rigidbody blacky;
    public float jHeight;
    private bool isGrounded;
    private bool walkGrounded;
    private Vector3 jumpForce;
    public float rotateSpeed;
    private Quaternion rotation;


    void Start()
    {
        


        blacky = GetComponent<Rigidbody>();
        jumpForce = new Vector3(0.0f, 2.0f, 0.0f);
   

    }
    void Update()
    {

      



     
        if (Input.GetAxis("Horizontal") != 0)
        {
            
            transform.Rotate(0.0f, 3*Input.GetAxis("Horizontal"), 0.0f);
           

        }

        else  if (Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            
            blacky.velocity = runSpeed * Vector3.forward;
           blacky.angularVelocity = rotateSpeed * transform.right;
            
        }
        else if (Input.GetAxis("Vertical") != 0 && walkGrounded && isGrounded)
        {

            
            transform.Translate(walkSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, walkSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
            blacky.AddForce(2f * jumpForce, ForceMode.Impulse);

            walkGrounded = false;
            


        }
        else
        {
            rotation = Quaternion.Euler(0f,transform.eulerAngles.y,0f);
           
            transform.Translate(walkSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, walkSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            blacky.AddForce(jHeight * jumpForce, ForceMode.Impulse);
            isGrounded = false;




        }



    }

    void FixedUpdate()
    {
        if (enemy == 0)
        {
            SceneManager.LoadScene("level2");
        }
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene("gameover");
        }






    }
    void OnCollisionStay()
    {
        isGrounded = true;
        walkGrounded = true;
    
 }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy" && !isGrounded)
        {

            Destroy(col.gameObject);
            enemy -= 1;
        }
        else if (col.gameObject.tag=="enemy")
        {
            SceneManager.LoadScene("gameover");

        }
    }



}