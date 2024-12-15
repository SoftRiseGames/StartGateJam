using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SkillGateManager : MonoBehaviour
{
    public List<GameObject> SkillButtons;
    public List<So_DoorTypes> GateTypes;
    public float gridSize=1f;
    
    public static int ListNumber;
    public GameObject Gate;

    public static SkillGateManager instance;
    [SerializeField] private Vector2 placementBoundsMin; 
    [SerializeField] private Vector2 placementBoundsMax;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }
    private void OnEnable()
    {
      
        ButtonManager.InteractFalse += FalseInteract;
        ButtonManager.InteractTrue += TrueInteract;
    }
    private void OnDisable()
    {
        ButtonManager.InteractFalse -= FalseInteract;
        ButtonManager.InteractTrue -= TrueInteract;
    }

    
    void FalseInteract()
    {
        
        foreach (GameObject skillbutton in SkillButtons)
        {
            skillbutton.GetComponent<Button>().interactable = false;
            Debug.Log("false");
        }
        PreviewGate();
    }
    void TrueInteract()
    {
        foreach (GameObject skillbutton in SkillButtons)
        {
            skillbutton.GetComponent<Button>().interactable = true;
        }
        DiscardGate();
    }

    [SerializeField] GameObject currentHandGate; //sadece bir tane gate tutabildiðimiz için.

    private void PreviewGate()
    {
        GameManager.Instance.canDrag = false;
        GameObject GateSystem = Instantiate(SkillGateManager.instance.Gate, gameObject.transform.position, gameObject.transform.rotation);
        GateSystem.GetComponent<GateScript>().GateType = SkillGateManager.instance.GateTypes[SkillGateManager.ListNumber];

        currentHandGate = GateSystem; 
    }


    private void Update() // Preview için obje posizyonu degismesi.
    {
        if(currentHandGate != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 gridPosition = new Vector3(
                Mathf.Round(mousePosition.x / gridSize) * gridSize,
                Mathf.Round(mousePosition.y / gridSize) * gridSize,
                currentHandGate.transform.position.z 
            );

            currentHandGate.transform.position = gridPosition;
            if (IsWithinBounds(gridPosition))
            {
                currentHandGate.transform.position = gridPosition;

                if (Input.GetMouseButtonDown(0)) // Sol týklama
                {
                    PlaceGate();
                    GameManager.Instance.canDrag = true;
                }
            }
        }
    }

    private void PlaceGate()
    {
        foreach (GameObject skillbutton in SkillButtons)
        {
            skillbutton.GetComponent<Button>().interactable = true;
        }
        currentHandGate.GetComponent<CircleCollider2D>().enabled = true;
        currentHandGate = null;
    }

    private void DiscardGate()
    {
        Destroy(currentHandGate.gameObject);
        currentHandGate = null; // Elimizdekini býraktýk.
        GameManager.Instance.canDrag = true;
    }

    private bool IsWithinBounds(Vector3 position)
    {
        return position.x >= placementBoundsMin.x && position.x <= placementBoundsMax.x &&
               position.y >= placementBoundsMin.y && position.y <= placementBoundsMax.y;
    }
}
