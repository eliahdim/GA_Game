using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;

    private void Update()
    {
        transform.Rotate(0, 0, 360 * rotationSpeed * Time.deltaTime);
    }
}
