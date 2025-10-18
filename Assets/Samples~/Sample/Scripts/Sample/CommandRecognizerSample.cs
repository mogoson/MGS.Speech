/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CommandRecognizerSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/10/15
 *  Description  :  Initial development version.
 *************************************************************************/

//#define DEVELOPMENT

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace MGS.Speech.Sample
{
    public class CommandRecognizerSample : MonoBehaviour
    {
        enum CommandSample
        {
            Hello,
            StartRotate,
            StopRotate
        }

        private CommandRecognizer<CommandSample> recognizer;

        private void Start()
        {
            enabled = false;

#if DEVELOPMENT
            var file = $"{Application.dataPath}/Samples/Sample/Meta/CommandMeta.json";
#else
            var file = $"{Application.dataPath}/Samples/Speech/1.0.0/Sample/Meta/CommandMeta.json";
#endif
            var content = File.ReadAllText(file);
            var metas = JsonConvert.DeserializeObject<List<CommandMeta<CommandSample>>>(content);

            recognizer = new CommandRecognizer<CommandSample>(metas);
            recognizer.OnRecognized += Recognizer_OnRecognized;
            recognizer.Start();
        }

        private void Recognizer_OnRecognized(CommandSample cmd)
        {
            Debug.Log($"Recognized {cmd}");
            switch (cmd)
            {
                case CommandSample.Hello:
                    Debug.Log("Unity: Hello!");
                    break;

                case CommandSample.StartRotate:
                    enabled = true;
                    break;

                case CommandSample.StopRotate:
                    enabled = false;
                    break;
            }
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
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