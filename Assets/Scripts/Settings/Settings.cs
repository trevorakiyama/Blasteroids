using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public float bulletSpeed;
    public float movementSpeed;

    public static float _bulletSpeed;
    public static float _movementSpeed;


    public void Start()
    {
        _bulletSpeed = bulletSpeed;
        _movementSpeed = movementSpeed;
    }

    public void Update()
    {
        _bulletSpeed = bulletSpeed;
        _movementSpeed = movementSpeed;
    }
}
