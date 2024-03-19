using UnityEngine;

public class RowingFPSSet : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
