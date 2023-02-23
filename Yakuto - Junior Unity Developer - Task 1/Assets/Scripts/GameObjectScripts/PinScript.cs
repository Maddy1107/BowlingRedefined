using UnityEngine;

public class PinScript : MonoBehaviour
{
    private Rigidbody rb;

    public float standingThreshold = 0.9f;

    public bool isStanding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass = new Vector3(0, 1, 0);

        isStanding = true;
    }

    public bool IsStanding()
    {
        if (transform.up.y > standingThreshold || transform.up.y < -standingThreshold)
            return true;

        return false;
    }

    public void ChangeState()
    {
        isStanding = false;
        PinManager.instance.ReducePinsLeft();
    }
}
