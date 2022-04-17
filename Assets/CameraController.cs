using UnityEngine;


public class CameraController : MonoBehaviour
     // this must be configured by inspector
    public KeyCode upArrow;
public KeyCode downArrow;
public KeyCode leftArrow;
public KeyCode rightArrow;
public KeyCode rotateAroundLeft;
public KeyCode rotateAroundRight;
public KeyCode zoomIn;
public KeyCode zoomOut;
public KeyCode jumpBackToPlayer;

public static InputManager instance; // instance reference
private Vector2 panAxis = Vector2.zero;

void Awake()
{
    instance = this; // instance reference
}

void Update()
{
    UpdatePanAxis();
}

private void UpdatePanAxis()
{
    panAxis = Vector2.zero;

    if (Input.GetKey(upArrow))
    {
        panAxis.y = 1;
    }
    else if (Input.GetKey(downArrow))
    {
        panAxis.y = -1;
    }

    if (Input.GetKey(rightArrow))
    {
        panAxis.x = 1;
    }
    else if (Input.GetKey(leftArrow))
    {
        panAxis.x = -1;
    }
}

public Vector2 GetPanAxis()
{
    return panAxis;
}

public bool GetRotateAroundLeft()
{
    return Input.GetKey(rotateAroundLeft);
}

public bool GetRotateAroundRight()
{
    return Input.GetKey(rotateAroundRight);
}

public float GetZoomInputAxis()
{
    float value = 0;

    if (Input.GetKey(zoomOut))
    {
        value = -0.3f;
    }
    else if (Input.GetKey(zoomIn))
    {
        value = 0.3f;
    }

    if (Input.GetAxis("Mouse ScrollWheel") < 0)
    {
        value = -1;
    }
    else if (Input.GetAxis("Mouse ScrollWheel") > 0)
    {
        value = 1;
    }

    return value;
}

public bool GetJumpBackToPlayer()
{
    return Input.GetKey(jumpBackToPlayer);
}

//{
//    // Left mouse button: Move forward with rotation
//    // Right mouse button: Move backward with rotation
//    // Both buttons: Rotate without movement

//    // Limits
//    private float startFOV = 60;
//    private float minFOV = 15f;
//    private float maxFOV = 90f;
//    private float maxDistance = 900f; // from 0,0,0

//    // Movement (left/right mouse)
//    public float minMoveSpeed = 250f;
//    public float maxMoveSpeed = 700f;
//    public float moveRampTime = 5f;

//    // Rotation (both mouse buttons)
//    public float rotateSpeed = 6f;
//    public float zoomSpeed = 3f;

//    public Camera cam;
//    private float movementTime = 0;
//    public float movementSpeed = 10;
//    Vector3 lastMousePosition;

//    void Awake()
//    {
//        cam = GetComponent<Camera>();
//        cam.fieldOfView = startFOV;
//    }

//    void LateUpdate()
//    {
//        bool b0 = Input.GetMouseButton(0);
//        bool b1 = Input.GetMouseButton(1);

//        // Movement (Left: forward, Right: backward)
//        Vector3 translate = Vector3.zero;
//        if (b0 != b1)
//        {
//            float direction = (b0) ? 1 : -1;
//            translate = transform.forward.normalized * direction * Time.deltaTime * movementSpeed;
//            translate.y = 0f;
//            translate = Vector3.ClampMagnitude(
//               new Vector3(transform.position.x, 0f, transform.position.z) + translate,
//               maxDistance);
//            translate.y = transform.position.y;
//            transform.position = translate;

//            movementTime += Time.deltaTime / moveRampTime;
//            movementSpeed = Mathf.Lerp(minMoveSpeed, maxMoveSpeed, movementTime * movementTime);
//        }
//        else
//        {
//            movementTime = 0;
//            movementSpeed = minMoveSpeed;
//        }

//        // Rotation (either button)
//        if (b0 || b1)
//        {
//            // if the game window is separate from the editor window and the editor
//            // window is active then you go to right-click on the game window the
//            // rotation jumps if  we don't ignore the mouseDelta for that frame.
//            Vector3 mouseDelta;
//            if (lastMousePosition.x >= 0
//                && lastMousePosition.y >= 0
//                && lastMousePosition.x <= Screen.width
//                && lastMousePosition.y <= Screen.height)
//                mouseDelta = Input.mousePosition - lastMousePosition;
//            else
//                mouseDelta = Vector3.zero;

//            Vector3 rotation = Vector3.up * Time.deltaTime * rotateSpeed * mouseDelta.x;
//            rotation += Vector3.left * Time.deltaTime * rotateSpeed * mouseDelta.y;
//            transform.Rotate(rotation, Space.Self);

//            // Make sure z rotation stays locked
//            rotation = transform.rotation.eulerAngles;
//            rotation.z = 0;
//            transform.rotation = Quaternion.Euler(rotation);
//        }
//        lastMousePosition = Input.mousePosition;

//        // Zoom (wheel)
//        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - Input.mouseScrollDelta.y * zoomSpeed, minFOV, maxFOV);
//    }
//}




//public class CameraController : MonoBehaviour
//{
//    private bool doMovement = true;
//    public float panSpeed = 30f;
//    public float panBorderThickness = 10f;
//    public float scrollSpeed = 5f;
//    public float minY = 10f;
//    public float maxY = 80f;

//    // Update is called once per frame  
//    void Update()
//    {
//        if (Input.GetKeyDown (KeyCode.Escape))
//            doMovement = !doMovement;

//        if (!doMovement)
//            return;

//        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
//            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
//        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
//            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
//        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
//            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
//        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
//            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);


//        float scroll = Input.GetAxis("Mouse ScrollWheel");
//        Vector3 pos = transform.position;
//        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
//        pos.y = Mathf.Clamp(pos.y, minY, maxY);

//        transform.position = pos;

//    }
//}

