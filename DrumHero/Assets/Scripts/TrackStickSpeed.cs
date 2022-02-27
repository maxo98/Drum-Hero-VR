using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackStickSpeed : MonoBehaviour
{
    private Vector3 _lastPos;
    public float speed;

    private void Start()
    {
        _lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        var position = transform.position;
        speed = (position - _lastPos).magnitude / Time.deltaTime;
        _lastPos = position;
    }
}
