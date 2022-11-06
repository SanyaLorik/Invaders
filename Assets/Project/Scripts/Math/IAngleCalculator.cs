using UnityEngine;

public interface IAngleCalculator
{
    float CalculateAngleBetweenTwoPointOnScreen(Vector2 source, Vector2 target);
}