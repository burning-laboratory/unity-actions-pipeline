<p>
      <img src="https://i.ibb.co/FXgqcy3/Git-Hub-Logo.png" alt="Project Logo" width="726">
</p>

<p>
    <img src="https://build.burning-lab.com/app/rest/builds/buildType:id:UnityAssets_ComBurningLabActionspipeline_DevelopmentBuild/statusIcon.png" alt="Build Status">
    <a href="https://n-fridman.myjetbrains.com/youtrack/agiles/121-18/current"><img src="https://img.shields.io/badge/Roadmap-YouTrack-orange" alt="Roadmap Link"></a>
    <img src="https://img.shields.io/badge/Engine-2021.3-blueviolet" alt="Unity Version">
    <img src="https://img.shields.io/badge/Version-1.0.2-blue" alt="Game Version">
    <img src="https://img.shields.io/badge/License-MIT-success" alt="License">
</p>

## About

An action management system for Unity projects.

## Installation

1. Add Burning-Lab registry to Unity Project.
2. Add Open UPM Registry to Unity Project for importing external dependencies.
3. Install **Actions Pipeline Engine** package via Unity Package Manager.

**Burning-Lab Registry:**

```json
    {
      "name": "Burning-Lab Registry",
      "url": "https://packages.burning-lab.com",
      "scopes": [
        "com.burning-lab"
      ]
    }
```

**Open UPM Registry:**

```json
    {
      "name": "Open UPM Registry",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.mackysoft.serializereference-extensions"
      ]
    }
```

## Usage Example

[![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&duration=1500&color=00FFFF&background=12121200&vCenter=true&multiline=true&repeat=false&width=1250&height=275&lines=%5BSerializeField%5D+private+ActionPipeline+_somePipeline+%2F%2F+Add+stages+to+pipeline+with+unity+inspector.;+++;private+void+Start();%7B;_somePipeline.OnPipelineComplete+%2B%3D+(result)+%3D%3E+%2F%2F+Handle+pipeline+complete+event.;_somePipeline.OnPipelineStageStart+%2B%3D+(stage)+%3D%3E+%2F%2F+Handle+pipeline+stage+start+event.;_somePipeline.OnPipelineStageEnd+%2B%3D+(stage)+%3D%3E+%2F%2F+Handle+pipeline+stage+end+event.;+++;_somePipeline.RunPipeline()+%2F%2F+Start+running+action+pipeline.;%7D)](https://git.io/typing-svg)

Get more usage examples in package samples.

## Custom stage example

```csharp
    /// <summary>
    /// Set parent class ActionPipelineStage for any your custom actions pipeline stages.
    ///
    /// Be sure to add the Serializable attribute.
    ///
    /// If you need to specify your own path to an action in Type Menu, you can do this using the Add Type Menu attribute.
    /// </summary>
    [System.Serializable]
    [AddTypeMenu("RootFolderName/SubFolderName/Custom Action Name")]
    public class SimpleStage : ActionPipelineStage
    {
        protected override void OnInit()
        {
            base.OnInit();
            
            // Write preparing code for action running here.
        }

        protected override void OnDeInit()
        {
            base.OnDeInit();
            
            // Write the code that will be executed after the completion of the action step.
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            // Write custom action logic here.
        }
    }
```

## Distribute

* [packages.burning-lab.com](https://packages.burning-lab.com/-/web/detail/com.burning-lab.actionspipeline)

## Developers

* [n.fridman](https://github.com/n-fridman)

## License

Project Burning-Lab.ActionsPipeline is distributed under the MIT license.