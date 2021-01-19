
using UnityEngine;
[CreateAssetMenu(fileName ="NPC資料", menuName ="Stiff/NPC資料")]
public class NpcData : ScriptableObject

{
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialogA;
    [Header("第二段對話"), TextArea(1, 5)]
    public string dialogB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string dialogC;
    [Header("任務項目需求數量")]
    public int count;
    [Header("已經取得項目數量")]
    public int countCurrent;
}
