using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Npc : MonoBehaviour
{
    [Header("NPC資料")]
    public NpcData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話間隔")]
    public float interval = 0.2f;
    [Header("對話者名稱")]
    public Text textName;

    public bool playerInArea;
    public enum NPCState
    {
      FirstDialog, Missioning, Finsh
    }
    public NPCState state = NPCState.FirstDialog;


    /*private void Start()
    {
        StartCoroutine(Test());
    }
    private IEnumerator Test()
    {
        print("嗨");
        yield return new WaitForSeconds(1.5f);

    }
    public enum NPCstate { }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "芭比")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "芭比")
        {
            playerInArea = false;
            StopDialog();
        }
       
    }
    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    }
    private IEnumerator Dialog()
    {
        dialog.SetActive(true);
        textContent.text = "";
        textName.text = name;

        string dialogString = data.dialogA;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialogA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialogB;
                break;
            case NPCState.Finsh:
                dialogString = data.dialogC;
                break;
            
                
        }

        for (int i = 0; i < dialogString.Length; i++)
        {
            textContent.text += dialogString[i]+"";
            yield return new WaitForSeconds(interval);
        }
    
    }

    
    










}
