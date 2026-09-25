using UnityEngine;
using UnityEngine.UI;

public class NPCBehavior : MonoBehaviour
{
    public int health = 3; 
    public Text healthText; 
    
    public float moveSpeed = 2f;
    public float patrolDistance = 4f;
    private Vector3 startPos;

    public GameObject explosionPrefab; 

    void Start()
    {
        startPos = transform.position;
        if (healthText != null) healthText.text = health + " HP"; 
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * moveSpeed, patrolDistance) - (patrolDistance / 2f);
        transform.position = startPos + new Vector3(offset, 0, 0); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health -= 1;
            
            if (healthText != null) 
            {
                healthText.text = health + " HP";
            }

            if (health <= 0)
            {
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
    }
}