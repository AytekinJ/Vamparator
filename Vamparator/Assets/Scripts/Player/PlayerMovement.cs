using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float CharacterSpeed = 5f;
    [SerializeField] private float isWalking;
    float RawVerticalInput;
    float RawHorizontalInput;

    Animator animator;

    bool isFacingRight = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RawVerticalInput = Input.GetAxisRaw("Vertical");
        RawHorizontalInput = Input.GetAxisRaw("Horizontal");

        isWalking = RawHorizontalInput != 0 || RawVerticalInput != 0 ? 1 : 0;
        animator.SetFloat("isWalking", isWalking);

        CharacterMove(RawVerticalInput, RawHorizontalInput);
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
