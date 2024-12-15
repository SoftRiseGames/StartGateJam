using UnityEngine;
using System;

public class BallRecovery : MonoBehaviour
{

    [SerializeField]Transform SpawnPoint;
    [SerializeField] GameObject ForceManager;
    [SerializeField] GameObject curBall;
    [SerializeField] GameObject BallOBJ;

    bool isBack;
    bool isCollide;
    GameObject ball;
    private void OnEnable()
    {
        ButtonManager.EndTurn += TurnBack;

    }
    private void OnDisable()
    {
        ButtonManager.EndTurn -= TurnBack;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "ball")
        {
            isCollide = true;
            ball = collision.gameObject;
            ball.SetActive(false);
        }

        else
            Destroy(collision.gameObject);
    }
  
    void TurnBack()
    {
        if(isCollide == true)
        {
            ball.SetActive(true);
            ball.transform.position = new Vector2(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y);
            ball.transform.GetComponent<BallScript>().DeActivatedRb();
            ForceManager.GetComponent<ForceSystemManager>().isDragForce = true;
            isCollide = false;
            ball = null;
        }
        
    }
}
