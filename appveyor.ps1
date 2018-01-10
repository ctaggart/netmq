$version = '4.0.0.1'
$packageVersion = $version + '-pdb' + [int]::Parse($env:appveyor_build_number).ToString('000')
dotnet restore src/NetMQ.sln
msbuild src/NetMQ.sln /p:Configuration=Release /p:PackageVersion=$packageVersion /p:Version=$version /verbosity:minimal
dotnet pack src/NetMQ/NetMQ.csproj -c Release --no-build /p:PackageVersion=$packageVersion /p:Version=$version