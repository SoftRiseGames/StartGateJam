using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PowerPoint;
    public float ManaPoint;
   
    private void OnEnable()
    {
        DoorScript.isPowerDoubler += PowerDoubler;
    }
    private void OnDisable()
    {
        DoorScript.isPowerDoubler -= PowerDoubler;
    }

   
    void PowerDoubler() => PowerPoint = PowerPoint * 2;


}
