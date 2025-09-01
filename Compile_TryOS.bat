:: copys the dll's over to the TryOS_Build folder
copy ".\TouchTest\bin\Debug\*.dll" ".\TouchTest\bin\Debug\TryOS_Build\"

:: Creates Settings Folder.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Settings"
copy ".\TouchTest\bin\Debug\Settings\temp.txt" ".\TouchTest\bin\Debug\TryOS_Build\Settings\"

:: Creates Folder for wallpapers
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_1.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_2.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_3.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_4.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"

:: Creates the folders that Webview2 needs.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x64\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native\"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x86\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native\"

:: Copys Main Program .exe
copy ".\TouchTest\bin\Debug\TouchTest.exe" ".\TouchTest\bin\Debug\TryOS_Build\TryOS.exe"
:: Add More when needed.

pause