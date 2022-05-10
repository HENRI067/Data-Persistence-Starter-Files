using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed;
    private float rotation;

    private void FixedUpdate()
    {
        rotation += speed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0,rotation,0);
    }
}
