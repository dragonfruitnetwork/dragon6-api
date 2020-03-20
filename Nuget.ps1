param ([string]$Suffix = "")

#versioning info
$DATE = Get-Date -UFormat "%Y.%m%d"
$VERSION = $DATE.$env:TRAVIS_BUILD_NUMBER$Suffix

#directories
$WORKINGDIR = Get-Location

#pack into nuget files with the suffix if we have one
Write-Output "Publishing Dragon6 API Version $VERSION"
dotnet pack -o $WORKINGDIR -c Release -p:PackageVersion=$VERSION

#recursively push all nuget files created
Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    dotnet nuget push $_ --api-key $env:nuget_key --source https://api.nuget.org/v3/index.json --force-english-output
}
