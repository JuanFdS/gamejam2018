using UnityEngine;
using System.Collections;

public class EnergyBarFiller : MonoBehaviour
{
    public Bird birdTransform;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(birdTransform.energy/100, transform.localScale.y,transform.localScale.z);
        Debug.Log(birdTransform.energy / 100);
    }
}
