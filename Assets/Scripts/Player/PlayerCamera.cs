using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //adjusts main camera to focus on the player
    private Vector3 offset = new Vector3(0f, 0f, -20f); 
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private Transform secondaryTarget;

    // Update is called once per frame
    //transforms the camera's position towards the player
    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        if(Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 secondaryTargetPosition = secondaryTarget.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, secondaryTargetPosition, ref velocity, smoothTime);
        }
    }

}
