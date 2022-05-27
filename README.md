# Sdk-For-Initializing-GA-and-FB
Custom sdk for initializing and event tracking for Facebook and Game Analytics 

PREREQUISITE
1. Convert your project on desired build platform (Android /ios)
2. Delete any Game Analytics or Facebook previously present in project
3. Import Tracking SDK.
4. After importing SDK you see the menu item of Tracking SDK. Click on the Tracking
SDK->Settings->Edit Settings.
5.Fill Keys for the desired platform and Click on “Check and Sync Settings” this will add
keys to relevant SDK.
6.From the menu go into Tracking SDK ->Create Tracking SDK GameObject, this will
create gameobject in the scene which will initialize all SDKs.

SCRIPTING 
1. On level start, call “TrackingSdkManager.GameStarted(level no)” and pass level
number in it.
2. On Level Fail, call “TrackingSdkManager.GameFailed(level no)” and pass level
number in it.
3. On Level Complete, call “TrackingSdkManager.GameFinished(level no)”and pass
level number in it.

AB TESTING 

1. Go to the menu item and Tracking SDK->Set Tests
2. Set desired tests in the settings which will show in the console and the analytics server
and click button.
3. After that you will see a prefab is added in the scene named as AbTest.
