using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    [Header("Scale setUp tools")]
    [Tooltip("how fast we move plane")] [SerializeField] float scaledThrow = 7f;
     float XThrow, YThrow;
    [Tooltip("how long we move horizontally")] [SerializeField] float xRange = 10f;
    [Tooltip("how long we move vertically")] [SerializeField] float yRange = 6f;

    [Header("position based tuning")]
    [Tooltip("determines direction of head of plane")] [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("determines direction of head of plane")] [SerializeField] float positionYawFactor = 1f;
    
    [Header("input based tuning")]
    [Tooltip("how fast we change head of plane up or down")] [SerializeField] float ControllPitchFactor = -12f;
    [Tooltip("how fast we change head of plane right or left")] [SerializeField] float ControllYawFactor = -15f;

    [Header("Object parts")]
    [Tooltip("lasers of plane")] [SerializeField] GameObject[] lasers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        translateProcess();

        rotateProcess();

        fireProcess();

        // crashProcess();
    }

    void fireProcess()
    {
        bool isActivate;
        if(Input.GetButton("Fire1"))
        {
            isActivate = true;
        }
        else 
        {
            isActivate = false;
        }
         
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActivate;
        }
    
    }

    void rotateProcess()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControll = YThrow * ControllPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControll = XThrow * ControllYawFactor;

        float pitch = pitchDueToPosition + pitchDueToControll;
        float yaw = yawDueToPosition;
        float roll = yawDueToControll;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void translateProcess()
    {
        XThrow = Input.GetAxis("Horizontal");
        YThrow = Input.GetAxis("Vertical");

        float offsetX = XThrow * Time.deltaTime * scaledThrow;
        float rawPosition = transform.localPosition.x + offsetX;
        // Debug.Log(message: rawPosition +" rawPosition");
        float xCalmped = Mathf.Clamp(rawPosition, -xRange, xRange);

        float offsetY = YThrow * Time.deltaTime * scaledThrow;
        float columnPosition = transform.localPosition.y + offsetY;
        float yCalmped = Mathf.Clamp(columnPosition, -yRange, yRange );

        float newZPosition = transform.localPosition.z;

        transform.localPosition = new Vector3(xCalmped, yCalmped, newZPosition);
        // Debug.Log(verticalThrow);
    }
}
