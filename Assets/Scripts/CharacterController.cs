using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  Rigidbody2D rb;
  Animator animator;
  // [SerializeField]
  float movementSpeed = 500;
  // [SerializeField]
  float jumpForce = 85;
  float inputX;
  bool jump = false;
  bool isOnGround = true;
  Vector2 movementDirection;
  [SerializeField]
  LayerMask groundLayer;
  SpriteRenderer spriteRenderer;
  bool isRightDirection = true;
  // Vector3 cameraPosition;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    rb.gravityScale = 5;

    animator = GetComponent<Animator>();
  }

  void Update()
  {
    inputX = Input.GetAxisRaw("Horizontal");

    if ((Mathf.Sign(inputX) == 1) && (rb.velocity.x > float.Epsilon))
    {
      isRightDirection = true;
      animator.SetBool("isWalking", true);
    }
    else if ((Mathf.Sign(inputX) == -1) && (rb.velocity.x < -float.Epsilon))
    {
      isRightDirection = false;
      animator.SetBool("isWalking", true);
    }
    else
    {
      animator.SetBool("isWalking", false);
    }

    spriteRenderer.flipX = !isRightDirection;

    isOnGround = Physics2D.OverlapCircle(transform.position, 2f, groundLayer);
    if (isOnGround) animator.SetBool("isJumping", false);
    if ((Input.GetKey(KeyCode.Space)) && isOnGround)
    {
      jump = true;
    }
    if (rb.velocity.y < -0.1f)
    {
      rb.gravityScale = 9.5f;
    }
    else
    {
      rb.gravityScale = 5f;

    }
  }

  void LateUpdate()
  {
    // cameraPosition = transform.position + Vector3.up * 4 + Vector3.forward * -10;
    // // if (isOnGround)
    // {
    //   // Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraPosition, (Time.time % 1f) / 20);
    //   Camera.main.transform.position = cameraPosition;
    // }
  }

  void FixedUpdate()
  {
    movementDirection = new Vector2(inputX * Time.deltaTime * movementSpeed, rb.velocity.y);
    rb.velocity = movementDirection;
    if (jump)
    {
      // animator.SetBool("isWalking", false);
      animator.SetBool("isWalking", false);
      animator.SetBool("isPushing", false);
      animator.SetBool("isJumping", true);
      rb.velocity = new Vector2(rb.velocity.x, 0);
      rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
      jump = false;
    }
  }
}
