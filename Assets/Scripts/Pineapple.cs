using UnityEngine;

public class Pineapple : MonoBehaviour
{
    [SerializeField] GameObject leaves;
    [SerializeField] float releaseStrength = 10f;

    void CutLeaves()
    {
        leaves.transform.parent = null;
        leaves.GetComponent<Collider>().enabled = true;
        Rigidbody rb = leaves.AddComponent<Rigidbody>();
        Vector3 dir = (leaves.transform.position - transform.position).normalized;
        rb.AddForce(dir * releaseStrength, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Blade"))
        {
            CutLeaves();
        }
    }
}
