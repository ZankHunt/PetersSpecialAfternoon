using UnityEngine;

public class FisherSpots : MonoBehaviour {

    public static Transform[] spots;

    void Awake()
    {
        spots = new Transform[transform.childCount];
        for (int i = 0; i < spots.Length; i++)
        {
            spots[i] = transform.GetChild(i);
        }
    }
}
