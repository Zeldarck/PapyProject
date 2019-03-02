using UnityEngine;
using UnityEngine.AI;



public class PlayerController : MonoBehaviour
{


    Rigidbody m_playerRigidbody;          


    [SerializeField]
    float m_speed;



    Interactable m_currentInteractable;

    public Interactable CurrentInteractable { get => m_currentInteractable; }

    void Start () {

        Camera.main.GetComponent<CameraFollow>().ObjectToFollow = gameObject;

        m_playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(m_currentInteractable != null)
            {
                m_currentInteractable.Interact(this);
            }
        }
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

    public bool SetInteractable(Interactable a_interactable)
    {
        if(m_currentInteractable == null || m_currentInteractable.gameObject == a_interactable.gameObject)
        {
            m_currentInteractable = a_interactable;
            return true;
        }
        return false;
    }

    public void ResetInteractable()
    {
        m_currentInteractable.GetComponent<InteractableManager>().Release(this);
        m_currentInteractable = null;
    }

}
