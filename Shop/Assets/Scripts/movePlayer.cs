using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] float m_MoveDistance = 0.1f;
    [Header("keys")]
    [SerializeField] KeyCode m_Left = KeyCode.A;
    [SerializeField] KeyCode m_Go = KeyCode.W;
    [SerializeField] KeyCode m_Right = KeyCode.D;
    [SerializeField] KeyCode m_Back = KeyCode.S;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void move()
    {
        Vector3 translate;
        translate = Vector3.zero;

        if (Input.GetKey(m_Left))
            translate = -mainCamera.transform.right * m_MoveDistance;
        if (Input.GetKey(m_Right))
            translate = mainCamera.transform.right * m_MoveDistance;
        if (Input.GetKey(m_Go))
            translate = mainCamera.transform.forward * m_MoveDistance;
        if (Input.GetKey(m_Back))
            translate = -mainCamera.transform.forward * m_MoveDistance;

        translate *= Time.deltaTime;

        transform.Translate(translate);
    }

    private void Update()
    {
        move();
    }
}