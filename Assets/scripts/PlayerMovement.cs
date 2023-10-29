using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public bool canMove = false;
    private float _controllerOriginalHeight;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _runSpeed = 8f;
    [SerializeField] private float _gravity = -30f;
    [SerializeField] private float jumpHeight = 1.5f;

    [SerializeField] private Animator _cameraAnimator;
    private AudioSource audioSource;
    public AudioClip walkSound;

    Vector3 velocity;
    public bool isGrounded = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walkSound;
        //_cameraAnimator.SetBool("IsWalk", false);
        _controllerOriginalHeight = controller.height;
    }

    void Update()
    {

        isGrounded = controller.isGrounded;
        Move();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 0.7f;
            _speed = 3f;
        }
        else if (CanStandUp())
        {
            controller.height = 1.6f;
            _speed = 4f;
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -3.0f * _gravity);
    }

    private void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (move == Vector3.zero || isGrounded == false)
        {
            audioSource.Stop();
            canMove = false;
        } else if (!audioSource.isPlaying)
        {
            audioSource.Play();
            canMove = true;
        }

        /*if (move == Vector3.zero)
        {
            _cameraAnimator.SetBool("IsWalk", false);
        }*/
        //else
        //{
        //   _cameraAnimator.SetBool("IsWalk", true);
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(_runSpeed * Time.deltaTime * move);
        }
        else
        {
            controller.Move(_speed * Time.deltaTime * move);
        }


        velocity.y += _gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //�������� ����������� ��� ����������
    private bool CanStandUp()
    {
        Vector3 upRayStart = transform.position + Vector3.up * (_controllerOriginalHeight / 2f);
        if (Physics.Raycast(upRayStart, Vector3.up, out RaycastHit hit, _controllerOriginalHeight))
        {
            return false;
        }
        return true;
    }
}