using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    float desiredDistance = 4f;
    float pitch = 0f;
    float pitchMin = -40f;
    float pitchMax = 60f;
    float yaw = 0f;
    float roll = 0f;
    public float CameraHeight = 1f;
    float cameraDistanceMax = 20f;
    float cameraDistanceMin = 5f;
    float cameraDistance = 10f;
    public float scrollSpeed = 10f;


    public float sensitivity = 15f;

    // Update is called once per frame
    void Update()
    {
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);



        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        transform.localEulerAngles = new Vector3(pitch, yaw, roll);
        transform.position = target.transform.position - cameraDistance * transform.forward + Vector3.up * CameraHeight;
    }
}