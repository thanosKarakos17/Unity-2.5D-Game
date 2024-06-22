using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Transform pos;
    private float start_y = 0f;
    private Vector3 playerVelocity;
    public float speed = 5F;
    /////////////////////////////////////
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
        start_y = 2.43f;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.localPosition.y != start_y) 
        {
            Vector3 newpos = pos.localPosition;
            newpos.y = start_y;
            pos.localPosition = newpos;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector2 animationDirection = input;
        if (input == Vector2.zero)
            animator.enabled = false;
        else
            animator.enabled = true;
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        //controller.Move(playerVelocity * Time.deltaTime);
        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);
    }

}
