using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    public Animator m_Animator;

    NavMeshAgent m_NavMeshAgent;
    float m_fMoveSpeed = 10f;

    // Use this for initialization
    void Awake ()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update ()
    {
        // 조이스틱 조작
        float x = UltimateJoystick.GetHorizontalAxis("move");
        float z = UltimateJoystick.GetVerticalAxis("move");
        bool bMoveState = UltimateJoystick.GetJoystickState("move");

        if (bMoveState == true)
        {
            Vector3 MoveOffsetStick = new Vector3(x, 0f, z);

            MoveOffsetStick *= Time.deltaTime;
            MoveOffsetStick *= m_fMoveSpeed;

            m_NavMeshAgent.Move(MoveOffsetStick);

            transform.localRotation = Quaternion.LookRotation(MoveOffsetStick);

            m_Animator.SetBool("Run", true);
        }
        else
            m_Animator.SetBool("Run", false);



        /*
        // 키보드 조작
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 MoveOffset = new Vector3(-1f, 0f, 0f);

            MoveOffset *= Time.deltaTime;
            MoveOffset *= m_fMoveSpeed;

            m_NavMeshAgent.Move(MoveOffset);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 MoveOffset = new Vector3(1f, 0f, 0f);

            MoveOffset *= Time.deltaTime;
            MoveOffset *= m_fMoveSpeed;

            m_NavMeshAgent.Move(MoveOffset);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 MoveOffset = new Vector3(0f, 0f, 1f);

            MoveOffset *= Time.deltaTime;
            MoveOffset *= m_fMoveSpeed;

            m_NavMeshAgent.Move(MoveOffset);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 MoveOffset = new Vector3(0f, 0f, -1f);

            MoveOffset *= Time.deltaTime;
            MoveOffset *= m_fMoveSpeed;

            m_NavMeshAgent.Move(MoveOffset);
        }
        */
    }
}
