using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class NewPlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public float speed = 1f;
    public float turnSpeed = 125f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

        MoveAction.Enable();
    }

    void Update()
    {
        var pos = MoveAction.ReadValue<Vector2>();      //Reading the input as Vector2, x and y axis

        float horizontal = pos.x;
        float vertical = pos.y;

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * Quaternion.Euler(0, horizontal * turnSpeed * Time.deltaTime, 0));   //Rotating the player using the rigidbody
        m_Rigidbody.MovePosition (m_Rigidbody.position + transform.forward * vertical * speed * Time.deltaTime);    //Moving the player forward using the rigidbody

        if (vertical > 0)
        {
            print("Moving Forwards");
        }
    }
}
