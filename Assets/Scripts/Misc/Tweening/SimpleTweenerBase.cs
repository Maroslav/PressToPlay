using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SimpleTweenerBase<T>
    : MonoBehaviour
    where T : struct
{
    public AnimationCurve TweenCurve;
    // Higher values will end the timer faster
    public float SpeedCoef = 1;

    // Debug vals
    public T CurrentValue;
    public float CurrentTime;
    public float TargetTime;


    private bool m_active;

    private Action<T> m_updateCallback;
    private Action<bool> m_finishedCallback;

    protected T SourceValue;
    protected T TargetValue;

    private float m_sourceTime;
    private float m_length;


    void OnValidate()
    {
        Assert.IsNotNull(TweenCurve, name);
    }

    void Update()
    {
        if (!m_active)
            return;

        float elapsed = Time.time - m_sourceTime;

        if (elapsed >= m_length)
        {
            if (m_updateCallback != null)
                m_updateCallback(TargetValue); // Signal the exact value as the last one

            if (m_finishedCallback != null)
                m_finishedCallback(false); // Signal that this was a graceful finish

            m_active = false;
            return;
        }

        float timePosition = elapsed / m_length; // Between 0,1
        float tweenPosition = TweenCurve.Evaluate(timePosition); // Curve can evaluate outside of 0,1
        T val = GetVal(tweenPosition);
        CurrentTime = elapsed; // Debug info
        CurrentValue = val; // Debug info

        if (m_updateCallback != null)
            m_updateCallback(val);
    }


    protected abstract T GetVal(float tweenPosition);

    public void Init(T sourceValue, Action<T> updateCallback = null, Action<bool> finishedCallback = null)
    {
        if (m_active)
            Stop();

        SourceValue = sourceValue;
        TargetValue = sourceValue;

        m_updateCallback = updateCallback;
        m_finishedCallback = finishedCallback;
    }

    public void TweenTo(T targetValue, T? sourceValue = null)
    {
        if (m_active)
            Stop();

        SourceValue = sourceValue ?? TargetValue; // Use the old target value by default
        TargetValue = targetValue;

        m_sourceTime = Time.time;
        m_length = TweenCurve.length / SpeedCoef;
        TargetTime = m_length; // Debug info
        m_active = true;
    }

    public void Stop()
    {
        m_active = false;
        if (m_finishedCallback != null)
            m_finishedCallback(true); // Signal that this was an abrupt finish
    }
}
