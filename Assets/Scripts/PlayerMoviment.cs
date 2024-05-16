using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float MovimentSpeed;
    [SerializeField] public Rigidbody2D Rb2D;

    // variable for movement
    Vector2 Mov,LastMovedDirection;

    //Variables to Rotate the aim toward the direction of the moviment 
    public bool isWalking;
    public Transform Aim;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        ProcessInputs();
    }
    // update in fixed time xd
    private void FixedUpdate()
    {
        Rb2D.MovePosition(Rb2D.position + Mov * MovimentSpeed * Time.deltaTime);

        if (isWalking) 
        {
           
            Vector3 vector3 = Vector3.left * Mov.x + Vector3.down * Mov.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }
    //function to process the inputs of the player 
    void ProcessInputs() 
    {
        // variables to store the last moved direction 
        float moveX= Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
     

        if ((moveX == 0 && moveY == 0) && (Mov.x != 0 || Mov.y != 0))
        {
            
            isWalking = false;
            LastMovedDirection = Mov;
            Vector3 vector3 = Vector3.left * LastMovedDirection.x + Vector3.down * LastMovedDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);

        } else if (moveX!=0 || moveY !=0) 
        {
            isWalking = true;
        }
        //inputs
        Mov.x = Input.GetAxisRaw("Horizontal");
        Mov.y = Input.GetAxisRaw("Vertical");
        Mov.Normalize();
    }
}
