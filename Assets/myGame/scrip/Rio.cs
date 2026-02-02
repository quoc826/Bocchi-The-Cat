using UnityEngine;

public class Rio : MonoBehaviour
{
    [Header("Settings")]
    public float detectionRange = 3.0f; 
    public LayerMask doritosLayer;      

    [Header("Animation")]
    public Animator anim;
    
 
    private int RioMoveID;
    private int RioEatID;
    private int RioDontEatID;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        // Chuyển tên string sang Hash ID
        RioMoveID = Animator.StringToHash("RioMove");
        RioEatID = Animator.StringToHash("RioEat"); 
        RioDontEatID = Animator.StringToHash("RioDontEat");
    }

    void Update()
    {
        CheckSurroundings();
    }


    void CheckSurroundings()
    {
        bool isDoritosNearby = Physics2D.OverlapCircle(transform.position, detectionRange, doritosLayer);

        anim.SetBool(RioMoveID, isDoritosNearby);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Doritos"))
        {

            anim.SetBool(RioEatID, true);

            // Destroy(collision.gameObject, 0.1f); 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Doritos"))
        {
             anim.SetBool(RioEatID, false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}