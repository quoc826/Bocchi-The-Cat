using UnityEngine;

public class DoritosSpamSingleClick : MonoBehaviour
{
    
    public GameObject item;
    
    public float popForce = 5f; 
    public float destroyTime = 3f; 

    [Header("Audio Clips")]
    public AudioClip popClip;
    

    void OnMouseDown()
    { 
        
        soundManager.Instance.setPlayPop(popClip);

        Vector3 spamPosition = transform.position;
        spamPosition += new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);

        
        GameObject cloneObject = Instantiate(item, spamPosition, Quaternion.identity);

      
        Rigidbody2D rb = cloneObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; 
        
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;
            rb.AddForce(randomDirection * popForce, ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-50f, 50f));
        }

        Destroy(cloneObject, destroyTime);
    }
}