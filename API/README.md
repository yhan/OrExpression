dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained -o=.\publish

this can be specified also by in csproj

    <PropertyGroup>        
        <PublishSingleFile>true</PublishSingleFile>
        <SelfContained>true</SelfContained>
        <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    </PropertyGroup>


> error NETSDK1097: It is not supported to publish an application to a single-file without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set PublishSingleFile to false. [C:\yi\repo\TestProject\api\API.csproj]


