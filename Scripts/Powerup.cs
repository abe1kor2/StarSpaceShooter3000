using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update

    private float _spd = 3.0f;
    private float _right = 9.44f;
    private float _left = -9.44f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* _spd * Time.deltaTime);

        if (transform.position.y< -5f)
        {
            transform.position = new Vector3(Random.Range(_left, _right), 7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();
            if (player != null) {
                player.TripleShotActive();
            }

            Destroy(this.gameObject); 
        }
    }

}
