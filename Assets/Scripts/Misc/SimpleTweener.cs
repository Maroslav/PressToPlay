using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SimpleTweener : MonoBehaviour
{
    public bool Active;
    public AnimationCurve TweenCurve;
    // Higher values will end the timer faster
    public float SpeedCoef = 1;

    // Debug vals
    public float CurrentValue;
    public float CurrentCurveEval;
    public float CurrentTime;
    public float TargetTime;


    private Action<float> m_updateCallback;
    private Action m_finishedCallback;
    private float m_sourceValue;
    private float m_targetValue;
    private float m_sourceTime;
    private float m_length;


    void OnValidate()
    {
        Assert.IsNotNull(TweenCurve, name);
    }

    void Update()
    {
        if (!Active)
            return;

        float elapsed = Time.time - m_sourceTime;

        if (elapsed >= m_length)
        {
            if (m_updateCallback != null)
                m_updateCallback(m_targetValue); // Signal the exact value as the last one

            if (m_finishedCallback != null)
                m_finishedCallback();

            Active = false;
            return;
        }

        float pos = elapsed / m_length; // Between 0,1
        float valScale = TweenCurve.Evaluate(pos); // Curve can evaluate outside of 0,1
        float val = (m_targetValue - m_sourceValue) * valScale + m_sourceValue;
        CurrentTime = elapsed; // Debug info
        CurrentCurveEval = valScale;
        CurrentValue = val; // Debug info

        if (m_updateCallback != null)
            m_updateCallback(val);
    }

    public void Init(float sourceValue, Action<float> updateCallback = null, Action finishedCallback = null)
    {
        m_sourceValue = sourceValue;

        m_updateCallback = updateCallback;
        m_finishedCallback = finishedCallback;
    }

    public void DoStart(float targetValue, float sourceValue = float.NaN)
    {
        m_sourceValue = float.IsNaN(sourceValue) ? m_targetValue : sourceValue; // Use the old target value
        m_targetValue = targetValue;

        m_sourceTime = Time.time;
        m_length = TweenCurve.length / SpeedCoef;
        TargetTime = m_length; // Debug info
        Active = true;
        Debug.Log("Starting... Time: " + TweenCurve.length);
    }
}
