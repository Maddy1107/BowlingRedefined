using UnityEngine;

public class Pin : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
         rb = GetComponent<Rigidbody>();
        
        rb.centerOfMass = new Vector3(0, 1, 0);
    }
}
