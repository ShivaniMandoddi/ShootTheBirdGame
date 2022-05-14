using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*3f*Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        transform.position = new Vector2(22f, transform.position.y);
    }
}
