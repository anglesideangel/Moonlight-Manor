using UnityEngine;
using TMPro;
using Unity.Netcode;

public class DoorController : NetworkBehaviour
{
    
    public TMP_Text text;
    public bool triggerAction = false;
    public NetworkVariable<bool> opened = new NetworkVariable<bool>(false);
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

    public override void OnNetworkSpawn(){
        opened.OnValueChanged += DoorStateChange;
    }

    public override void OnNetworkDespawn()
    {
        opened.OnValueChanged -= DoorStateChange;
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
            if (opened.Value) ToggleDoorServerRpc();
        }
    }

    [Rpc(SendTo.Server)]
    void ToggleDoorServerRpc(){
        opened.Value = !opened.Value;
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (triggerAction && gameObject != null ){
                ToggleDoorServerRpc();                
            } 
        }
    }

    void DoorStateChange(bool previous, bool current){
        if (opened.Value){
            gameObject.GetComponentInParent<Animator>().Play("DoorOpen");
        } else {
            gameObject.GetComponentInParent<Animator>().Play("DoorClose");
        }
    }
   
}
