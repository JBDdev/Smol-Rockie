using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockData : MonoBehaviour
{

     [SerializeField] public List<string> rockNames;
     [SerializeField] public List<Sprite> rockSprites;
     
     // Total number of rocks in the system
     public int NumRocks { get { return rockSprites.Count; } }
}
