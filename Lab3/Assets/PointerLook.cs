using UnityEngine;
using UnityEngine.InputSystem;

public class PointerLook : MonoBehaviour
{
    public float MouseSensitivity = 20.0f;
    public InputAction Look;

    private Transform childCamera;

    private void Awake()
    {
        childCamera = GetComponentInChildren<Camera>().transform;

        Look.Enable();
        Look.performed += x => RotateLook(x.ReadValue<Vector2>());
    }

    private void RotateLook(Vector2 delta)
    {
        transform.Rotate(0, delta.x * Time.deltaTime * MouseSensitivity, 0);
        childCamera.Rotate(-delta.y * Time.deltaTime * MouseSensitivity, 0, 0);
    }
}