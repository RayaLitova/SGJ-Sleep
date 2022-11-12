using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] bool isDoubleJumpEnabled = false;
    [SerializeField] float jumpSpeed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float dashLength = 0f;


    private int jumpCount = 0;
    private int dashCount = 0;
    private float dashTimer = 0f;
    private bool isMoveNegative = false;
    private Rigidbody2D characterRb;
    private BoxCollider2D characterBoxCollider;

    private void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        characterBoxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine("Jump");
    }
    void FixedUpdate()
    {
        HorizontalMovement();
    }

    private void Update()
    {
        Jump();
        Dash();
    }

    private void Jump()
    {
        if (!Input.GetButtonDown("Jump"))
            return;
        if (isGrounded())
            jumpCount = 0;
        if (jumpCount >= (isDoubleJumpEnabled ? 2 : 1))
            return;

        characterRb.velocity = new Vector2(characterRb.velocity.x, jumpSpeed);
        jumpCount++;
    }
    private void HorizontalMovement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (moveDirection.x < 0) isMoveNegative = true;
        else isMoveNegative = false;
        if (moveDirection != Vector3.zero)
            transform.position += (moveDirection * moveSpeed);
    }

    private void Dash()
    {
        if (!Input.GetKeyDown(KeyCode.LeftShift))
            return;
        if (dashTimer < Time.fixedTime)
            dashCount = 0;
        if (dashCount >= 1)
            return;
        characterRb.velocity = new Vector2(dashSpeed * (isMoveNegative ? -1 : 1), characterRb.velocity.y);
        dashCount++;
        dashTimer = Time.fixedTime + dashLength;
    }

    private bool isGrounded()
    {
        float extraHeight = .02f;
        RaycastHit2D r = Physics2D.Raycast(characterBoxCollider.bounds.center, Vector2.down, characterBoxCollider.bounds.extents.y + extraHeight, groundLayer);
        return r.collider != null;
    }
}
