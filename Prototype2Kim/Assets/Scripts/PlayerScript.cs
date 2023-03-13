using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    public float xRange = 10.0f;
    public Transform projectileSpawnPoint;

    public float zMin;
    public float zMax;


    public GameObject projectilePrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefabs, projectileSpawnPoint.position, projectilePrefabs.transform.rotation);
        }
        //keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if(transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }

        if(transform.position.z >zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }
    }
}
