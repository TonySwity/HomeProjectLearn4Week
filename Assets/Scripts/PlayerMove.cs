using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraCenter;
    [SerializeField] private float _torqueValue;
    
    private Rigidbody _body;
    private float _verticalInput;
    private float _horizontalInput;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _body.maxAngularVelocity = 500f;
    }

    private void Update()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _body.AddTorque(_cameraCenter.right * (_verticalInput * _torqueValue));
        _body.AddTorque((-_cameraCenter.forward * (_horizontalInput * _torqueValue)));
    }

    public void InitCameraCenter(Transform cameraCenter)
    {
        _cameraCenter = cameraCenter;
    }

}
