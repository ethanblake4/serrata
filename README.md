# Serrata
Searrta is a DAW built for use in VR and, in the future, AR. Its Frontend uses Unity for its 3D component and physics features; this part is separate from the Audio Engine, which is written in C++. The core components of Serrata are its Frontend, Audio Engine, and AAP plugin spec.

## Frontend
Serrata's frontend is intented to be intuitive and straightforward for people familiar with DAWs, but improved in as many ways as possible via VR support.

## Audio Engine
The Audio Engine bridges plugins to output using a Mixer and interfaces with the Frontend. Serrata's audio engine is compatible with ASIO and WASAPI exclusive mode devices, enabling extremely low latency. 

### Mixer

In Serrata, Effects do not necessarily need to be processed on a mixer track. Instead, they can be directly attached to generators and an internal proxy mixer track will be created  (an "imixer track").
Each mixer track represents a data stream, not a thread. Two single-threaded generators can be processed in parallel, even if they share a track. However, effects requiring input audio on the same channel must be processed sequentially. If one Mixer track is routed to another, the two tracks will share a data stream. 

## Plugins

Native plugins for Serrata use the Augmented Audio Processor spec (AAP), and are loaded as DLLs by the Audio Engine. AAP plugins use an expand-collapse threading method which allows each individual voice to be processed on a separate thread and then combined on a single thread, leading to increased performance over current solutions for high-core-count processors. They also send 3D model data to the Frontend, and can be manipulated directly in VR.

In the future, Serrata aims to be compatible with VST and VSTi plugins through window capture.

## Extra

### Real-world mapping
Input devices such as keyboards, Launchpads, microphones etc are available to be mapped to real world devices. Supports HTC Vive Tracker, others. Allows mapping without 3D tracking- user positions the item in 3D to match its real world location, useful for eg. microphone.
