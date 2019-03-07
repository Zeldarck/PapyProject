using UnityEngine;
using UnityEngine.AI;



public class PlayerController : MonoBehaviour
{


    Rigidbody m_playerRigidbody;          


    [SerializeField]
    float m_speed;

    public Interactable CurrentInteractable { get; private set; }

    public Inventory Inventory { get; private set; }

    public bool Freeze { get; set; }

    void Start () {

        Inventory = new Inventory();

        Camera.main.GetComponent<CameraFollow>().ObjectToFollow = gameObject;

        m_playerRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (!Freeze)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (CurrentInteractable != null)
                {
                    CurrentInteractable.Interact(this);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!Freeze)
        {
            Move();
        }
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
        if(CurrentInteractable == null || CurrentInteractable.gameObject == a_interactable.gameObject)
        {
            CurrentInteractable = a_interactable;
            return true;
        }
        return false;
    }

    public void ResetInteractable()
    {
        CurrentInteractable.GetComponent<InteractableManager>().Release(this);
        CurrentInteractable = null;
    }

}
