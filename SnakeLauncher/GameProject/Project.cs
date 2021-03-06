using SnakeLauncher.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SnakeLauncher.GameProject
{
    [DataContract(Name = "Game")]
    public class Project : ViewModelBase
    {
        
        public static string Extension { get; } = ".snake";
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Path { get; private set; }

        public string FullPath => $"{Path}{Name}{Extension}";

        [DataMember(Name = "Scenes")]
        private ObservableCollection<Scene> _scenes = new ObservableCollection<Scene>();
        public ReadOnlyObservableCollection<Scene> Scenes
        { get; }

        public Project(string name, string path)
        {
            Name = name;
            Path = path;

            _scenes.Add(new Scene(this, "Default Scene"));

        }

    }
}
