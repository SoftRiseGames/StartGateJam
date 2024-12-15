using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "PeggleGridData", menuName = "Peggle/Grid Data")]
public class PeggleGridData : ScriptableObject
{
    public List<GridCellData> cells; // Grid hücrelerini saklayacak liste
}
