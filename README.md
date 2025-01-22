# AC CSP Tree Collision Generator
 
Just a simple tool that generates collisions for CSP trees. You need .NET8 installed. If you dont, you should get prompted to install it.

1) Launch and select your trees.txt
2) Copy the content of `treecollider.txt` (created next to your trees.txt) into your csp config.

Alternatively (and preferrably) you can include it into your config like this:

```ini
[INCLUDE: /trees/treecollider.txt]
```
It saves you the hassle of always copying edited content in your config and just includes the entire file.

Make sure to add `WAV_PITCH=extended-0` to your first surface in surfaces.ini, for example:

```ini
[SURFACE_0]
KEY=PITS
FRICTION=0.97
DAMPING=0
WAV=
WAV_PITCH=extended-0
FF_EFFECT=NULL
DIRT_ADDITIVE=0
BLACK_FLAG_TIME=0
IS_VALID_TRACK=1
SIN_HEIGHT=0
SIN_LENGTH=0
IS_PITLANE=1
VIBRATION_GAIN=0
VIBRATION_LENGTH=0
```