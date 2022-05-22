using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class OrbitCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;

    public float xSpeed = 250f;
    public float ySpeed = 120;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80;

    private float x = 0f;
    private float y = 0f;

    public float smoothTime = 0.3f;
    public float zoomDamp = 2f;

    private float xSmooth = 0f;
    private float ySmooth = 0f;
    private float distanceSmooth = 23.0f;

    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private float smoothVelocity = 0f;

    public float minDistance = 9f;
    public float maxDistance = 10f;

    private Vector3 posSmooth = Vector3.zero;

    private Rigidbody rbody;

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

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(target)
        {
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, minDistance, maxDistance);
            distanceSmooth = Mathf.SmoothDamp(distanceSmooth, distance, ref smoothVelocity, zoomDamp);

        }

        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            Cursor.visible = false;
        }

        xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
        ySmooth = Mathf.SmoothDamp(ySmooth, y, ref yVelocity, smoothTime);

        ySmooth = ClampAngle(ySmooth, yMinLimit, yMaxLimit);

        var rotation = Quaternion.Euler(ySmooth, xSmooth, 0);

        transform.rotation = rotation;
        transform.position = rotation * new Vector3(0, 0, -distanceSmooth) + posSmooth;
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
