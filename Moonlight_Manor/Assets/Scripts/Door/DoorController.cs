using UnityEngine;
using TMPro;

public class DoorController : MonoBehaviour
{
    
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened = false;
    public GameObject currentDoor;
    public bool isUnlocked = false;
    public int order;
    
    void Start()
    {
        text = gameObject.transform.parent.GetComponentInChildren<TMP_Text>();
        if (order == 0){
            text.gameObject.SetActive(true);
            isUnlocked = true;
        }
        else{text.gameObject.SetActive(false);}
        DoorManager.Instance.AddDoor(this, order);
    }



    public void UnlockDoor()
    {
        isUnlocked = true;
        text.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && isUnlocked)
        {
            triggerAction = true;
            // text.gameObject.SetActive(true);
            PuzzleManager.Instance.DisplayHint(order);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player") && isUnlocked)
        {
            triggerAction = false;
            // text.gameObject.SetActive(false);
            if (opened) opened = false;
            currentDoor = null;
        }
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (triggerAction && gameObject != null ){
                if (!opened ){
                    gameObject.GetComponentInParent<Animator>().Play("DoorOpen");
                    opened = true;
                } else {
                    gameObject.GetComponentInParent<Animator>().Play("DoorClose");
                    opened = false;
                }
                
            } 
        }
    }
   
}
