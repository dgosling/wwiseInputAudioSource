using BepInEx;
using System;
using System.Runtime;
using R2API;
using R2API.Utils;
using RoR2;
using UnityEngine;
using AK;
using System.Reflection;

namespace WWiseTest
{
	//This is an example plugin that can be put in BepInEx/plugins/ExamplePlugin/ExamplePlugin.dll to test out.
    //It's a small plugin that adds a relatively simple item to the game, and gives you that item whenever you press F2.

    //This attribute specifies that we have a dependency on R2API, as we're using it to add our item to the game.
    //You don't need this if you're not using R2API in your plugin, it's just to tell BepInEx to initialize R2API before this plugin so it's safe to use R2API.
    [BepInDependency(R2API.R2API.PluginGUID)]
	
	//This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
	
	//We will be using 2 modules from R2API: ItemAPI to add our item and LanguageAPI to add our language tokens.
    [R2APISubmoduleDependency(nameof(SoundAPI), nameof(PrefabAPI))]
	
	//This is the main declaration of our plugin class. BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    //BaseUnityPlugin itself inherits from MonoBehaviour, so you can use this as a reference for what you can declare and use in your plugin class: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class WWiseTestPlugin : BaseUnityPlugin
	{
        //The Plugin GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config).
        //If we see this PluginGUID as it is on thunderstore, we will deprecate this mod. Change the PluginAuthor and the PluginName !
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "dgosling";
        public const string PluginName = "WWiseTest";
        public const string PluginVersion = "1.0.0";
        

        //We need our item definition to persist through our functions, and therefore make it a class field.


        //The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            Log.Init(Logger);

            Helpers.SetupSoundBank();


            On.RoR2.Run.Start += Run_Start;
            

            //Init our logging class so that we can properly log for debugging


            //First let's define our item

        }

        private void Run_Start(On.RoR2.Run.orig_Start orig, Run self)
        {
            orig(self);
            Helpers.SetupEvent();
        }

        private void Run_onRunStartGlobal(Run obj)
        {
            Helpers.SetupEvent();
            
        }

        private void Start()
        {
            
        }

        //The Update() method is run on every frame of the game.
        private void Update()
        {


            if (Input.GetKeyUp(KeyCode.J))
            {
                Logger.Log(BepInEx.Logging.LogLevel.Info, "j was pressed");
                GameObject.Instantiate<GameObject>(Helpers.gameObject);
            }
        }
    }
}
