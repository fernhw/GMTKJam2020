using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float x_translation = Input.GetAxis("Horizontal") * speed;
        float z_translation = Input.GetAxis("Vertical") * speed;
        Vector3 translation = new Vector3(x_translation, 0, z_translation);
        transform.Translate(translation * (speed*Time.deltaTime));
    }
}
