using UnityEngine;
using System;
public class GroundCollider : MonoBehaviour
{
    public static Action isTurnBasedCombat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
            isTurnBasedCombat?.Invoke();
    }
}
