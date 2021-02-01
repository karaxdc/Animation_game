using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float frontSpeed;
    private Rigidbody rb;
    public Vector3 jump;
    public float jumpForce = 20.0f;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + frontSpeed);

        if (Input.GetButton("Horizontal"))
        {
            this.gameObject.transform.position += new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0);

        }

        
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z)) && isGrounded){
     
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
         
        
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
