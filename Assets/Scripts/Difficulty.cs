using UnityEngine;

public static class Difficulty 
{
    private static float maxDifficultyTime = 30f;

    public static float GetDifficultyPercentage(){
        return Mathf.Clamp01(Time.timeSinceLevelLoad/maxDifficultyTime);
    }
}
