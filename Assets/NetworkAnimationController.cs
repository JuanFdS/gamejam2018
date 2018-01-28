using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAnimationController : MonoBehaviour {

    public Animator AnimationController;
    Vector3 previousPosition = new Vector3(0, 0, 0);
    bool m_FacingRight = true;

    // Use this for initialization
    void Start () {
        AnimationController = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        float moveX = this.transform.position.x - previousPosition.x;
        float moveY = this.transform.position.y - previousPosition.y;

        if (moveX != 0 && Mathf.Abs(moveY) < 0.01)
        {
            AnimationController.SetFloat("Speed", 1);
        }
        else
            AnimationController.SetFloat("Speed", 0);

        if(Mathf.Abs(moveY) > 0.01)
        {
            AnimationController.SetFloat("vSpeed", 1);
        }
        else
            AnimationController.SetFloat("vSpeed", 0);

        previousPosition = this.transform.position;

        //evito que las los pequenios cambios en la red generen falsas animaciones
        if(Mathf.Abs(moveX) > 0.05)
        {
            if (moveX > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (moveX < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
