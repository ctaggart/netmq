cd $PSScriptRoot
msbuild /t:restore /v:m
# msbuild /t:publish /v:m /p:TargetFramework=net462 /p:RuntimeIdentifier=win-x64
# msbuild /t:publish /v:m /p:TargetFramework=net462
msbuild /t:build /v:m