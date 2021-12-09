using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    float maxHeight = 400.0f;
    float minHeight = 50.0f;
    float maxX = 220.0f;
    float minX = -220.0f;
    float maxZ = 220.0f;
    float minZ = -220.0f;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;


    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }


    void HandleMovementInput()
    {
        // Speed
        if(Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        } 
        else
        {
            movementSpeed = normalSpeed;
        }

        // Pan
        Pan();

        // Rotate
        Rotate();

        // Zoom
        Zoom();

        // Lerps
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

    }

    public void Pan()
    {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        

        //newPosition = new Vector3(inputVector.x, 0, inputVector.y);

        // Pan Bounds
        if (transform.position.z > maxZ)
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (transform.position.z < minZ)
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (transform.position.x > maxX)
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (transform.position.x < minX)
        {
            newPosition += (transform.right * movementSpeed);
        }
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
    }

    public void Zoom()
    {
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        // Zoom Bounds
        if (cameraTransform.position.y > maxHeight)
        {
            newZoom += zoomAmount;
        }
        if (cameraTransform.position.y < minHeight)
        {
            newZoom -= zoomAmount;
        }
    }

}
