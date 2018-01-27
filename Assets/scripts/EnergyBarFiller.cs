using UnityEngine;
using System.Collections;

public class EnergyBarFiller : MonoBehaviour
{
    public float energy = 100;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(energy / 100, transform.localScale.y,transform.localScale.z);
    }
}
