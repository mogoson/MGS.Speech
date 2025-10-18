/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  KeywordRecognizerSample.cs
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
    public class KeywordRecognizerSample : MonoBehaviour
    {
        public string[] keywords;
        KeywordRecognizer recognizer;

        private void Start()
        {
            recognizer = new KeywordRecognizer(keywords);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }

        private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            Debug.Log($"Recognized {args.text}");
        }

        private void OnDestroy()
        {
            if (recognizer != null)
            {
                if (recognizer.IsRunning)
                {
                    recognizer.Stop();
                }
                recognizer.Dispose();
            }
        }
    }
}