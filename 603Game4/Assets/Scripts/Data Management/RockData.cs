using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RockData : MonoBehaviour
{

     [SerializeField]List<string> rockNames;
     [SerializeField]List<Sprite> rockSprites;
     
     // Total number of rocks in the system
     public int NumRocks { get { return rockSprites.Count; } }
}
