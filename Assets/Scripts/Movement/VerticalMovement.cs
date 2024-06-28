using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the GameObject between the given Y positions using a Sin function.
/// </summary>
public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private float upperY = 6;
    [SerializeField] private float lowerY = -4;
    [SerializeField] private float speed = 1;
    private float center;
    private float amplitude;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate constant values
        amplitude = (upperY - lowerY) / 2;
        center = (upperY + lowerY) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the next vertical position.
        var nextYPosition = amplitude * Mathf.Sin(Time.time * speed) + center;
        transform.position = new Vector3(transform.position.x, nextYPosition, transform.position.z);
    }
}
