using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float normalSpeed = 60f;
    public float sprintSpeed = 80f;
    public float xLimit = 80;
    private float currentSpeed;

    public GameObject blastPrefab;
    public float blastSpeed = 100f;
    public Transform[] blastSpawnPoints;

    void Start()
    {
        currentSpeed = normalSpeed;
    }
    
    void Update()
    {

        // Cambiar la velocidad según si se presiona la tecla Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }

        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * currentSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBlasts();
        }
    }

    void FireBlasts()
    {
        foreach (Transform spawnPoint in blastSpawnPoints)
        {
            GameObject blast = Instantiate(blastPrefab, spawnPoint.position, spawnPoint.rotation);
            Rigidbody rb = blast.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * blastSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameOverManager.instance.GameOver();
            Destroy(gameObject); // Destruir el player
        }
    }
}
