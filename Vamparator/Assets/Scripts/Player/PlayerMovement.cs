using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.Searcher.SearcherWindow.Alignment;
#endif

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float CharacterSpeed = 5f;
    [SerializeField] private float isWalking;
    [SerializeField] public Joystick joystick;
    float RawVerticalInput;
    float RawHorizontalInput;

    Animator animator;
    public bool canMove = true;
    bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RawVerticalInput = joystick.Vertical;
        RawHorizontalInput = joystick.Horizontal;

        isWalking = RawHorizontalInput != 0 || RawVerticalInput != 0 ? 1 : 0;
        animator.SetFloat("isWalking", isWalking);

        if(canMove)
        {
            CharacterMove(RawVerticalInput, RawHorizontalInput);
        }
        
        Flip();
    }
    void CharacterMove(float Vertical, float Horizontal)
    {
        transform.Translate(new Vector3(Horizontal, Vertical, 0f).normalized * CharacterSpeed * Time.deltaTime);
    }

    void Flip()
    {
        if (isFacingRight && RawHorizontalInput < 0f || !isFacingRight && RawHorizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
