using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 5f;
    IsometricCharacterRenderer isoRenderer;
    private bool touchStart = false;
    public VJHandler jsMovement;
    public Vector2 direction;
    public Transform firepoint;
    public float pX, pY;
    public float lx, ly;
    public float tpx,tpy;
    private float offset =0.8f;
    public Vector2 temp;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        firepoint.position = rbody.position+ new Vector2(0, 0.5f);
    }
    void  Update()
    {
        rbody.velocity=Vector2.zero;
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            movecharbykey();
        }
        else if (jsMovement.isDrag)
        {
            
            direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project


            if (direction.magnitude != 0)
            {

                pX = direction.x;
                pY = direction.y;
                Vector2 currentPos = rbody.position;
                this.moveChar(direction, currentPos);
            }
            else
            {
                Vector2 currentPos = rbody.position;
                this.moveChar(direction, currentPos);
            }
        }
        else
        {

            jsMovement.resetO();
            isoRenderer.SetDirection(Vector2.zero);
        }



    }


    // Update is called once per frame
    
    
    void moveChar(Vector2 d, Vector2 cPos)
    {
        Vector2 currentPos = cPos;
        Vector2 inputVector = d;
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector*1f * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        temp = movement;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);

        tpx = (Mathf.Sign(pX) * (Mathf.Round(Mathf.Abs(pX))+offset+1));
        tpy = (Mathf.Sign(pY) * (Mathf.Round(Mathf.Abs(pY))+offset+1));
        if(Mathf.Abs(pX)<0.2){
            tpx = 0;
        }
        else if(Mathf.Abs(pY)<0.2){
            tpy = 0;
        }
        if ((tpx == 0) && (tpy == 0))
        {
            tpy = 1;
        }
        else
        {
            lx = (float)(cPos.x + tpx * 0.15); 
            ly = (float)(cPos.y + tpy * 0.15);
        }
        
        
        firepoint.position = new Vector2(lx, ly);
     
    }
    void movecharbykey()
    {

        Vector2 currentPos = rbody.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        temp = movement;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
        jsMovement.changeVJ(inputVector*1.2f);

        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            
            if (!(Input.GetKey("up") || Input.GetKey("down")) )
            {
                tpx = (Mathf.Sign(inputVector.x) * (Mathf.Round(Mathf.Abs(inputVector.x))+offset+1));
                tpy = 0;
                         
            }
            else if(!(Input.GetKey("left") || Input.GetKey("right"))){
                tpx = 0;
                tpy = (Mathf.Sign(inputVector.y) * (Mathf.Round(Mathf.Abs(inputVector.y))+offset+1));   
            }
            else{
                tpx = (Mathf.Sign(inputVector.x) * (Mathf.Round(Mathf.Abs(inputVector.x))+offset+1));
                tpy = (Mathf.Sign(inputVector.y) * (Mathf.Round(Mathf.Abs(inputVector.y))+offset+1));
     
            }
            
        }
        if ((inputVector.x == 0) && (inputVector.y == 0))
            {
                tpy = 1;
            }
            else
            {
                lx = (float)(currentPos.x + tpx * 0.15); 
                ly = (float)(currentPos.y + tpy * 0.15);
            }
            
            
            firepoint.position = new Vector2(lx, ly);
        

        
        
    }
    
    
}
