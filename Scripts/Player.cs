using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.15f;

    [SerializeField]
    private float _nextFire = 0f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private GameObject _tripleShotPrefab;

    private SpawnManager _spawnManager;

    [SerializeField]
    private bool _tripleShot = false;

    void Start()
    {

        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is Null.");
        }

    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            Shoot();
        }
  

    }

    void Shoot()
    {

        _nextFire = Time.time + _fireRate;

        
        if (_tripleShot != false)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity); 
        }
        

        else 
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }


        //instantiate 3 lasers(Triple shot prefab)
    }


    void CalculateMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        
        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }

        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {

            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    
    }

    public void TripleShotActive() 
    {
   
        _tripleShot = true;
        startCoroutine(TripleShotPowerdown());
    }

    IEnumerator TripleShotPowerdown() {
        yield return new WaitForSeconds(5.0f);
        _tripleShot = false;
    }

}
