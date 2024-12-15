using UnityEngine;
using Sirenix.OdinInspector;

public class PeggleGridLoader : MonoBehaviour
{
    [SerializeField] private GameObject bubblePrefab; // Tek bir bubble prefab'i
    [SerializeField] private PeggleGridData gridData; // Grid verilerini tutan ScriptableObject

    private void Start()
    {
        if(gridData!=null) LoadGrid();

    }

    [Button("Load Grid Data")]
    private void LoadGrid()
    {
        foreach (var cell in gridData.cells)
        {
            // Bubble prefab'�n� sahnede olu�tur
            GameObject bubble = Instantiate(bubblePrefab, cell.position, Quaternion.identity, transform);

            // Bubble'�n `WallScript` bile�enini al ve ScriptableObject verilerini uygula
            var wallScript = bubble.GetComponent<WallScript>();
            if (wallScript != null)
            {
                wallScript.transform.position = cell.position;
                wallScript.InitBubble(cell.wallType); 
            }
        }
    }
}
