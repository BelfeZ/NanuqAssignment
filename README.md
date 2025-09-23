# Nanuq Assignment
This assignment is to demonstrating how understanding of programming princibles and software design.

# Technical decisions
**Input System**
This genre is very simple and used very few button to play. This project will use only **Left Mouse click and Escape Key** so i choose to use the Legacy input system that unity already have.

**Scene Management**
The GDD need **Main Menu, In-Game, Game Over** so i decide to use 2 scenes to operate. (Main Menu and In-game scene will working with Game Over in 1 scene.)

**UI System**
This genre mostly have very least button and simple. So i choose to be simple but rich with good UX also. This project will have tutorial for player and have very least button to press.

*Code Architecture*
This type of game mostly have a lot of numbers to use in script. For example is Jump Stregth, gravity or Obstacles spawn rate. This project have avoid a lot of magic number and can edit configuration inside unity editor easily. (This project have lock at 60 framerate to make game logic smooth as possible.) This project also using Instance Singleton and handle safely.
The save system this game using is Playerpref because this game doesn't save a lot of detail (only high score.) so that why this project is using Playerpref system.

**Asset Management**
This project asset has very limited choice to use so the graphic of this project will be not pretty as much. This project using only legally free asset. Free assets that being used in this project has been listed in readme file.

**Unity Version**
This project unity vesion is **Unity 6.0 (6000.0.58f1) LTS**

# Free Assets Used
- Ababil Bird Full Sprite - https://yudemgoy.itch.io/ababil-bird-full-sprite
- Parallax Cave Background Assets - https://slashdashgamesstudio.itch.io/cave-background-assets
- Upheavel Font - https://dl.dafont.com/dl/?f=upheaval
- Cave Background and Tileset - https://ludenc.itch.io/cave-background-and-tileset
- UNDER GUI Asset - https://prinbles.itch.io/under
- FREE Music Loop Bundle - https://tallbeard.itch.io/music-loop-bundle
