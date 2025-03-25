# Unity SDF Octree Proximity Detection

A real-time proximity detection system implemented in Unity, utilizing Signed Distance Fields (SDF) and adaptive octree space partitioning for efficient spatial queries and distance calculations.

## Overview
This project combines the power of Signed Distance Fields with adaptive octree space partitioning to achieve efficient and accurate proximity detection in real-time applications. The implementation is specifically designed for Unity environments, providing both runtime performance and editor integration.

## Features
- Adaptive octree space partitioning
- Real-time SDF-based proximity detection
- Dynamic subdivision based on spatial density
- Efficient neighbor finding and spatial queries
- Unity Editor integration and debug visualization

## Project Structure
```
Assets/Scripts/AdaptiveOctree/
├── Core/                           # Core octree implementation
│   ├── HysteresisActivationStrategy.cs
│   ├── IActivationStrategy.cs
│   ├── IOctreeNode.cs
│   ├── OctreeNode.cs
│   └── TimeoutActivationStrategy.cs
├── Components/                     # Unity components
│   ├── AdaptiveOctreeSDFProximityDetector.cs
│   ├── AdaptiveOctreeLeafTrigger.cs
│   ├── OctreeBuilder.cs
│   └── OctreeStructureValidator.cs
├── Editor/                        # Unity Editor extensions
│   └── AdaptiveOctreeSDFProximityDetectorEditor.cs
├── Visualization/                 # Debug visualization tools
│   └── SDFVisualizationHelper.cs
└── Scenes/                       # Example scenes
    └── Example Scene.unity
```

## Requirements
- Unity 2020.3 or higher
- .NET Standard 2.0+

## Installation
1. Clone this repository into your Unity project's Assets folder
2. Import the necessary dependencies
3. Configure the octree settings in the Unity Editor

## Quick Start
1. Add the `AdaptiveOctreeSDFProximityDetector` component to your scene
2. Configure the octree parameters in the inspector
3. Add `AdaptiveOctreeLeafTrigger` components to objects you want to track
4. Run the scene and use the visualization tools to debug

## Documentation
- See [LUT.md](LUT.md) for detailed component documentation
- Check [FEATURE_LIST.md](FEATURE_LIST.md) for current and planned features

## License
MIT License

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.