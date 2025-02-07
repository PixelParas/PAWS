using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace CSharpCompiler
{
    public class LoadScript : MonoBehaviour
    {
        public TMP_InputField inputField;
        public bool loadInBackground = true;
        public bool doStream = false;

        public string scriptName;
        List<string> loaded = new List<string>();

        DeferredSynchronizeInvoke synchronizedInvoke;
        CSharpCompiler.ScriptBundleLoader loader;

        string script;
        void Start()
        {
            synchronizedInvoke = new DeferredSynchronizeInvoke();

            loader = new CSharpCompiler.ScriptBundleLoader(synchronizedInvoke);
            loader.logWriter = new UnityLogTextWriter();
            loader.createInstance = (Type t) =>
            {
                if (typeof(Component).IsAssignableFrom(t)) return this.gameObject.AddComponent(t);
                else return System.Activator.CreateInstance(t);
            };
            loader.destroyInstance = (object instance) =>
            {
                if (instance is Component) Destroy(instance as Component);
            };

            script = Path.GetFullPath(Application.streamingAssetsPath) + "/" + scriptName + ".cs";
            if (!File.Exists(script))
            {
                Debug.Log(script + " Does not exist");
                File.CreateText(script);

            }
            loader.LoadAndWatchScriptsBundle(new[] { script });
            loaded.Add(script);
        }
        void Update()
        {
            synchronizedInvoke.ProcessQueue();
        }
        public void Compile()
        {
            Debug.Log("Compiling");
            if (!File.Exists(script))
            {
                Debug.Log(script + " Does not exist");
                File.CreateText(script);
                loader.LoadAndWatchScriptsBundle(new[] { script });
                loaded.Add(script);
            }
            File.WriteAllText(script, inputField.text);
        }
        void OnGUI()
        {
            var sourceFolder = Application.streamingAssetsPath;
            int num = 0;
            var files = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (!file.EndsWith(".meta"))
                {
                    if (num > 20) break;
                    num++;
                    var shortPath = file.Substring(sourceFolder.Length);
                    if (loaded.Contains(file))
                    {
                        GUILayout.Label("Loaded: " + shortPath);
                    }
                    else
                    {
                        if (GUILayout.Button("Load: " + shortPath))
                        {
                            loader.LoadAndWatchScriptsBundle(new[] { file });
                            loaded.Add(file);
                        }
                    }
                }
            }



        }

    }

}