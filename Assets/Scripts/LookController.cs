using UnityEngine;

public class LookController : MonoBehaviour
{
    [SerializeField]
    private float sensX, sensY;
    private float rotationX, rotationY;

    [SerializeField]
    private Transform orientation, cameraTr;

    void Start()
    {
        rotationX = transform.rotation.eulerAngles.x;
        rotationY = transform.rotation.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotationY += Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        rotationX -= Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -75f, 75f);
        cameraTr.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
