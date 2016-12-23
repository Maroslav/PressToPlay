
public class FloatTweener
        : SimpleTweenerBase<float>
{
    protected override float GetVal(float tweenPosition)
    {
        return (TargetValue - SourceValue) * tweenPosition + SourceValue;
    }
}
