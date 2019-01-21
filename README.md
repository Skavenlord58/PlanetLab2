# PlanetLab 2

## Intro
PlanetLab2 is a better, more functional and more interactive continuation of the old C++ Planetlab made by @KulichCode. 
It's a "educational" space exploration game. Just like, say we, the Elite series, but without the fighting and trading. It isn't even the goal to mimic/clone it. This is a project to help me understand Unity better and to make me extend my skills.
Everything in this game is self-made (except for default Unity assets), this includes the graphics and sounds.

### Controls
**W/S** - Throttle control  
**R/F** - Pitch  
**A/D** - Yaw  
**Q/E** - Roll  

### Features
**Planet scanning** is automatic and happens when you place the scanner cursor on top of a planet body.  
**Ship acceleration** happens in stages, e.g. the ship doesn't speed up in linear motion, but rather a "transmission-based"
curve.  

#### Known bugs
> * ~~The game freezes for several seconds after you press the Play button in the main menu. This is because the game is loading, and is stuck on the first rendered frame. The loading screen is in progress.~~
> * ~~Scanner may go through planets and scan the planet behind the desired planet or the scanner doesn't register a planet at all. This is sadly due to Unity's render capabilities and not my fault (but I'm still trying to fix it!).~~

#### Changelog
* 2.19w4.0b
  * Loading screen
  * Fully functional ESC menu
  * Fixed Vsync problems
  * Fixed Shader issues
  
#### Upcoming features (TODO)
* Better player model (after I get used with Maya/Blender)
* Credits screen
* Achievements
* Better skybox and planet models
* New star systems!
  * Proxima Centauri
  * Barnard's Star
  * Luhman 16
  * WISE 0855−0714
  * Sirius
* More info about planets
* Better scaling for high resolutions (1440p+)
