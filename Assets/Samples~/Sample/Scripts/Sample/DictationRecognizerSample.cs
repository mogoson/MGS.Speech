/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DictationRecognizerSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.Windows.Speech;

namespace MGS.Speech.Sample
{
    public class DictationRecognizerSample : MonoBehaviour
    {
        DictationRecognizer recognizer;

        private void Start()
        {
            recognizer = new DictationRecognizer();
            recognizer.DictationHypothesis += Recognizer_DictationHypothesis;
            recognizer.DictationResult += Recognizer_DictationResult;
            recognizer.DictationComplete += Recognizer_DictationComplete;
            recognizer.DictationError += Recognizer_DictationError;
            recognizer.Start();
        }

        private void Recognizer_DictationHypothesis(string text)
        {
            Debug.Log($"Hypothesis {text}");
        }

        private void Recognizer_DictationResult(string text, ConfidenceLevel confidence)
        {
            Debug.Log($"Result {confidence} {text}");
        }

        private void Recognizer_DictationComplete(DictationCompletionCause cause)
        {
            Debug.Log($"Complete cause {cause}");
        }

        private void Recognizer_DictationError(string error, int hresult)
        {
            Debug.Log($"Error {error} {hresult}");
        }

        private void OnDestroy()
        {
            if (recognizer != null)
            {
                if (recognizer.Status == SpeechSystemStatus.Running)
                {
                    recognizer.Stop();
                }
                recognizer.Dispose();
            }
        }
    }
}