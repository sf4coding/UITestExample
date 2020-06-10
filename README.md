# UI Test Example

This project should demonstrate how to use Xamarin UITests using a small weather app

## Weather API

I used the weather api OpenWeather in my project. In order to make the api calls you have to get an api key from https://openweathermap.org/api and insert it in the WeatherService.cs - Without the key the app will always claim that the entered city does not exist.

Using OpenWeather is free (for everything I used here) and it does not take long to get the api key ;)

Please make sure to click the link in the confirmation mail you get when you set up your OpenWeather account. Otherwise your API Keys will not work and you still get the error that your city does not exist.

## UI Test Execution

In order to be able to execute the UI Tests, you first must **build and install** the application using the UITest config. If you start a UI Test before that, the apk resp. app will not exist (you will get an exception). When the apk resp. app is created you can start the UI test on any emulator. It does not have to be installed to this emulator.

When you have installed the application you can execute the test, like you would execute any tests. The only thing you have to pay attention to is that you have exactly one Android emulator running if testing on Android. This emulator is used for the test execution. Executing iOS tests will start the default emulator on its own.
