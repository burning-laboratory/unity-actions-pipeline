# Actions Pipeline

Structure with pipeline action settings.

### Settings:

- **-** **`PipelineStages (List<ActionPipelineStage>)`** - Action stages.

### Events:

- **-** **`On Pipeline Complete (Action<ActionPipelineResult>)`** - The event of the end of the execution of the action pipeline.

- **-** **`On Pipeline Stage Start (Action<ActionPipelineStage>)`** - The event of the start of the execution of the pipeline action.

- **-** **`On Pipeline Stage End (Action<ActionPipelineStage>)`** - Pipeline action completion event.

### Methods:

- **-** **`ActionPipeline.RunPipeline()`** **`void`** - Start action pipeline.

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**