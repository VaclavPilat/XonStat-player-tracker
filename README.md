# XonStat player tracker
A simple web scraping application made in Windows Forms for tracking Xonotic players.

**This repo is not in development anymore, please use [a new version](https://github.com/VaclavPilat/XonStat-player-tracker-v2) instead.** 

## How it works
This program allows you to track selected Xonotic players by extracting information from their profiles on [XonStat webpage](https://stats.xonotic.org).
The web scraping part of this app is done using [Html Agility Pack](https://html-agility-pack.net/) package. 

All tracked players are currently stored in App.config file. After start, the program loads these players, prints them out to a data table and attempts to load information from their profiles.

To track a new player, click on `Add new player` button located in the top-right side of the main window. This should open a new window with textboxes for player ID and nickname.

**Note:** You can track only players who have set their profiles to be public in the game settings. If you cannot find the player on [XonStat webpage](https://stats.xonotic.org), he/she might have a private profile.

## How to run
You can [download the latest release](https://github.com/VaclavPilat/XonStat-player-tracker/releases/) or use the source code and build it yourself. 

Locate file `XonStat player tracker.exe` and run it.