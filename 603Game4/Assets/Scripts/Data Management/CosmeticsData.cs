using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmeticsData : MonoBehaviour
{
    //May attempt to pack this data into a struct or something depending on what's easiest

    [SerializeField] List<string> fourStarNames;
    [SerializeField] List<string> fiveStarNames;
    [SerializeField] List<string> fourStarTypes;
    [SerializeField] List<string> fiveStarTypes;
    [SerializeField] List<Sprite> fourStarSprites;
    [SerializeField] List<Sprite> fiveStarSprites;

    // Returns total number of cosmetics in each category 
    public int NumFourStars 
    { get { return fourStarSprites.Count; } }
    public int NumFiveStars 
    { get {return fiveStarSprites.Count; } }
}
