/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ICommandRecognizer.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Speech
{
    public interface ICommandRecognizer<T> : ISpeechRecognizer
    {
        event Action<T> OnRecognized;
    }
}