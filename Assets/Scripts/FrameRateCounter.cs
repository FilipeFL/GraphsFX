using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>  
/// This class is setting the frame reate counter that is on display in real-time.
/// </summary>

public class FrameRateCounter : MonoBehaviour
{
    #region Constant Fields

    #endregion

    #region Static Fields

    #endregion

    #region Fields

    [SerializeField]
    TextMeshProUGUI display;

    public enum DisplayMode { FPS, MS }

    [SerializeField]
    DisplayMode displayMode = DisplayMode.FPS;

    [SerializeField, Range(0.1f, 2f)]
    float sampleDuration = 1f;

    int frames;

    float duration, bestDuration = float.MaxValue, worstDuration;

    #endregion

    #region Events and Delegates

    #endregion

    #region Callbacks

    #endregion

    #region Constructors

    #endregion

    #region LifeCycle Methods

    void Update()
    {
        float frameDuration = Time.unscaledDeltaTime;
        frames += 1;
        duration += frameDuration;

        if (frameDuration < bestDuration)
        {
            bestDuration = frameDuration;
        }
        if (frameDuration > worstDuration)
        {
            worstDuration = frameDuration;
        }

        if (duration >= sampleDuration)
        {
            if (displayMode == DisplayMode.FPS) {
                display.SetText("FPS\n{0:0}\n{1:0}\n{2:0}",
                        1f / bestDuration,
                        frames / duration,
                        1f / worstDuration);
            }
            else
            {
                display.SetText("MS\n{0:1}\n{1:1}\n{2:1}",
                        1000f * bestDuration,
                        1000f * duration / frames,
                        1000f * worstDuration);
            }

            frames = 0;
            duration = 0f;
            bestDuration = float.MaxValue;
            worstDuration = 0f;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Internal Methods

    #endregion

    #region Protected Methods

    #endregion

    #region Private Methods

    #endregion

    #region Nested Types

    #endregion
}
