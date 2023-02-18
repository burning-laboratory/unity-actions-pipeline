# Action Pipeline Stage

The root abstract action pipeline stage class.

### Settings:

- **-** **`Stage Name (string)`** - Name of action pipeline stage.

- **-** **`Include For Progress Computing (bool)`** - If enabled, the passage of this stage is taken into account in the overall progress of the pipeline.

### Events:

- **-** **`On Stage Started (Action<IActionPipelineStage>)`** - The pipeline action trigger event.

- **-** **`On Stage End (Action<IActionPipelineStage, ActionsPipelineStageResult>)`** - Pipeline action completion event.

### Protected Methods:

- **-** **`Next (ActionsPipelineStageResult)`** - Call next stage.

### Protected Virtual Methods:

- **-** **`OnInit()`** **`void`** - A virtual method for the logic of initializing an action.

- **-** **`OnDeInit()`** **`void`** - A virtual method for deinit action.

- **-** **`OnStart()`** **`void`** - A virtual method for the logic executed when the action is started.

### Public Methods:

- **-** **`Init()`** **`void`** - Initializing the pipeline action.

- **-** **`DeInit()`** **`void`** - Deinit of the pipeline action.

- **-** **`Start()`** **`void`** - Starting the pipeline action.

### Developer contacts:

**Email - [n.fridman@burning-lab.com](mailto://n.fridman@burning-lab.com)**