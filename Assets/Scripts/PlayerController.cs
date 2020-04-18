using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed = 1000f;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float hdir = Input.GetAxisRaw("Horizontal");
        float vdir = Input.GetAxisRaw("Vertical");


        float cameraDirection = cam.transform.localEulerAngles.y;
        Vector3 directionVector = new Vector3(hdir, 0, vdir);
        Vector3 unitVector = directionVector.normalized;
        Vector3 CamDir = unitVector;
        CamDir = Quaternion.AngleAxis(cameraDirection, Vector3.up) * CamDir;

        Vector3 forceVector = CamDir * moveSpeed * Time.deltaTime;
        rb.AddForce(forceVector);
    }
}