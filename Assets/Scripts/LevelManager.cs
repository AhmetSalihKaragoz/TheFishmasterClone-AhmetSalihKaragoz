using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public int currentDeptLenght;
    [HideInInspector] public int currentStrength;

    private int _depthLevelCounter = 1;
    private void Awake()
    {
        currentDeptLenght = 30;
        currentStrength = 8;
    }
    public int CalculateDepthLenght()
    {
        currentDeptLenght = currentDeptLenght + _depthLevelCounter * 15;
        _depthLevelCounter++;
        return currentDeptLenght;     
    }

    public int IncrementStrength()
    {
        currentStrength = currentStrength + 1;
        return currentStrength;
    }
}
