using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    OVRInput.Controller controller = OVRInput.Controller.LTouch; // Left controller
    public float speed = 1f;
    public GameObject centralCam;

    private void LateUpdate()
    {
        // check if the left thumstick is moved
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller) != Vector2.zero)
        {
            Vector2 moveInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, controller);
            Vector3 cameraDirection = centralCam.transform.forward; // Returns a normalized vector representing the blue axis of the transform in world space.
            cameraDirection.y = 0f;
            cameraDirection.Normalize();

            Vector3 direction = cameraDirection * moveInput.y + centralCam.transform.right * moveInput.x;
            transform.position += speed * Time.deltaTime * direction;
        }        
    }
}
