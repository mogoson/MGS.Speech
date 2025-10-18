/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ISpeechRecognizer.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Speech
{
    public interface ISpeechRecognizer
    {
        bool IsRunning { get; }

        void Start();

        void Stop();

        void Dispose();
    }
}