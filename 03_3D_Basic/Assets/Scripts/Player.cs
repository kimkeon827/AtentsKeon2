using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;
    public float jumpPower = 3.0f;

    float moveDir = 0.0f;
    float rotateDir = 0.0f;

    Rigidbody rigid;

    PlayerInputActions inputActions;                // PlayerInputActionsŸ���̰� inputActions �̸��� ���� ������ ����

    private void Awake()
    {
        inputActions = new PlayerInputActions();    // �ν��Ͻ� ����
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();   // Player �׼Ǹʿ� ����ִ� �׼ǵ��� ó���ϰڴ�.
        inputActions.Player.Move.performed += OnMoveInput;  // Move �׼ǿ� ����� Ű�� �������� �� ����Ǵ� �Լ��� ���� ( ���ε�)
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Jump.performed += OnJumpInput;
    }

    

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMoveInput;  // ���ε� ����
        inputActions.Player.Disable(); // Player �׼Ǹʿ� �ִ� �׼ǵ��� ó������ �ʰڴ�.
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Jump.performed -= OnJumpInput;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();   // �Էµ� ���� �о����
        //Debug.Log(input);
        moveDir = input.y;      // w : +1, s : -1   �������� �������� ����
        rotateDir = input.x;    // a : -1, d : +1   ��ȸ������ ��ȸ������ ����
    }

    private void OnJumpInput(InputAction.CallbackContext _)
    {
        // �÷��̾��� ���� ����(up)���� jumppower��ŭ ��� ���� �߰��Ѵ�.(���� ���� ����)
        rigid.AddForce(transform.up * jumpPower , ForceMode.Impulse);
    }

    private void Move()
    {
        // ������ٵ�� �̵��ϱ�
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * moveDir * transform.forward);
    }

    void Rotate() 
    {
        // ������ٵ�� ȸ�� ����
        //rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0, rotateDir * rotateSpeed * Time.fixedDeltaTime, 0));
        rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up));

        // Quaternion.Euler(0, rotateDir * rotateSpeed * Time.fixedDeltaTime, 0) // x,z���� ȸ�� ���� y�� �������� ȸ��
        // Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up)   // �÷��̾��� y�� �������� ȸ��
    }

}
