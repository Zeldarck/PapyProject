using UnityEngine;
using UnityEngine.AI;



public class PlayerController : MonoBehaviour
{


    Rigidbody m_playerRigidbody;          


    [SerializeField]
    float m_speed;


    void Start () {
        Camera.main.GetComponent<CameraFollow>().ObjectToFollow = gameObject;

        m_playerRigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        movement = movement.normalized * m_speed * Time.deltaTime;

        m_playerRigidbody.MovePosition(transform.position + movement);

        Turning(movement);

    }

    void Turning(Vector3 a_movement)
    {
        if (a_movement != Vector3.zero)
        {            
            Quaternion rotation = Quaternion.LookRotation(a_movement.normalized, Vector3.up);
            m_playerRigidbody.MoveRotation(rotation);
        }
    }

}
