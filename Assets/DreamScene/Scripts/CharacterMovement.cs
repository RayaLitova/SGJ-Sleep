using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.Burst.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float dashLength = 0f;

    private int jumpCount = 0;
    private int dashCount = 0;
    private float dashTimer = 0f;
    private bool isMoveNegative = true;
    private Rigidbody2D characterRb;
    private BoxCollider2D characterBoxCollider;

    private float enemyCollisionCooldown;
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
        if (jumpCount >= (CharacterStats.isDoubleJumpEnabled ? 2 : 1))
            return;

        characterRb.velocity = new Vector2(characterRb.velocity.x, CharacterStats.jumpSpeed);
        jumpCount++;
    }
    private void HorizontalMovement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (moveDirection == Vector3.zero)
            return;
        bool lastMoveNegative = isMoveNegative;
        if (moveDirection.x < 0.0f) isMoveNegative = true;
        else isMoveNegative = false;
        if(lastMoveNegative != isMoveNegative) 
            FlipObject();
        transform.position += (moveDirection * CharacterStats.runSpeed);
    }

    private void Dash()
    {
        if (!Input.GetKeyDown(KeyCode.LeftShift))
            return;
        if (dashTimer < Time.fixedTime)
            dashCount = 0;
        if (dashCount >= 1)
            return;
        FlipObject();
        characterRb.velocity = new Vector2(CharacterStats.dashSpeed * (isMoveNegative ? -1 : 1), characterRb.velocity.y);
        dashCount++;
        dashTimer = Time.fixedTime + dashLength;
    }

    private void FlipObject()
    {
        Vector3 newScale = transform.localScale;
        if (isMoveNegative)
            newScale.x = Mathf.Abs(newScale.x);
        else
            newScale.x *= Mathf.Abs(newScale.x) * - 1;
        transform.localScale = newScale;
    }

    private bool isGrounded()
    {
        float extraHeight = .02f;
        RaycastHit2D r = Physics2D.Raycast(characterBoxCollider.bounds.center, Vector2.down, characterBoxCollider.bounds.extents.y + extraHeight, 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Enemy"));
        return r.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemyCollisionCooldown < Time.fixedTime)
            return;
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            CharacterStats.health--;
            enemyCollisionCooldown = Time.fixedTime + 1f;
        }  
    }
}
