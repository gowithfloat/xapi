#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

Target.create "Clean" (fun _ ->
    !! "**/bin"
    ++ "**/obj"
    |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
    !! "Float.xAPI/*.fsproj"
    |> Seq.iter (DotNet.build id)
)

//  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
Target.create "Test" (fun _ ->
    !! "Float.xAPI.Tests/*.csproj"
    |> Seq.iter (DotNet.test id)
)

//  /p:Configuration=Release /p:PackageVersion=0.0.2
Target.create "Pack" (fun _ ->
    !! "Float.xAPI/*.fsproj"
    |> Seq.iter (DotNet.pack id)
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Pack"
  ==> "All"

Target.runOrDefault "All"
