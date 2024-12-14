using UnityEngine;

public class SpritePlacement : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject GateSystem = Instantiate(SkillGateManager.instance.Gate, gameObject.transform.position, gameObject.transform.rotation);
        GateSystem.GetComponent<GateScript>().GateType = SkillGateManager.instance.GateTypes[SkillGateManager.ListNumber];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
