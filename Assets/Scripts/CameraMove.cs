using System;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private List<Vector3> _velocityList = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            _velocityList.Add(Vector3.zero);
        }
    }

    private void Update()
    {
        Vector3 sumVelocity = Vector3.zero;

        foreach (var val in _velocityList)
        {
            sumVelocity += val;
        }
        
        if (_player && _playerRigidbody)
        {
            transform.position = _player.position;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(sumVelocity), Time.deltaTime * 10f);
        }
        
    }

    private void FixedUpdate()
    {
        if (_player && _playerRigidbody)
        {
            _velocityList.Add(_playerRigidbody.velocity);
            _velocityList.RemoveAt(0);
        }
    }
    
    public void InitPlayer(Player player)
    {
        _player = player.transform;
        _playerRigidbody = player.GetComponent<Rigidbody>();

    }
}
