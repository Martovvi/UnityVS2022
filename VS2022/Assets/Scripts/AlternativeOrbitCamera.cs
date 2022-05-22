using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class AlternativeOrbitCamera : MonoBehaviour
{

    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 25.0f;
    public float ySpeed = 50.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private Rigidbody rbody;

    float x = 0.0f;
    float y = 0.0f;

    bool orbitable;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rbody != null)
        {
            rbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftControl) == true)
        {
            orbitable = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) == true)
        {
            orbitable = false;
        }
        */

        if (Input.GetMouseButtonDown(1))
        {
            orbitable = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            orbitable = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (orbitable)
        {
            if (target)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

                RaycastHit hit;
                if (Physics.Linecast(target.position, transform.position, out hit))
                {
                    distance -= hit.distance;
                }
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
