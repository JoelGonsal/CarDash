using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int health = 100; 
    public float moveSpeed = 15f;
    public float turnSpeed = 100f;

    public GameObject[] hearts; 
    public Text messageText; 
    
    // Slot for your explosion effect
    public GameObject explosionPrefab; 

    void Start()
    {
        if (messageText != null) messageText.text = ""; 
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            health -= 10; 
            int boxIndex = health / 10;
            
            if (boxIndex >= 0 && boxIndex < hearts.Length)
            {
                hearts[boxIndex].SetActive(false);
            }
            
            if (messageText != null) 
            {
                messageText.text = "CAR HIT!";
                Invoke("ClearMessage", 2f); 
            }

            if (health <= 0)
            {
                if (messageText != null) messageText.text = "CAR DESTROYED!";
                CancelInvoke("ClearMessage"); 
                
                // Spawn the explosion at the car's current position and rotation
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
    }

    void ClearMessage()
    {
        if (messageText != null) messageText.text = "";
    }
}