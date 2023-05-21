using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowrData : MonoBehaviour
{
    public struct FlowerData{
        private string flowerName;
        private float production;
        private float durability;

        public void SetData(string a, float b, float c){
            flowerName = a;
            production = b;
            durability = c;
        }


        public string FlowerName() => flowerName;
        public float Production() => production;
        public float Durability() => durability;
        
    }

    
}
