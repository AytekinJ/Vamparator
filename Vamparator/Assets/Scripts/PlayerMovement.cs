using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] float CharacterSpeed = 5f;
    float RawVerticalInput;
    float RawHorizontalInput;
    void Update()
    {
        RawVerticalInput = Input.GetAxisRaw("Vertical");

        RawHorizontalInput = Input.GetAxisRaw("Horizontal");

        CharacterMove(RawVerticalInput, RawHorizontalInput);
    }
    void CharacterMove(float Vertical, float Horizontal)
    {
        characterController.Move(new Vector3(Horizontal, Vertical, 0f).normalized * CharacterSpeed * Time.deltaTime);
    }

}
