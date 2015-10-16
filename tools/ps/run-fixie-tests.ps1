$PackagesFolder = $env:APPVEYOR_BUILD_FOLDER + "\src\packages"

$FixieFolder = Get-ChildItem $PackagesFolder -recurse | Where-Object {$_.PSIsContainer -eq $true -and $_.Name -match "Fixie"}

$LibFolder = $FixieFolder.FullName + "\lib"

$SubFoldersOfLib = Get-ChildItem $LibFolder -Directory

if($SubFoldersOfLib.Length -eq 0)
{
    echo "No folders in the fixie lib folder"
    exit
}

$NetFolder = $SubFoldersOfLib[0].FullName

$ExePath = $NetFolder + "\Fixie.Console.exe"

$Command = $ExePath + " " + $env:APPVEYOR_BUILD_FOLDER + "\src\PostHaste.Tests\bin\Release\PostHaste.Tests.dll  --NUnitXml " + $env:APPVEYOR_BUILD_FOLDER + "\TestResult.xml" 

echo "Running tests"

iex $Command

# upload results to AppVeyor
$wc = New-Object 'System.Net.WebClient'
$wc.UploadFile("https://ci.appveyor.com/api/testresults/nunit/$($env:APPVEYOR_JOB_ID)", ($env:APPVEYOR_BUILD_FOLDER + "\TestResult.xml"))
