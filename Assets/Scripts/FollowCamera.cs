using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Actor m_Actor;

    Vector3 m_CameraOffSet;
    // Use this for initialization
    void Start ()
    {
        m_CameraOffSet = transform.position - m_Actor.transform.position;

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = m_Actor.transform.position + m_CameraOffSet;
    }
}
