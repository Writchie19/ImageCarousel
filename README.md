# ImageCarousel

ImageCarousel is a collection of applications used to allow users to take pictures on an android smart phone (in developer mode) and have them show up on a Windows PC in a full screen slide show.

## Installation

Currently there is no installer.  The following steps assume you have cloned this repository.  

To install the phone application:
1. Install Android Studio
2. Put your Android Smart Phone in developer mode
3. Connect your Android Smart Phone to your PC, then run the application using android studio.

To install the WPF App and .Net server (Both are needed for the application to work):
1. Install Visual Studio (Community and latest stable release is fine)
2. Ensure correct .Net 5 SDKs are installed
3. Open two instances of visual studio, one with ImageCarousel.Server loaded and the other with ImageCarousel2 loaded
4. Run both applications in debug mode

## Usage
The settings button on the android application should allow you to enter and save an IP address and port.  The port is currently hard coded to 5000.  This should be used to sync your PC's IP Address on your internal Wifi network. 

## Project Status
This project was created for a quick fun thing to do at a halloween party. I did not spend much time on it so most best practices were thrown out the window.  I plan to revamp the project every halloween (the next one being in 2022).  See below for the list of TODO.

## TODO

### General
- Change the name of the projects
- Refactor everything so it doesn't look like it was created in a few hours ;)

### Server/Client
- Add a settings page for the server (ImageCarousel.Client)
- Make the Source image directory configurable
- Auto upload images to a Google Drive (or maybe add a button that does this)

### WPF Application
- Add a settings page fro the WPF App (ImageCarousel2)
- Make the time between images on the carousel configurable
- Move the WPF app to MVVM Pattern
- Refactor the WPF app so it isn't holding onto the images in the directory at all time (gotta manage my resources better, worried about memory issues), maybe do a lazy loading mechanism, give a buffer of ~5 images both directions then deallocate memory and file handle as slide show progresses


### Android Application
- Add a next and previous button the Android App to control the slide show
- Handle taking a photo in landscape orientation
- Add viewing of previous photos on android app
- Change android app styling (its hideous)

## License
[MIT](https://choosealicense.com/licenses/mit/)
