using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color color;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            GetComponent<Renderer>().material.color = color;
        }
    }
}