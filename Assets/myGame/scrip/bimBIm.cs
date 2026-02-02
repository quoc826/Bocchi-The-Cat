using UnityEngine;

public class bimBIm : MonoBehaviour
{
    [Header("Animation")]
    public Animator anim;
    public int RioEatAnimation; 

    private Vector3 offset;
    private Vector3 startPosition; 
    private bool isOverRio = false; 

    public AudioClip Snack;
    

    public AudioClip eatSound;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        if (isOverRio)
        {
            EatAndRespawn();
        }
    }

    private void EatAndRespawn()
    {
        gameObject.SetActive(false);
        soundManager.Instance.setRioEat(eatSound);
        Debug.Log("Rio đã ăn Bim Bim!");
        Invoke("Respawn", 0.5f); 
    }

    private void Respawn()
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
        isOverRio = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane; 
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rio"))
        {
            isOverRio = true; 
        }

        if (collision.gameObject.CompareTag("Doritos"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                soundManager.Instance.setSnack(Snack);
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rio"))
        {
            isOverRio = false;
        }
    }
}