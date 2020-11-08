param ([string] $ApiKey, [string]$Suffix = "")

#versioning info
$VERSION = "$(Get-Date -UFormat "%Y.%m%d").$($env:GITHUB_RUN_NUMBER)$($Suffix)"
$WORKINGDIR = Get-Location

#Build files

Write-Output "Building DragonFruit.Six.API Version $VERSION"
dotnet restore
dotnet build -c Release /p:PackageVersion=$VERSION

#pack into nuget files with the suffix if we have one

Write-Output "Publishing DragonFruit.Six.API Version $VERSION"
dotnet pack ".\DragonFruit.Six.API\DragonFruit.Six.API.csproj" -o $WORKINGDIR -c Release -p:PackageVersion=$VERSION -p:Version=$VERSION

#recursively push all nuget files created

Get-ChildItem -Path $WORKINGDIR -Filter *.nupkg -Recurse -File -Name | ForEach-Object {
    dotnet nuget push $_ --api-key $ApiKey --source https://api.nuget.org/v3/index.json --force-english-output
}
