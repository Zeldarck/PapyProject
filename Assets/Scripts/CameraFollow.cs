using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    GameObject m_objectToFollow;

    // TODO change how this is fixed/control and orientation
    [SerializeField]
    Vector3 m_offset;

    [SerializeField]
    Vector3 m_orientation;

    [SerializeField]
    float m_speed;


    #region getter/setter
    public GameObject ObjectToFollow
    {
        get
        {
            return m_objectToFollow;
        }

        set
        {
            m_objectToFollow = value;
        }
    }

    public Vector3 Offset
    {
        get
        {
            return m_offset;
        }

        set
        {
            m_offset = value;
        }
    }
    #endregion //getter/setter


    void Update()
    {
        if (ObjectToFollow)
        {
            transform.position = ObjectToFollow.transform.position + Offset;
            transform.localRotation = Quaternion.Euler(m_orientation);

            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                Offset += gameObject.transform.forward * m_speed;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
            {
                Offset -= gameObject.transform.forward * m_speed;
            }

        }

    }

}

