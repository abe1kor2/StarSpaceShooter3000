using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _spd = 8.0f;

    void Update()
    {
        transform.Translate(Vector3.up * _spd * Time.deltaTime);



        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
