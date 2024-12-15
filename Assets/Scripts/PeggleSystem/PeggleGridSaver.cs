using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class PeggleGridSaver : MonoBehaviour
{

    public PeggleGridData gridData; // ScriptableObject'e ba�lanacak

    [ContextMenu("Save Grid Data")]
    [Button("Save Grid Data")]
    public void SaveGridData()
    {
        gridData.cells = new List<GridCellData>();

        // T�m �ocuk objeleri tarar
        foreach (Transform child in transform)
        {
            GridCellData cellData = new GridCellData
            {
                position = child.position,
                wallType = child.GetComponent<WallScript>().WallType // H�credeki WallType bilgisi
        };
            gridData.cells.Add(cellData);
        }

        EditorUtility.SetDirty(gridData); // ScriptableObject'i kaydet
        Debug.Log("Grid verileri kaydedildi!");
    }
}
