using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsData : MonoBehaviour
{
    //May attempt to pack this data into a struct or something depending on what's easiest

    [SerializeField] public List<string> fourStarNames;
    [SerializeField] public List<string> fiveStarNames;
    [SerializeField] public List<string> fourStarTypes;
    [SerializeField] public List<string> fiveStarTypes;
    [SerializeField] public List<Sprite> fourStarSprites;
    [SerializeField] public List<Sprite> fiveStarSprites;

    // Returns total number of cosmetics in each category 
    public int NumFourStars 
    { get { return fourStarSprites.Count; } }
    public int NumFiveStars 
    { get {return fiveStarSprites.Count; } }
}
