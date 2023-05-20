using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;


public class Machine : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

    public bool isInit;
    private void Awake() {
       
        slots = GetComponentsInChildren<Slot>();
        waitsec();
    }



    private void CheckChild(){
        var count = 0;
        for(int i = 0; i < slots.Length; i++){
            
            if(slots[i].transform.childCount>0){
                count++;
            }
        }
        Debug.Log(count);
    }
    
    private async UniTaskVoid waitsec()
    {
        while(true){
            await UniTask.WaitUntil(() => isInit);
            Debug.Log("IN");
            isInit = false;
        }
       
    }
}
