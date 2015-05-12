@echo off
set p32=%programfiles(x86)%
set p64=%programfiles%

:: Find Java Executer
if "%JAVAEXE%"=="" (
    for /f "delims=" %%p in ('where java.exe') do set JAVAEXE=%%p
)

:: Find Scala Executer
if "%SCALAEXE%"=="" (
    for /f "delims=" %%p in ('where scala.bat') do set SCALAEXE=%%p
)

:: Find JavaScript Executer
if "%JSEXE%"=="" (
    for /f "delims=" %%p in ('where node.exe') do set JSEXE=%%p
)

:: Find Java Compiler
if "%JAVAC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%p32%\java\javac.exe"') do set JAVAC=%%p
)
if "%JAVAC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%p64%\java\javac.exe"') do set JAVAC=%%p
)

:: Find Scala Compiler
if "%SCALAC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%p32%\scala\scalac.bat"') do set SCALAC=%%p
)
if "%SCALAC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%p64%\scala\scalac.bat"') do set SCALAC=%%p
)

:: Find C# Compiler
if "%CSC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%windir%\Microsoft.NET\Framework\csc.exe"') do set CSC=%%p
)

:: Find F# Compiler
if "%FSC%"=="" (
    for /f "delims=" %%p in ('dir /s /b "%p32%\Microsoft SDKs\F#\fsc.exe"') do set FSC=%%p
)

echo JAVAEXE=%JAVAEXE%
echo SCALAEXE=%SCALAEXE%
echo JSEXE=%JSEXE%
echo JAVAC=%JAVAC%
echo SCALAC=%SCALAC%
echo CSC=%CSC%
echo FSC=%FSC%

set /A ERRS=0

if "%JAVAEXE%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find Java. Please make sure Java is installed.
if "%SCALAEXE%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find Scala. Please make sure Scala is installed.
if "%JSEXE%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find JavaScript. Please make sure Node is installed.
if "%JAVAC%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find Java Compiler. Please make sure JDK is installed.
if "%SCALAC%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find Scala Compiler. Please make sure Scala is installed.
if "%CSC%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find C# Compiler. Please make sure .NET Framework is installed. 
if "%FSC%"=="" SET /A ERRS=%ERRS%+1 & echo Unable to find F# Compiler. Please make sure .NET Framework is installed. 

if %ERRS% GTR 0 pause

:: Compile Test App
if not exist bin mkdir bin
if exist bin\test.exe del bin\test.exe
%csc% /nologo /out:bin\test.exe test.cs
bin\test.exe