using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1)
        {
            animator.Play("FrogRun");
        }
        else
        {
            animator.Play("FrogIdle");
        }
    }
}
