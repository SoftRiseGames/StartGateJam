using UnityEngine;
using DG.Tweening;
using System;
using System.Threading.Tasks;
public class GateScript : MonoBehaviour
{
    public So_DoorTypes GateType;
    public GameObject ball;
    public CircleCollider2D collider;
    bool isCooldown;


    public static Action isEnemScaleUp;
    public static Action isBulletMode;
    public static Action isMomentumChange;
    public static Action isPowerDoubler;
 
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            ball = collision.gameObject;
            if (GateType.GateType == DoorType.BallMultiplier && !isCooldown)
            {
                GameObject newBall = Instantiate(ball,new Vector2(this.gameObject.transform.position.x+.05f,this.gameObject.transform.position.y) , this.gameObject.transform.rotation);
                newBall.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(collision.GetComponent<Rigidbody2D>().linearVelocityX * -1, collision.GetComponent<Rigidbody2D>().linearVelocityY);
                newBall.GetComponent<BallScript>().ActivateRb();
                isCooldown = true;
                waitingTime();
            }
            if (GateType.GateType == DoorType.ScaleUpper && !isCooldown)
            {
                isEnemScaleUp?.Invoke();
                isCooldown = true;
                waitingTime();
            }
            if (GateType.GateType == DoorType.MomentumChanger && !isCooldown)
            {
                isMomentumChange?.Invoke();
                isCooldown = true;
                waitingTime();
            }
            if (GateType.GateType == DoorType.BulletPower && !isCooldown)
            {
                isBulletMode?.Invoke();
                isCooldown = true;
                waitingTime();
            }
            if (GateType.GateType == DoorType.DoublerAmount && !isCooldown)
            {
                isPowerDoubler?.Invoke();
                isCooldown = true;
                waitingTime();
            }
        }
    }
    

    public async void waitingTime()
    {
        await Task.Delay(1000);
        isCooldown = false;

    }


}
