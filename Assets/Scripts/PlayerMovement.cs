using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb;
    [SerializeField]
    Animator animator;
    Vector2 movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;

        //rotation
        //rotateToMouse();

        //void rotateToMouse()
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //    Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        //    transform.up = dir;

        //}
    }
}
