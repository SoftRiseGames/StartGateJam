using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;



[CreateAssetMenu(fileName = "PeggleGridData", menuName = "Peggle/Grid Data")]
public class So_PeggleGridData : ScriptableObject
{
    public List<GridCellData> cells; // Grid h�crelerini saklayacak liste
}

[System.Serializable]
public class GridCellData
{
    public Vector2 position; // H�crenin pozisyonu
    public So_PowerAndManaWall wallType; // H�creye atanm�� WallType
}
public class PeggleGridSaver : MonoBehaviour
{

    public So_PeggleGridData gridData; // ScriptableObject'e ba�lanacak

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
