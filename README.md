# unity-direct-sdkintegration
1) Create your app in Unity IDE.
2)go to file/buildsettings->builSystem Gradle ->playerSettings ->select minify release & debug gradle -> put your bundleId in othersettings/identification/packageName. 
3)click build & run to see your app running in the connected android device.
---We Assume you have already gone through the above process and running unity app on android device -----------

---- go throug our documentayion to import unity package and code your .cs file ---------
4) go to your project folder->Temp-> gradleOut and copy build.gradle and save it somewhere . open it in any IDE or texteditor. 
5) carefully add the fields from the below build.gradle https://github.com/sourav12051987/unity-direct-sdkintegration/blob/master/Assets/Plugins/Android/mainTemplate.gradle
6) remember to change your applicationId in build.gradle.
7) Do not change the gradle version which unity provides.
8)Rename the file as mainTemplate.gradle and save it in the path Assets/Plugins/Android (If you don't have this folder create the folder)
9) Copy /Temp/StagingArea/AndroidManifest-main.xml and save it samewhere. open in Any IDE or text editor and add the baidu license key and the needed permissions. take reference from https://github.com/sourav12051987/unity-direct-sdkintegration/blob/master/Assets/Plugins/Android/AndroidManifest.xml
10) rename it as AndroidManifest.xml and save it in the folder Assets/Plugins/Android 
11) file/build settings /PublisherSettings check Custom Gradle Template. check if the path provided there is the same where you pasted your mainTemplate.gradle.
12) build and run in your android device or simulator
