@ECHO OFF

REG.exe Query HKLM\Hardware\Description\System\CentralProcessor\0 | findstr /i "x86" > NUL
If %ERRORLEVEL% == 0 (
    SET BITS=32
) ELSE (
    SET BITS=64
)

echo. > _framework.txt
FOR /f "usebackq delims=\ tokens=5" %%G IN (`reg.exe query HKLM\Software\Microsoft\.NetFramework`) DO echo %%G >> _framework.txt
FOR /f "usebackq tokens=1" %%G IN (`findstr /i v4 _framework.txt`) DO SET Version=%%G
del _framework.txt

set msbuild=C:\Windows\Microsoft.NET\Framework%BITS:32=%\%Version%\msbuild.exe

if exist %msbuild% goto build
echo MSBuild could not be found.
echo I detected %BITS%bits
echo Net Framework 4 is: %Version% 
echo So I guesst msbuild to be at: %msbuild% 
echo but it is not :-( 
echo I can not proceed, you got to fix this...
echo. 
goto error

:build
%msbuild% build.proj
if not %ERRORLEVEL% == 0 goto error

::%msbuild% build.proj /target:tests
::if not %ERRORLEVEL% == 0 goto error

goto exit
:error
echo There was an error!
pause

:exit

