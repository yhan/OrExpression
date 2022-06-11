dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained -o=.\publish

this can be specified also by in csproj

    <PropertyGroup>        
        <PublishSingleFile>true</PublishSingleFile>
        <SelfContained>true</SelfContained>
        <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    </PropertyGroup>


> error NETSDK1097: It is not supported to publish an application to a single-file without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set PublishSingleFile to false. [C:\yi\repo\TestProject\api\API.csproj]


→ C:\yi\repo\TestProject\API [main ↑2 +0 ~1 -0 !]› ls .\publish\

    Directory: C:\yi\repo\TestProject\API\publish

Mode LastWriteTime Length Name
----                 -------------         ------ ----
d----- 6/5/2022 5:01 PM publish2 -a---- 6/5/2022 5:01 PM 90183685 API.exe -a---- 6/5/2022 5:01 PM 20524 API.pdb -a----
6/5/2022 2:48 PM 127 appsettings.Development.json -a---- 6/5/2022 2:48 PM 151 appsettings.json -a---- 4/18/2022 2:08 PM
352896 aspnetcorev2_inprocess.dll -a---- 6/5/2022 5:01 PM 528 web.config
