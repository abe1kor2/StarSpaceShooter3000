 using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _downspeed = 4.0f;

    private float _right = 9.44f;
    private float _left = -9.44f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(Vector3.down * _downspeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(_left, _right), 7f, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
  

        if (other.tag == "Player") {

            //damage us
            Player player = other.transform.GetComponent< Player > ();
            if (player != null) 
            {
                player.Damage();
            }
            Destroy(this.gameObject);

        }




        //if other is laser
        //laser
        //destroy us

        if (other.tag == "Laser") 
        {

            Destroy(other.gameObject);  //which is the laser
            Destroy(this.gameObject);   //which is the enemy cube


            //damage 

        }





    }
}
