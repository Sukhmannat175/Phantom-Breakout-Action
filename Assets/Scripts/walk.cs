using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    
    Animator anim;
  
    int FireButtonPressed = Animator.StringToHash("FireButtonPressed");
    
    

    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();


        //    float horizontalMove = Input.GetAxis("Horizontal");
        //    anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //    anim.SetBool("JumpButonPressed", jump);
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);
        


        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(FireButtonPressed);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger(FireButtonPressed);
        }
       

    }

    void Movement()
    {
        Vector3 charecterScale = transform.localScale;
        if (Input.GetKey(KeyCode.D))
        {
            charecterScale.x = 1;
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            charecterScale.x = -1;
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        transform.localScale = charecterScale;
    }

   
}
