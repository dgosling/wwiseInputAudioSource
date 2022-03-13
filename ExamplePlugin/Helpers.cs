using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Path = System.IO.Path;
using R2API;
using AK;
using UnityEngine;
namespace WWiseTest
{
    internal static class Helpers
    {
        public static WwiseEventReference wwiseEventReference;
        public static GameObject gameObject;
        public static void SetupSoundBank()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string soundBankName = "New_SoundBank";
            SoundAPI.SoundBanks.Add(Path.Combine(path, soundBankName + ".bnk"));
        }
        public static void SetupEvent()
        {
            wwiseEventReference = (WwiseEventReference)ScriptableObject.CreateInstance(typeof(WwiseEventReference));
            wwiseEventReference.id = 4090997213;
            gameObject = new GameObject();
            MyAudioInputBehaviour myAudioInputBehaviour = gameObject.AddComponent<MyAudioInputBehaviour>();
            AK.Wwise.Event a = new AK.Wwise.Event();
            a.WwiseObjectReference = wwiseEventReference;
            myAudioInputBehaviour.AudioInputEvent = a;
        }
    }
}
