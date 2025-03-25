# Look-Up Table (LUT)

## Modules
### Core/
- Core octree implementation for spatial partitioning
- Location: Assets/Scripts/AdaptiveOctree/Core/
- Key Files:
  - `HysteresisActivationStrategy.cs`: Implements hysteresis-based node activation
  - `IActivationStrategy.cs`: Interface for node activation strategies
  - `IOctreeNode.cs`: Interface for octree nodes
  - `OctreeNode.cs`: Base implementation of octree nodes
  - `TimeoutActivationStrategy.cs`: Time-based node activation strategy

### Components/
- Unity-specific implementations and behaviors
- Location: Assets/Scripts/AdaptiveOctree/Components/
- Key Files:
  - `AdaptiveOctreeSDFProximityDetector.cs`: Main proximity detection component
  - `AdaptiveOctreeLeafTrigger.cs`: Trigger component for objects
  - `OctreeBuilder.cs`: Helper for octree construction
  - `OctreeStructureValidator.cs`: Validation utilities

### Editor/
- Unity Editor extensions
- Location: Assets/Scripts/AdaptiveOctree/Editor/
- Key Files:
  - `AdaptiveOctreeSDFProximityDetectorEditor.cs`: Custom inspector

### Visualization/
- Debug and visualization tools
- Location: Assets/Scripts/AdaptiveOctree/Visualization/
- Key Files:
  - `SDFVisualizationHelper.cs`: SDF visualization utilities

## Features Reference
### Spatial Partitioning
- Adaptive Octree Implementation
- Dynamic subdivision based on proximity
- Efficient neighbor finding
- Customizable activation strategies

### SDF (Signed Distance Field)
- Real-time distance calculations
- Proximity detection system
- Visualization tools

### Unity Integration
- Editor tools and custom inspectors
- Runtime performance optimization
- Debug visualization
- Event-based communication

## Architecture Notes
- Event-driven architecture for manager classes
- Strategy pattern for activation behavior
- Unity Editor integration
- Debug logging system

## Development Guidelines
- Use Unity Editor integration where possible
- Implement event-based communication between managers
- Include debug messages at key points
- Follow Unity C# coding conventions
- Use activation strategies for behavior customization