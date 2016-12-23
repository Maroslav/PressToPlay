using UnityEngine;

public class Vector3Tweener
        : SimpleTweenerBase<Vector3>
{
    protected override Vector3 GetVal(float tweenPosition)
    {
        return (TargetValue - SourceValue) * tweenPosition + SourceValue;
    }
}
