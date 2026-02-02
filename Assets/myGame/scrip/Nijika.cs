using UnityEngine;

public class Nijika : MonoBehaviour
{

    public AudioClip ahhClip;

    private Animator anim;
    private int nijikaMove;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        nijikaMove = Animator.StringToHash("nijikaMove");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        anim.SetTrigger(nijikaMove);
        soundManager.Instance.setNijika_ahh(ahhClip);
    }
}
