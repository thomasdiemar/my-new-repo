# Planet Generator

A procedural planet generation system for Unity with seamless zoom capabilities.

## Features

- **Procedural Noise Generation**: 2D and 3D Perlin noise with fractal Brownian motion
- **Terrain Generation**: Height, normal, and color generation based on noise functions  
- **Level of Detail (LOD)**: Dynamic LOD system for performance optimization
- **Extensible Architecture**: Modular design ready for additional features

## Components

### Noise.cs
- 2D Perlin noise generation
- 3D Perlin noise generation  
- Fractal Brownian Motion (fBm) noise generation

### PlanetGenerator.cs
- Terrain height generation using noise functions
- Terrain normal generation for lighting calculations
- Terrain color generation with elevation-based coloring
- LOD (Level of Detail) system implementation
- Mesh generation framework

### Tests
Comprehensive unit tests covering all core functionality.

## Usage

1. Create a new PlanetGenerator instance
2. Configure parameters as needed
3. Call generation methods to create terrain data
4. Use the generated data for mesh creation and rendering

## Integration

This system is designed to work within Unity's ecosystem and can be extended with:
- Biome generation systems
- Atmospheric effects
- Advanced rendering pipelines
- Performance optimization features