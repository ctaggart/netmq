cd $PSScriptRoot
msbuild /t:restore /v:m
# msbuild /t:build /v:m
msbuild /t:publish /v:m