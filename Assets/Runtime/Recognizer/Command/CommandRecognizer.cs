/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandRecognizer.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Windows.Speech;

namespace MGS.Speech
{
    public class CommandRecognizer<T> : ICommandRecognizer<T>
    {
        public bool IsRunning { get { return recognizer.IsRunning; } }

        public event Action<T> OnRecognized;
        protected KeywordRecognizer recognizer;
        protected IEnumerable<CommandMeta<T>> metas;

        public CommandRecognizer(IEnumerable<CommandMeta<T>> metas)
        {
            this.metas = metas;
            var keywords = CollectKeywords(metas).ToArray();
            recognizer = new KeywordRecognizer(keywords);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        }

        protected virtual IEnumerable<string> CollectKeywords(IEnumerable<CommandMeta<T>> metas)
        {
            var keywords = new List<string>();
            foreach (var meta in metas)
            {
                keywords.AddRange(meta.keywords);
            }
            return keywords;
        }

        protected virtual void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            T command = default;
            foreach (var meta in metas)
            {
                if (meta.keywords.Contains(args.text))
                {
                    command = meta.command;
                    break;
                }
            }
            InvokeOnRecognized(command);
        }

        protected void InvokeOnRecognized(T command)
        {
            OnRecognized?.Invoke(command);
        }

        public virtual void Start()
        {
            recognizer.Start();
        }

        public virtual void Stop()
        {
            recognizer.Stop();
        }

        public virtual void Dispose()
        {
            recognizer.Dispose();
        }
    }
}